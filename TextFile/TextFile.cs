using System.IO;

namespace TextFile
{
    public class TextFile
    {
        public string Path { get; set; } = string.Empty;

        public void Create(string i_Path)
        {
            File.Create(i_Path); 
        }

        public void Append(string[] i_Lines)
        {
            foreach (string line in i_Lines)
            {
                Append(line);
            }
        }
        public void Append(string i_Line)
        {
            File.AppendAllText(Path, i_Line);
        }

        public bool Exist(string i_Path)
        {
            return File.Exists(Path);
        }
    }
}
