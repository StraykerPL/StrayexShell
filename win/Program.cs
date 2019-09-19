﻿/*
    Strayex Shell for Windows
    Copyright © 2019 Daniel Strayker Nowak
    All rights reserved
 */

using System;
using System.Diagnostics;
using System.IO;

namespace strayex_shell_win
{
    class Program
    {
        public static string ShellPath = Directory.GetCurrentDirectory(); // Directory to work,
        public static string Cmd = ""; // Command,
        public static string[] Args = new string[50]; // Arguments,

        // Counts, how much times the given char appears in string, maybe will be usefull in future:
        static int CountChar(char x, string y)
        {
            int Long = y.Length;
            int Counter = 0;

            for(int i = 0; i < Long; i++) if (y[i] == x) Counter++;

            return Counter;
        }
        
        static string DiscussFile(string FileName)
        {
            // Is it only executable filename or filename with extenstion?
            if(FileName.Contains("."))
            {
                // With extenstion!

                int i = 0;
                try
                {
                    for (; FileName[i] != '.'; i++) ;
                }
                catch (Exception)
                {
                    return "0"; // If file is unknown, shell can't execute it!
                }

                string Extenstion = FileName.Substring(i + 1); // Gets extension name,

                // Determine, witch file is it:
                if (Extenstion == "exe") return "apk";
                else if (Extenstion == "txt") return "text";
                else if (Extenstion == "png") return "image";
                else return "0"; // If file is unknown, shell can't execute it!
            }
            else
            {
                // Just filename! So shell have to find app in workdir:
                // TODO: Some fun with it!
                string[] Apps = Directory.GetFileSystemEntries(ShellPath);

                for (int i = 0; i < Apps.Length; i++)
                {
                    //string Temp = 
                    //if (Temp == ShellPath + '\\' + FileName)
                   // {
                    //    return "";
                   // }
                   // else
                   // {
                        // If shell can't find the file, it can't execute it!
                   //     return "0";
                   // }
                }
            }

            return "0";
        }

