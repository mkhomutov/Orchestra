using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules.JuliaEditor.Helpers
{
    using ICSharpCode.AvalonEdit.Highlighting;
    using ICSharpCode.AvalonEdit.Highlighting.Xshd;

    public class HighlightingHelper : IHighlightingDefinition
    {

        public HighlightingHelper()
        {            
            var ruleset = new HighlightingRuleSet();
            ruleset.Rules.Add(new HighlightingRule(){Color = new HighlightingColor(){}});
        }

        public HighlightingColor GetNamedColor(string name)
        {
            throw new NotImplementedException();
        }

        public HighlightingRuleSet GetNamedRuleSet(string name)
        {
            throw new NotImplementedException();
        }

        public HighlightingRuleSet MainRuleSet
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<HighlightingColor> NamedHighlightingColors
        {
            get { throw new NotImplementedException(); }
        }
    }
}
