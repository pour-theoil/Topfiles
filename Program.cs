using System;
using System.IO;
using System.Linq;

namespace topfiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = "";
            int max = 10;
            if (args?.Length > 0)
            {
                if (args[0] == "-d")
                {
                    sourceDirectory = args[1];
                }
            }


            if (args.Length > 2)
            {
                if (args[2] == "-n")
                {
                    int.TryParse(args[3], out int num);
                    max = num;
                }
            }

            else
            {
                sourceDirectory = @"C:\Users\frank\Downloads";
            }



            RecentFiles topfiles = new RecentFiles();

            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory);

                foreach (string currentFile in txtFiles)
                {

                    string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                    Files file = new Files(fileName);

                    FileInfo fi = new FileInfo($@"{sourceDirectory}\{fileName}");

                    long size = fi.Length;
                    file.filesize = size;

                    file.time = fi.CreationTime;

                    topfiles.addFile(file, file.time);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var sorted = from pair in topfiles.recents
                         orderby pair.Value descending
                         select pair;

            int i = 0;
            foreach (var pair in sorted)
            {
                if (i < max)
                {
                    Console.WriteLine($@"{i + 1}) {pair.Key.filename} 
Created: {pair.Key.time}
Size: {pair.Key.filesize/10000} mbs
");
                    i++;
                }
            }




        }
    }
}
