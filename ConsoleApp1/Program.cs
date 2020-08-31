using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp1
{


    public class Program
    {
        static void Main(string[] args)
        {
            Smtp mailSender = new Smtp();
            mailSender.define();
            mailSender.sendMail();
            Console.ReadLine();
            /*
            subMarine sm = new subMarine();
            Console.ReadLine();*/
            /*
            stackcs st = new stackcs();
            st.run();
            Console.ReadLine();
          /*  Controller m_engine = new Controller(@"C:\testFoleder");
            m_engine.start();
            Console.ReadLine();
            */
            /*
            string folderPath = @"C:\Users\itayco\Desktop\info";
            ZipFile.CreateFromDirectory(folderPath, @"C:\Users\itayco\Desktop\info\test.zip");
            string[] dirs = Directory.GetDirectories(folderPath);
            string[] files = Directory.GetFiles(folderPath);
            printDirectories(dirs);
            printFiles(files);
            Console.WriteLine(Environment.NewLine);
            string[] fileContent = File.ReadAllLines(files[0]);

            Console.WriteLine(files[0]);
            Console.WriteLine(Path.GetFileName(files[0]) + " " + Path.GetFileNameWithoutExtension(files[0]));
            string[] parts = files[0].Split('\\');
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }

            var info = new FileInfo(files[0]);
            DateTime dt = new DateTime();
            dt = info.LastWriteTime;

            Console.WriteLine(dt);
            /*foreach (var line in fileContent)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }

        private static void printFiles(string[] files)
        {
            Console.WriteLine("Files :");
            foreach (var fileName in files)
            {
                Console.WriteLine(fileName);
            }
        }

        private static void printDirectories(string[] dirs)
        {
            Console.WriteLine("Directories :");
            foreach (var dirName in dirs)
            {
                Console.WriteLine(dirName);
            }
        }*/

        }
    }
}
