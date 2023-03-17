using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FiveM_Cleane
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "FiveM Cleaner | -TOXIC-#1835 (CFT Development)";
            string username = Environment.UserName;
            string path = @"C:\Users\" + username + @"\AppData\Local\FiveM\FiveM.app";
            Console.Write("If you want to start press [" + ConsoleKey.Enter + "]");
            Console.ReadKey();
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path + @"\data");
                DirectoryInfo directory2 = new DirectoryInfo(path + @"\data\nui-storage");
                DirectoryInfo directory3 = new DirectoryInfo(path + @"\crashes");
                DirectoryInfo directory4 = new DirectoryInfo(path + @"\logs");

                if (directory.Exists)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("[#] In directory: " + directory.FullName);
                    Console.ResetColor();
                    foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                    {
                        if (subDirectory.Name == "cache" || subDirectory.Name == "server-cache" || subDirectory.Name == "server-cache-priv")
                        {
                            subDirectory.Delete(true);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[+] Deleted > ");
                            Console.ResetColor();
                            Console.WriteLine(subDirectory.Name);
                        }
                    }
                    if (directory2.Exists)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("[#] In directory: " + directory2.FullName);
                        Console.ResetColor();
                        foreach (DirectoryInfo subDir in directory2.GetDirectories())
                        {
                            if (subDir.Name.StartsWith("context-server") || subDir.Name.ToLower().Contains("cache"))
                            {
                                subDir.Delete(true);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("[+] Deleted > ");
                                Console.ResetColor();
                                Console.WriteLine(subDir.Name);
                            }
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Cannot find the FiveM Folder!");
                    Console.ResetColor();
                }
                if (directory3.Exists)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("[#] In directory: " + directory3.FullName);
                    Console.ResetColor();
                    foreach (FileInfo file in directory3.GetFiles())
                    {
                        file.Delete();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[+] Deleted > ");
                        Console.ResetColor();
                        Console.WriteLine(file.Name);
                    }
                }
                if (directory4.Exists)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("[#] In directory: " + directory4.FullName);
                    Console.ResetColor();
                    foreach (FileInfo file in directory4.GetFiles())
                    {
                        file.Delete();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[+] Deleted > ");
                        Console.ResetColor();
                        Console.WriteLine(file.Name);
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[*] Completely done! | Everything Got Removed.");
                Console.ResetColor();
                Console.Write("Do you want to remove additional data to be able to get unbaned? Press [" + ConsoleKey.Y + "]");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                {
                    DirectoryInfo addPath = new DirectoryInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Local\DigitalEntitlements");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("[#] In directory: " + addPath.FullName);
                    Console.ResetColor();
                    foreach (FileInfo file in addPath.GetFiles())
                    {
                        file.Delete();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[+] Deleted > ");
                        Console.ResetColor();
                        Console.WriteLine(file.Name);
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[*] Completely done! | Additional Data Got Removed.");
                    Console.WriteLine("[!] Change Rockstar & Steam Account + Sign out from FiveM!");
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
            Console.ReadLine();
        }
    }
}
