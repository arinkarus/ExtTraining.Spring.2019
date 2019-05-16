using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution.Visitors
{
    public abstract class PartConverter
    {
        public string DynamicVisit(DocumentPart documentPart)
             => Visit((dynamic)documentPart);

        protected abstract string Visit(PlainText text);

        protected abstract string Visit(HyperLink link);

        protected abstract string Visit(BoldText text);
    }
}
