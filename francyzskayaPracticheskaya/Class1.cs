using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_7
{
    public static class GetFiles
    {
        public static List<File1> Get(string path)
        {
            List<File1> File1list = new List<File1>();
            foreach (string file in Directory.GetDirectories(path))
                File1list.Add(new File1(file.Split("\\")[^1]+"\\", file));
            foreach (string file in Directory.GetFiles(path))
                File1list.Add(new File1(file.Split("\\")[^1], file));
            return File1list;
        }
    }
    public class Cursor
    {
        public Cursor(int max = 1, int min = 1, int pos = 1)
        {
            this.max = max;
            this.min = min; 
            this.pos = pos;
        }
        public int max, min, pos;
    }
    public static class ShowInformation
    {
        public static void ShowDirs(List<File1> papkaList)
        {
            foreach (File1 elem in papkaList)
                Console.WriteLine("   " + elem.name);
        }
    }
    public class File1
    {
        public File1(string name, string path)
        {
            
            this.path = path;
            this.name = name;
        }
        public string name;
        public string path;
    }
}
