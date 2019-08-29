﻿using System.Collections.Generic;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SDKExamples.UWP.AutoCompleteBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Configurations : ExamplePageBase
    {
        public Configurations()
        {
            this.InitializeComponent();

            this.autoComplete.ItemsSource = new List<string>() {"Ivo", "Ivaylo", "Iva", "Yasen", "Yavor" };
        }
    }
}
