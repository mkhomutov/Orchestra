// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorConfiguration.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models
{
    using System.Windows;
    using System.Windows.Media;

    public class TextEditorConfiguration 
    {
        public string Name { get; set; }

        public bool ReadOnly { get; set; }

        public bool WrapWords { get; set; }

        public bool ShowLinesNumber { get; set; }

        public int TabWidth { get; set; }

        public int IndentSize { get; set; }

        public bool ConvertTabToSpace { get; set; }

        public bool ShowSpaces { get; set; }

        public bool ShowTabs { get; set; }

        public bool ShowEndOfLine { get; set; }

        public FontStretch FontStretch { get; set; }

        public double FontSize { get; set; }

        public FontFamily FontFamily { get; set; }

        public FontStyle FontStyle { get; set; }

        public FontWeight FontWeight { get; set; }
    }
}