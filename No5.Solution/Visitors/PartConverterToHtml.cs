using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution.Visitors
{
    public class PartConverterToHtml: PartConverter
    {
        protected override string Visit(PlainText text) => text.Text;

        protected override string Visit(HyperLink link) => "<a href=\"" + link.Url + "\">" + link.Text + "</a>";

        protected override string Visit(BoldText text) => "<b>" + text.Text + "</b>";
    }
}

