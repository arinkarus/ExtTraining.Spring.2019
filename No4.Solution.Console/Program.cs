namespace No4.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicRandomFileGenerator randomBytesFileGenerator = 
                new RandomBytesFileGenerator("Files with random bytes", ".bytes");
            BasicRandomFileGenerator randomCharsFileGenerator =
                new RandomCharsFileGenerator("Files with random chars", ".txt");
            randomBytesFileGenerator.GenerateFiles(10, 100);
            randomCharsFileGenerator.GenerateFiles(10, 100);
        }
    }
}
