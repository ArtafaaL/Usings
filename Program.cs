using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

//Написать пример, приложения, читающего файл из потока(Stream)

namespace Usings
{
    internal class Program
    {
        private static string ReadFile(FileStream file)
        {
            byte[] buffer = new byte[file.Length];
            file.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        static void Main(string[] args)
        {
             string path = @"F:\Основы C#\_Res\ReadMeAndClose.txt"; // нужно поправить для своего ПК. Да, хард код - зло.
            try
            {
                using (FileStream streamFile = new FileStream(path, FileMode.Open))
                {
                    Console.WriteLine(ReadFile(streamFile));
                }
            }
            catch (FileNotFoundException)
            {
                FileStream streamFile = new FileStream(path, FileMode.CreateNew);
                Console.WriteLine("Файла не было, в связи с этим создал новый.");
                streamFile.Dispose();
            }
        }
    }
}
