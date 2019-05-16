using System;
using System.IO;

namespace No4.Solution
{
    public class RandomBytesFileGenerator: BasicRandomFileGenerator
    {
        public RandomBytesFileGenerator(string workingDirectory,
            string fileExtension) : base(workingDirectory, fileExtension)
        {
        }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();
            var fileContent = new byte[contentLength];
            random.NextBytes(fileContent);
            return fileContent;
        }

        protected override void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }
    }
}