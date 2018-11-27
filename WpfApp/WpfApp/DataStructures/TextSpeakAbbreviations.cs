using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace WpfApp.DataStructures
{
    /* Author: Stefan Hristov
     * Student Number: 40284739
     * Last Updated: 13/11/2018
     * 
     * Class "TextSpeakAbbreviations"
     * 
     * The purpose is to deal with the text speak abbreviations. Loading, printing etc.
     * The data is loaded in the memory in the form of a list of arrays.
     * Each array has element 0 as the abbreviation.
     * And element 1 as the meaning.
     * The delimeter is presumed to always be ','
     * 
     */
    public static class TextSpeakAbbreviations
    {
        private static List<Array> abbreviationsDictionary = new List<Array>();
        private static string filePath = @"C:\Users\stefa\Documents\Workspace\SoftwareEngineeringCW\textwords.csv";
        private static char delimeter = ',';

        // Load the data into memory
        public static void LoadFile()
        {
            string[] lines = null;
            string[] line = null;

            try
            {
                if(!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }

                lines = File.ReadAllLines(filePath);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File to text abbreviations not found.");
            }

            foreach(string pair in lines)
            {
                line = pair.Split(delimeter);
                abbreviationsDictionary.Add(line);
            }
        }

        public static List<Array> AbbreviationsDictionary
        {
            get { return abbreviationsDictionary; }
        }
        
    }
}