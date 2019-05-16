using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No4.Solution
{
    public abstract class BasicRandomFileGenerator
    {
        private string workingDirectory;
        private string fileExtension;

        public string WorkingDirectory
        {
            get
            {
                return this.workingDirectory;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Directory can't be null");
                }


                if (value == string.Empty)
                {
                    throw new ArgumentException("Directory string can't be empty");
                }

                this.workingDirectory = value;
            }
        }

        public string FileExtension
        {
            get { return this.fileExtension;  }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("File extension can't be null");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Directory string can't be empty");
                }

                this.fileExtension = value;
            }
        }

        public BasicRandomFileGenerator(string workingDirectory, string fileExtension)
        {
            this.WorkingDirectory = workingDirectory;
            this.FileExtension = fileExtension;
        }

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);
                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";
                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        protected abstract byte[] GenerateFileContent(int contentLength);
        protected abstract void WriteBytesToFile(string fileName, byte[] content);
    }
}
