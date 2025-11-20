
using System.Collections.ObjectModel;
using System.Management.Automation;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Management.Automation.Runspaces;
using Microsoft.SqlServer.Server;

namespace DorApplication
{
    internal class Program
    {



        static void Main(string[] args)
        {
            string filePath = "";
            string scriptPath = "";
            //Getting arguments
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if ((arg.StartsWith("-f") || arg.StartsWith("--file")) && i + 1 < args.Length)
                {
                    filePath = args[++i];
                    break;
                }
                else if ((arg.StartsWith("-s") || arg.StartsWith("--script")) && i + 1 < args.Length)
                {
                    scriptPath = args[++i];
                    break;
                }
            }

            // If no arguments print it
            if (args.Length == 0)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("  -f, --file     Specify the file path.");
                Console.WriteLine("  -s, --script   Specify the script path.");
                return;
            }

            //Switch for the options:
            if (filePath != "")
            {
                if(!File.Exists(filePath))
                {
                    Console.WriteLine("The given file does not exists!");
                    return;
                }
                Console.WriteLine("File path: " + filePath);
                PowerShell ps = PowerShell.Create();
                string[] scriptLines = File.ReadAllLines(filePath);
                ps.AddScript("Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force");

                foreach (string line in scriptLines)
                {
                    ps.Commands.Clear();
                    ps.AddScript(line + " | Out-String");
                    Collection<PSObject> results = ps.Invoke();
                    string output = string.Join(Environment.NewLine, results);
                    if (!string.IsNullOrEmpty(output))
                    {
                        Console.WriteLine(output);
                    }
                }





            }

            else if (scriptPath != "")
            {
                Console.WriteLine("Script path: " + scriptPath);
                PowerShell ps = PowerShell.Create();

                ps.AddScript(scriptPath + " | Out-String");
                Collection<PSObject> results = ps.Invoke();
                if (results.Count > 0)
                {
                    string output = results[0].ToString();
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine("No output returned.");
                }
            }
            Console.WriteLine("Done!");

        }
    }
}
