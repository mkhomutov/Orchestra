namespace Orchestra.Modules.TextEditor.Helpers
{
    using System;
    using System.Collections.Generic;

    using ICSharpCode.AvalonEdit.Highlighting;

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
