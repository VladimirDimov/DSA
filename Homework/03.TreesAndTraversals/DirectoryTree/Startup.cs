namespace DirectoryTree
{
    using System.Collections.Generic;
    using System.IO;

    class Startup
    {
        static void Main()
        {
            var rootPath = @"c:\windows";
            var rootFolder = new Folder(rootPath);

            CreateFolderTree(rootFolder);

            var size = CalculateSize(rootFolder);
        }

        private static void CreateFolderTree(Folder folder)
        {
            var folderInfo = new DirectoryInfo(folder.Name);
            var subFilesToAdd = new List<File>();
            var subFoldersToAdd = new List<Folder>();

            FileInfo[] containedFIlesInfo = folderInfo.GetFiles();
            foreach (FileInfo file in containedFIlesInfo)
            {
                var fileToAdd = new File(file.Name, (int)file.Length);
                subFilesToAdd.Add(fileToAdd);
            }

            folder.Files = subFilesToAdd.ToArray();

            foreach (var subfolder in Directory.GetDirectories(folder.Name))
            {
                var folderToAdd = new Folder(subfolder);
                subFoldersToAdd.Add(folderToAdd);
                CreateFolderTree(folderToAdd);
            }

            folder.Folders = subFoldersToAdd.ToArray();
        }

        private static int CalculateSize(Folder folder, int size = 0)
        {
            foreach (var file in folder.Files)
            {
                size += file.Size;
            }

            foreach (var subfolder in folder.Folders)
            {
                size += CalculateSize(subfolder);
            }

            return size;
        }
    }
}
