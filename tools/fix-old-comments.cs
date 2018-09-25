// fix-old-comments.cs
// Imports comments in the form needed from a Wordpress export
//css_args -provider:%CSSCRIPT_DIR%\lib\CSSRoslynProvider.dll
//css_ref %CSSCRIPT_DIR%\lib\Bin\Roslyn\System.ValueTuple.dll
//css_nuget YamlDotNet
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

public class Comment
{
    public string id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string avatar { get; set; }
    public string gravatar { get; set; }
    public string date { get; set; }
    public string url { get; set; }
    public bool is_sean { get; set; }
    public string message { get; set; }
}

class Script
{
    private static Deserializer m_Deserializer = new Deserializer();
    private static Serializer m_Serializer = new Serializer();
    private static Regex m_GravatarRegex = new Regex(@"https://www.gravatar.com/avatar/([A-Za-z0-9]+)?");

    public static void Main()
    {
        Console.WriteLine("Fixing wordpress comments ...");

        foreach (var path in Directory.GetFiles(@"..\_data\comments-src", "*.yml", SearchOption.AllDirectories))
        {
            using (var reader = File.OpenText(path))
            {
                Console.WriteLine($"Fixing {path}");
                var comment = m_Deserializer.Deserialize<Comment>(reader);
                WriteFixedComment(path, comment);
            }
        }

        Console.WriteLine("done.");
    }

    private static void WriteFixedComment(string sourcePath, Comment comment)
    {
        // Fix up the comment
        // Need to double do-it on newlines (for markdown)
        comment.message = comment.message.Replace("\n", "\n\n");

        // Is this me leaving a comment?
        if (comment.email != null && comment.email.Contains("seanba"))
        {
            comment.is_sean = true;
        }

        // Avatar to Gravatar
        var match = m_GravatarRegex.Match(comment.avatar ?? string.Empty);
        if (match.Success)
        {
            comment.gravatar = match.Groups[1].Value;
        }
        else
        {
            comment.gravatar = "fixit";
        }

        comment.avatar = null;
        comment.email = null;

        // Export the fixed up comment
        var path = sourcePath.Replace("comments-src", "comments");

        Console.WriteLine($"Writing: {path}");
        Directory.CreateDirectory(Path.GetDirectoryName(path));

        using (var writer = new StreamWriter(path))
        {
            m_Serializer.Serialize(writer, comment);
        }
    }
}