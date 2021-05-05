using System.IO;

namespace DotNetBlog.Cli.Utils
{
    public static class DirectoryHelper
    {
        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            var files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)
            {
                var name = Path.GetFileName(file);
                var dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            
            var folders = Directory.GetDirectories(sourceFolder);

            foreach (string folder in folders)
            {
                var name = Path.GetFileName(folder);
                var dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}