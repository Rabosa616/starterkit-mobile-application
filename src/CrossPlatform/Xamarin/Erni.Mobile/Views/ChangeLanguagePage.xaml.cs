﻿using Erni.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Erni.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeLanguagePage
    {
        public ChangeLanguagePage()
        {
            InitializeComponent();
            BindingContext = new ChangeLanguageViewModel();
        }
    }
}