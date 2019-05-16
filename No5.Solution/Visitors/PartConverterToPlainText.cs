using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution.Visitors
{
    public class PartConverterToPlainText: PartConverter
    {
        protected override string Visit(PlainText text) => text.Text;

        protected override string Visit(HyperLink link) => link.Text + " [" + link.Url + "]";

        protected override string Visit(BoldText text) => "**" + text.Text + "**";
    }
}
