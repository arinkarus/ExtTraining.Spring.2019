using No5.Solution.Visitors;
using System.Collections.Generic;

namespace No5.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var boldText = new BoldText { Text = "Bold text" };
            var hyperLink = new HyperLink { Text = "HyperLink", Url = "someurl.com" };
            var plainText = new PlainText { Text = "PlainText" };
            List<DocumentPart> parts = new List<DocumentPart>()
                { boldText, hyperLink, plainText };
            var document = new Document(new 
                List<DocumentPart>() { boldText, hyperLink, plainText });
            System.Console.WriteLine(document.ConvertTo(new PartConverterToHtml()));
            System.Console.WriteLine(document.ConvertTo(new PartConverterToLaTeX()));
            System.Console.WriteLine(document.ConvertTo(new PartConverterToPlainText()));
        }
    }
}
