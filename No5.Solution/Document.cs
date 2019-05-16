using No5.Solution;
using No5.Solution.Visitors;
using System;
using System.Collections.Generic;
using System.Text;

namespace No5
{
    public class Document
    {
        private readonly List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }

            this.parts = new List<DocumentPart>(parts);
        }

        public string ConvertTo(PartConverter converter)
        {
            var stringBuilder = new StringBuilder();
            foreach(DocumentPart part in this.parts)
            {
                stringBuilder.Append(converter.DynamicVisit(part)); 
            }

            return stringBuilder.ToString();
        }
    }
}
