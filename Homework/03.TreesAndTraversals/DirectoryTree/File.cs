namespace DirectoryTree
{
    class File
    {
        public File(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }

        public int Size { get; set; }
    }
}
