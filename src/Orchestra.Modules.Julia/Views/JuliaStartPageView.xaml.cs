// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JuliaStartPageView.xaml.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.Julia.Views
{
    using Orchestra.Modules.Julia.Views.Interfaces;
    using Orchestra.Views;

    /// <summary>
    /// Логика взаимодействия для JuliaStartPage.xaml
    /// </summary>
    public partial class JuliaStartPageView : DocumentView, IJuliaStartPageView
    {
        #region Constructors
        public JuliaStartPageView()
        {
            InitializeComponent();
        }
        #endregion
    }
}