using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Controller
    {
        private string m_WorkingPath = @"";
        private List<string> m_FileExtension;
        private string[] m_FilesNameInWorkingPath;

        public string[] FilesNameInWorkingPath { get => m_FilesNameInWorkingPath; set => m_FilesNameInWorkingPath = value; }
        public string WorkingPath { get => m_WorkingPath; set => m_WorkingPath = value; }
        public string LogFileName { get => m_LogFileName; set => m_LogFileName = value; }

        string m_LogFileName;
        public Controller(string i_WorkingPath)
        {
            this.WorkingPath = i_WorkingPath;
            m_FileExtension = new List<string>();
            /*
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            string test = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            */
            LogFileName = DateTime.Now.ToShortDateString().ToString().Replace("/","_") + ".txt";
            LogFileName = Path.Combine(WorkingPath,LogFileName);
        }

        public void start()
        {
            FilesNameInWorkingPath = getFilesFromDirectory(WorkingPath);
            collectFlieExtension();
            createExtnsionDirectories();
            copyFilesByExtension();
        }

        private void copyFilesByExtension()
        {
            logToFile(LogFileName, "Starting process: " + DateTime.Now.ToString());
            foreach (var extension in m_FileExtension)
            {
                foreach (var file in FilesNameInWorkingPath)
                {
                    string currentFileExtension = removeDotFromExtension(file);
                    if (extension.Equals(currentFileExtension))
                    {
                        if (File.Exists(file))
                        {
                            string fileName = Path.GetFileName(file);
                            File.Copy(file, Path.Combine(WorkingPath,extension,fileName), true);
                            logToFile(LogFileName, string.Format(@"Copy : {0} to destination : {1}", file, Path.Combine(WorkingPath, extension, fileName)));
                            File.Delete(file);
                            logToFile(LogFileName, string.Format(@"Deleted : {0}.", file));
                        }

                    }
                }
            }
            logToFile(LogFileName, "End process: " + DateTime.Now.ToString());
        }

        private void logToFile(string i_LogFileName, string i_Message)
        {
            File.AppendAllText(i_LogFileName, i_Message + Environment.NewLine);
        }

        private string removeDotFromExtension(string file)
        {
            string currentFileExtension = Path.GetExtension(file);
            currentFileExtension = currentFileExtension.Replace(".", "");
            return currentFileExtension;
        }

        private void createExtnsionDirectories()
        {
            foreach (var extension in m_FileExtension)
            {
                string directoryToCreate = Path.Combine(WorkingPath,extension);
                Directory.CreateDirectory(directoryToCreate);
            }
        }

        private void collectFlieExtension()
        {
            foreach (var file in FilesNameInWorkingPath)
            {
                string fileExtension = removeDotFromExtension(file);
                m_FileExtension.Add(fileExtension);
                
            }
        }

        private string[] getFilesFromDirectory(string i_WorkingPath)
        {
            string[] filesNames= null;
            filesNames = Directory.GetFiles(i_WorkingPath);
            return filesNames;
        }
    }
}
