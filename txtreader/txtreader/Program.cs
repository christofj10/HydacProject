namespace txthandler
{
    internal class Program 
    { 
        static void Main(string[] args)
            {
            string filePath = @"C:\Users\chris\OneDrive\Dokumenter\checkin.txt";

            // Call the read method
            FileOperations.ReadFile(filePath);

            // Call the write method
            FileOperations.WriteToEmptyLine(filePath, "This is the new content.");
    }
}
}

