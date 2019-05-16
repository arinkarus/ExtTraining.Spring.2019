using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution.Visitors
{
    public class PartConverterToLaTeX: PartConverter
    {
        protected override string Visit(PlainText text) => text.Text;

        protected override string Visit(HyperLink link) => "\\href{" + link.Url + "}{" + link.Text + "}";

        protected override string Visit(BoldText text) => "\\textbf{" + text.Text + "}";
    }
}
