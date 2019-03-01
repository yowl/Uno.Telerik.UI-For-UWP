using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Bindable]
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            try
            { 
                var x = new ResourceDictionary(); 
                this.InitializeComponent();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Items = Enumerable.Range(0, 10).Select(i => new RowItem(i, i.ToString())).ToList();
            DataContext = this;
        }

        public List<RowItem> Items { get; set; }

        [Bindable]
        public class RowItem
        {
            public int Ix { get; }
            public string Name { get; }

            public RowItem(int ix, string name)
            {
                Ix = ix;
                Name = name;
            }
        }

    }
}
