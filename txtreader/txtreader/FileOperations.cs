using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txthandler
{
    internal static class FileOperations
    {
        // Method to read the file and display the content
        public static void ReadFile(string filePath)
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);

            string[] files = Directory.GetFiles(directoryPath);
            int i = 0;

            bool fileFound = false;
            while (i < files.Length)
            {
                if (Path.GetFileName(files[i]) == fileName)
                {
                    fileFound = true;
                    break;
                }
                i++;
            }

            if (fileFound)
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int j = 0; j < lines.Length; j++)
                {
                    Console.WriteLine(lines[j]);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        // Method to write content to the first empty line in the file and save the changes
        public static void WriteToEmptyLine(string filePath, string content)
        {
            // Read all lines into an array
            string[] lines = File.ReadAllLines(filePath);

            bool lineWritten = false; // Flag to check if the line has been written

            // Look for an empty line to overwrite
            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    lines[i] = content; // Write content to the first empty line
                    lineWritten = true;
                    break;
                }
            }

            // If no empty line was found, add the content at the end of the file
            if (!lineWritten)
            {
                // Add a new line with the content
                Array.Resize(ref lines, lines.Length + 1);
                lines[^1] = content;
            }

            // Write the updated lines back to the file and save the changes
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Content written and saved to the file.");
        }
    }
}
