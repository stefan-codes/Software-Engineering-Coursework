using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Logic;
using WpfApp.DataStructures;

namespace WpfApp.Logic
{
    public static class ReadFromFile
    {
        private static string error;
        private static string[] fileLines = { };
        private static int startingLine = 0;
        private static string line = "";

        public static bool Read(string filePath)
        {
            Console.WriteLine("Read from file entered");
            if (!LoadDataFromFile(filePath))
            {
                return false;
            }

            while(fileLines.Length > startingLine)
            {
                Console.WriteLine("while entered.");
                line = fileLines[startingLine];
                if (line.Equals("sms") || line.Equals("email") || line.Equals("tweet"))
                {
                    switch (line)
                    {
                        case "sms":
                            Console.WriteLine("Sms case entered");
                            ServiceController.NewMessage(AppOptions.MessageTypes.IndexOf(line), fileLines[startingLine + 1], fileLines[startingLine + 2]);
                            startingLine = startingLine + 3;
                            break;
                        case "email":
                            ServiceController.NewMessage(AppOptions.MessageTypes.IndexOf(line), fileLines[startingLine + 1], fileLines[startingLine + 2], Convert.ToBoolean(fileLines[startingLine + 3]), AppOptions.IncidentTypes.IndexOf(fileLines[startingLine + 4]), fileLines[startingLine + 5], fileLines[startingLine + 6]);
                            startingLine = startingLine + 7;
                            break;
                        case "tweet":
                            ServiceController.NewMessage(AppOptions.MessageTypes.IndexOf(line), fileLines[startingLine + 1], fileLines[startingLine + 2]);
                            startingLine = startingLine + 3;
                            break;
                    }
                } else
                {
                    startingLine++;
                }
            }

            System.Windows.MessageBox.Show("File complete!");
            return true;
        }

        private static bool LoadDataFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }

                fileLines = File.ReadAllLines(filePath);
            }
            catch (FileNotFoundException)
            {
                error = "File not found.";
                return false;
            }
            return true;
        }

        public static string Error
        {
            get { return error; }
        }
    }
}
