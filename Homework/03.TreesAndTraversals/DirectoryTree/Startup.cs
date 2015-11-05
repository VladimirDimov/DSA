namespace DirectoryTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Enter initial directory (default: c:\\windows)");
            var rootPath = Console.ReadLine();
            rootPath = rootPath == string.Empty ? @"C:\windows" : rootPath;

            var rootFolder = new Folder(rootPath);
            Console.WriteLine("Slow operation...");
            CreateFolderTree(rootFolder);

            var size = CalculateSize(rootFolder);
            Console.WriteLine("{0} size: {1} bytes", rootPath, size);
        }

        private static void CreateFolderTree(Folder folder)
        {
            var folderInfo = new DirectoryInfo(folder.Name);
            var subFilesToAdd = new List<File>();
            var subFoldersToAdd = new List<Folder>();

            FileInfo[] containedFIlesInfo = new FileInfo[0];
            try
            {
                containedFIlesInfo = folderInfo.GetFiles();
            }
            catch (System.Exception)
            {
            }

            foreach (FileInfo file in containedFIlesInfo)
            {
                var fileToAdd = new File(file.Name, (int)file.Length);
                subFilesToAdd.Add(fileToAdd);
            }

            folder.Files = subFilesToAdd.ToArray();

            try
            {
                var subDirs = Directory.GetDirectories(folder.Name);
                foreach (var subfolder in subDirs)
                {
                    var folderToAdd = new Folder(subfolder);
                    subFoldersToAdd.Add(folderToAdd);
                    CreateFolderTree(folderToAdd);
                }

                folder.Folders = subFoldersToAdd.ToArray();
            }
            catch (System.Exception)
            {
            }
        }

        private static ulong CalculateSize(Folder folder, ulong size = 0)
        {
            foreach (var file in folder.Files)
            {
                size += (ulong)file.Size;
            }

            foreach (var subfolder in folder.Folders)
            {
                try
                {
                    size += (ulong)CalculateSize(subfolder);
                }
                catch (System.Exception)
                {
                }
            }

            return size;
        }
    }
}
