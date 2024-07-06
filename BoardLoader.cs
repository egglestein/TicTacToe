using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpliSafeTakeHomeAssesment
{
    public static class BoardLoader
    {
        public const string BOARD_FILENAME = "board_data.txt";

        public static BoardLoadParams LoadBoard()
        {
            return ReadBoardFromFile();
        }

        static BoardLoadParams ReadBoardFromFile()
        {
            BoardLoadParams newBoardLoadParams = new BoardLoadParams();

            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BOARD_FILENAME);
            if (!File.Exists(fileName))
            {
                throw new Exception("Stopping, no file detected. Please refer to README and create data file.");
            }

            using (TextFieldParser parser = new TextFieldParser(fileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                int lineCount = 0;
                while (!parser.EndOfData)
                {
                    try
                    {
                        string[] fields = parser.ReadFields();
                        newBoardLoadParams.cellInfo.Add(new List<int>());
                        for (int i = 0; i < fields.Length; i++)
                        {
                            string fieldInfo = fields[i];
                            int parsedValue = -1;
                            if (CheckInputValid(fieldInfo, out parsedValue))
                            {
                                newBoardLoadParams.cellInfo[lineCount].Add(parsedValue);
                            }
                            else
                            {
                                throw new Exception("Bad parse, stopping");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error reading file");
                        throw;
                    }
                    lineCount++;
                }
            }
            return newBoardLoadParams;

        }

        static bool CheckInputValid(string input, out int output)
        {
            int value = -1;
            try
            {
                value = Int32.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Error parsing character. Please input 0 for empty, 1 for X, or 2 for O");
                throw;
            }

            if (value != 0 &&
                value != 1 &&
                value != 2)
            {
                Console.WriteLine("Error parsing character. Please input 0 for empty, 1 for X, or 2 for O");
                output = -1;
                return false;
            }

            output = value;
            return true;
        }
    }
}
