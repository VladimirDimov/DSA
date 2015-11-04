//  Write a program to traverse the directory C:\WINDOWS and all its subdirectories 
//  recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.
namespace ConsoleApplication1
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            var rootPath = @"c:\windows";
            PrintAllExeFiles(rootPath);
        }

        private static void PrintAllExeFiles(string rootPath, int indentation = 0)
        {
            var subFolders = Directory.GetDirectories(rootPath);
            var containedFiles = Directory.GetFiles(rootPath);

            foreach (var file in containedFiles)
            {
                if (file.EndsWith(".exe"))
                {
                    Console.WriteLine(file);
                }
            }

            foreach (var folder in subFolders)
            {
                PrintAllExeFiles(folder, indentation + 3);
            }
        }
    }
}
