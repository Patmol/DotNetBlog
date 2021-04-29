using System;
using System.CommandLine.Parsing;
using System.IO;
using DotNetBlog.Cli.Commands.Build;

namespace DotNetBlog.Cli.Tools.Common
{
    public static class BlogPath
    {
        public static string GetBlogPath(ParseResult parseResult)
        {
            string pathDirectory;

            if (parseResult.HasOption(BuildCommandParser.PathOption)) 
            {
                // Retrieve the path set in the option and check if the path is valid.
                pathDirectory = parseResult.ValueForOption<string>(BuildCommandParser.PathOption);

                if (pathDirectory.StartsWith("~"))
                {
                    string homePath = (Environment.OSVersion.Platform == PlatformID.Unix || 
                        Environment.OSVersion.Platform == PlatformID.MacOSX)
                            ? Environment.GetEnvironmentVariable("HOME")
                            : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

                    pathDirectory = pathDirectory.Replace("~", homePath);
                }

                if (!Directory.Exists(pathDirectory))
                {
                    throw new DirectoryNotFoundException($"The path '{pathDirectory}' does not exist.");
                }  
            }
            else
            {
                // Get the exec path
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                pathDirectory = System.IO.Path.GetDirectoryName(path);
            }

            return pathDirectory;
        }
    }
}