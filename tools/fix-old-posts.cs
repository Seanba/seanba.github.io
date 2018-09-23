// fix-old-posts.cs
// Go through our posts exported from wordpress and fix them up for the new blog
//css_args -provider:%CSSCRIPT_DIR%\lib\CSSRoslynProvider.dll
//css_ref %CSSCRIPT_DIR%\lib\Bin\Roslyn\System.ValueTuple.dll
using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

class Script
{
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
        Console.WriteLine($"Fixing wordpress post: {path}");

        // fixit - choose deprecation type (or no deprecation at all)
        contents = contents.SetFrontMatterValue("layout", "old-post-deprecated");

        // Get rid of decorated characters
        contents = contents.Replace("&#8230;", "...");
        contents = contents.Replace("&#8217;", "'");
        contents = contents.Replace("&#160;", " ");

        // Fix content links
        contents = contents.Replace("http://www.seanba.com/blog/wp-content/uploads", "/assets/wp-content/uploads");

        // Fix internal permalinks

        File.WriteAllText(path, contents);
    }

    private static FixPermalinks(string contents)
    {
        // var output = Regex.Replace(input, @"\$\$.+?\$\$", m => m.Value.ToLower());
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
