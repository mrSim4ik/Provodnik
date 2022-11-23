using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Практическая_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "\\";
            Cursor cursor = new Cursor();
            List<File1> filelist = new List<File1>();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                cursor.max = 0;
                Console.WriteLine("Проводник.ехе. Текущий путь - "+file);
                if (file == "\\")
                {
                    filelist = new List<File1>();
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    foreach (DriveInfo drive in allDrives)
                    {
                        double totalSpace = drive.TotalSize;
                        double availableSpace = drive.AvailableFreeSpace;
                        File1 elem = new File1($"Диск {drive.Name} | Размер {totalSpace} гб | Доступно {availableSpace} гб", drive.Name);
                        filelist.Add(elem);
                    }
                }
                else
                {
                    try
                    {
                        filelist = GetFiles.Get(file);
                    }
                    catch
                    {
                        
                    }
                    
                }
                ShowInformation.ShowDirs(filelist);
                cursor.max = filelist.Count;
                Console.SetCursorPosition(0, cursor.pos);
                Console.Write(">>");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        if (Directory.Exists(filelist[cursor.pos - cursor.min].path))
                        {
                            file = filelist[cursor.pos - cursor.min].path;
                        }
                        else
                        {
                            Process.Start(filelist[cursor.pos - cursor.min].path);
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor.pos == cursor.max)
                            cursor.pos = cursor.min;
                        else
                            cursor.pos++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (cursor.pos == cursor.min)
                            cursor.pos = cursor.max;
                        else
                            cursor.pos--;
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}