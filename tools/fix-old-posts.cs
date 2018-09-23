// fix-old-posts.cs
// Go through our posts exported from wordpress and fix them up for the new blog
//css_args -provider:%CSSCRIPT_DIR%\lib\CSSRoslynProvider.dll
//css_ref %CSSCRIPT_DIR%\lib\Bin\Roslyn\System.ValueTuple.dll
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Script
{
    public static char[] NewLines = Environment.NewLine.ToCharArray();

    public static void Main()
    {
        Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");

        foreach (var file in Directory.GetFiles(@"..\collections\_posts", "*.md", SearchOption.AllDirectories))
        {
            var contents = File.ReadAllText(file);

            // If the post is from before 2018 then it was imported from Wordpress and we want to fix it
            if (contents.TryGetFrontMatterValue("date", out string value) && DateTime.TryParse(value, out var date))
            {
                if (date.Year < 2018)
                {
                    FixFile(file, contents);
                }
            }
        }
    }

    private static void FixFile(string path, string contents)
    {
        // Back up the file in case I bone things up
        var dir = Path.GetDirectoryName(path) + "_bak";
        Directory.CreateDirectory(dir);
        File.WriteAllText(Path.Combine(dir, Path.GetFileName(path)), contents);

        Console.WriteLine($"Fixing wordpress post: {path}");

        // fixit - choose deprecation type (or no deprecation at all)
        contents = contents.SetFrontMatterValue("layout", "old-post-deprecated");

        // Get rid of the guid front-matter
        var lines = contents.Split(NewLines).Where(l => !l.StartsWith("guid:")).ToArray();
        contents = string.Join("\n", lines);

        // Get rid of decorated characters
        contents = contents.Replace("&#8230;", "...");
        contents = contents.Replace("&#8217;", "'");
        contents = contents.Replace("&#160;", " ");
        contents = contents.Replace("&amp;", "&");
        contents = contents.Replace("&rsquo;", "'");
        contents = contents.Replace("&ndash;", "-");
        contents = contents.Replace("&#8211;", "-");

        // Fix content links
        contents = contents.Replace("http://www.seanba.com/blog/wp-content/uploads", "/assets/wp-content/uploads");
        contents = FixPermalinks(contents);

        File.WriteAllText(path, contents);
    }

    private static string FixPermalinks(string contents)
    {
        // convert http://www.seanba.com/path/to/page to {{ page/to/page | relative_url }}
        contents = Regex.Replace(contents,
            @"http://www.seanba.com/([A-Za-z0-9\-\\_/]+)",
            m => string.Format("{{{{ '/{0}/' | relative_url }}}}", m.Groups[1].Value),
            RegexOptions.IgnoreCase);
        return contents;
    }
}

public static class RegexExtensions
{
    public static bool TryGetFrontMatterValue(this string thisString, string variable, out string value)
    {
        var r = new Regex($"^{variable}:\\s+(.*)$", RegexOptions.Multiline);

        var m = r.Match(thisString);
        if (m.Success)
        {
            value = m.Groups[1].Value;
            return true;
        }

        value = string.Empty;
        return false;
    }

    public static string SetFrontMatterValue(this string thisString, string variable, string value)
    {
        var pattern = $"^{variable}:\\s+(.*)$";
        return Regex.Replace(thisString, pattern, $"{variable}: {value}", RegexOptions.Multiline);
    }
}