        static void CmdInterpreter()
        {
            // First index is command, higher indexes are arguments,
            // If user proviede args for commands, that don't need them, shell will ignore them,

            string[] apps = Directory.GetFiles(ShellPath);

            // Commands:
            if (Cmd == "hello")
            {
                // Say hi to user :)
                Console.WriteLine("Hello user! :D");
                return;
            }
            else if (Cmd == "clear")
            {
                // Clear console,
                Console.Clear();
                return;
            }
            else if (Cmd == "echo") // Write something in console, if no args are given, shell will write empty line,
            {
                // Writes args on screen:

                int ArgsLen = Args.Length;

                if (ArgsLen == 0) Console.WriteLine();
                else if(ArgsLen == 1)
                {
                    Console.WriteLine(Args[0]);
                }
                else
                {
                    for (int i = 0; i < ArgsLen; i++)
                    {
                        if (i != ArgsLen - 1) Console.Write(Args[i] + ' ');
                        else Console.Write(Args[i]);
                    }
                    Console.WriteLine();
                }

                return;
            }
            else if (Cmd == "cd")
            {
                // "cd" takes only one parameter and checks, if it exists in file system!
                if ((Args != null) && Directory.Exists(Args[0])) ShellPath = Args[0];
                else
                {
                    Console.WriteLine("Can't change directory, wrong argument!");
                    return;
                }
                Console.Title = ShellPath + " - Strayex Shell";
                return;
            }
            else if (Cmd == "help")
            {
                Console.WriteLine();
                Console.WriteLine("Strayex Shell Command list:");
                Console.WriteLine("- help - shows this list,");
                Console.WriteLine("- hello - make shell to say hello to you,");
                Console.WriteLine("- clear - clears consol's screen,");
                Console.WriteLine("- echo - write information on screen,");
                Console.WriteLine("- cd - changes active directory,");
                Console.WriteLine("- color - change colors of active shell session,");
                Console.WriteLine("- exit - close shell,");
                Console.WriteLine();
                return;
            }
            else if(Cmd == "color")
            {
                // Change colors of active shell session:

                if (Args[0] == "")
                {
                    Console.WriteLine("No arguments given! Type `color help` for info!");
                    return;
                }

                if(Args[0] == "help")
                {
                    Console.WriteLine("Strayex Shell Color Config");
                    Console.WriteLine("This command changes colors of terminal.");
                    Console.WriteLine("Use `color reset` to reload default terminal settings!");
                    Console.WriteLine("Available colors set:");
                    Console.WriteLine("- Background - Black, Blue, Green, White,");
                    Console.WriteLine("- Font - Black, Blue, Green, White,");
                    Console.WriteLine("Use `color <background> <font>` to change settings.");
                    Console.WriteLine("If you will provide one argument, Strayex Shell will interpret it as background color change!");
                    return;
                }
                else if(Args[0] == "reset")
                {
                    Console.ResetColor();
                    Console.WriteLine("Reset of color settings!");
                    return;
                }

                // If user wants rainbow in shell...
                if(Args[2] != "")
                {
                    Console.WriteLine("Too many colors given!");
                    return;
                }
                else if(Args[0] != "" && Args[1] != "")
                { // If background and font color are provided:
                    // Check background color:
                    switch (Args[0].ToLower())
                    {
                        case "black":
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                        case "blue":
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;

                        case "green":
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;

                        case "white":
                            Console.BackgroundColor = ConsoleColor.White;
                            break;

                        default:
                            Console.WriteLine("Can't determine color: " + Args[0]);
                            break;
                    }

                    // Check font color:
                    switch (Args[1].ToLower())
                    {
                        case "black":
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;

                        case "blue":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        case "green":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case "white":
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        default:
                            Console.WriteLine("Can't determine color: " + Args[0]);
                            break;
                    }
                }
                else if(Args[0] != "")
                { // Check background color only:
                    switch (Args[0].ToLower())
                    {
                        case "black":
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                        case "blue":
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;

                        case "green":
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;

                        case "white":
                            Console.BackgroundColor = ConsoleColor.White;
                            break;

                        default:
                            Console.WriteLine("Can't determine color: " + Args[0]);
                            break;
                    }
                }

                return;
            }
            else if (Cmd == "exit") Environment.Exit(0);
            else if (Cmd == "") return;

            // File to open in third-party app:
            if (DiscussFile(Cmd) == "text")
            {
                Process.Start("notepad.exe", ShellPath + '\\' + Cmd);
                return;
            }

            // Executable binaries:
            for(int i = 0; i < apps.Length; i++)
            {
                if (ShellPath + '\\' + Cmd == apps[i])
                {
                    // Start given process:

                    var apk = new Process();
                    apk.StartInfo.FileName = apps[i];

                    // If there's input, add it to process:
                    string Temp = "";
                    for (int j = 0; j < Args.Length; j++) Temp += Args[j];
                    apk.StartInfo.Arguments = Temp;

                    // Redirect streams to shell:
                    apk.StartInfo.RedirectStandardError = true;
                    apk.StartInfo.RedirectStandardInput = true;
                    apk.StartInfo.RedirectStandardOutput = true;
                    apk.StartInfo.UseShellExecute = false;

                    try
                    {
                        apk.Start();
                    }
                    catch (Exception a)
                    {
                        // If there's error, print it:
                        Console.WriteLine("Error trying execute given command: " + a.Message);
                        return;
                    }

                    apk.WaitForExit();

                    // If there's output, print it:
                    string output = apk.StandardOutput.ReadToEnd();
                    if (output != "") Console.Write(output);

                    return;
                }
            }

            // Write info if no command or program found:
            Console.WriteLine("Command or program not found!");
        }

        static void Main(string[] args)
        {
            Console.Title = ShellPath + " - Strayex Shell";
            // Standard shell's header:
            Console.WriteLine("Strayex Shell for Windows v1.0.0");
            Console.WriteLine("Copyright (c) 2019 Daniel Strayker Nowak");
            Console.WriteLine("All rights reserved");

            // Command routine:
            string temp = "";

            // While shell still execute:
            while(temp != "exit")
            {
                // Set title of window:
                Console.Title = ShellPath + " - Strayex Shell";
                // Write line for command input:
                Console.Write(ShellPath + "> ");
                // Wait for command:
                temp = Console.ReadLine();
                // Split args and command into array:
                string[] help = temp.Split(' ');
                // First element of array is always command name!
                Cmd = help[0];

                // Prepare args strings to add to shell:
                int b = 0;
                for (; b < 50; b++) Args[b] = "";

                for (int a = 1; a < help.Length; a++)
                {
                    Args[a - 1] = help[a];
                }

                // Interpret the command:
                CmdInterpreter();

                // Clear values of already executed command:
                Cmd = "";
                for (b = 0; b < 50; b++) Args[b] = "";
            }
        }
    }
}
