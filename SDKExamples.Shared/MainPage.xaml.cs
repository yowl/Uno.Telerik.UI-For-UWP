﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SDKExamples.UWP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public static Frame RootFrame;
		private ControlData[] _controls;
		private Example[] _examples;

//		public Windows.UI.Xaml.Controls.NavigationView NavigationView
//		{
//			get { return NavigationViewControl; }
//		}
//
		public MainPage()
		{
			this.InitializeComponent();

//			MainPage.RootFrame = rootFrame;

#if !NETFX_CORE
			this.TopAppBar = new CommandBar();
			this.Padding = new Thickness(0, 55, 0, 0);
#endif

            Source = new List<GridItem>
            {
                new GridItem("a"),
                new GridItem("b"),
            };
#if __WASM__
//			switch (Environment.GetEnvironmentVariable("UNO_BOOTSTRAP_MONO_RUNTIME_MODE"))
//			{
//				case "Interpreter":
//					UnoShell.AppEnvironmentMode = "Interpreted";
//					break;
//				case "FullAOT":
//					UnoShell.AppEnvironmentMode = "AOT";
//					break;
//				case "InterpreterAndAOT":
//					UnoShell.AppEnvironmentMode = "Mixed";
//					break;
//			}
#endif
        }

        public class GridItem
        {
            public GridItem(string v)
            {
                A = v;
            }

            public string A { get; }
        }


		public IEnumerable Source { get; set; }

		private async void LoadData()
		{
#if NETSTANDARD2_0 || __ANDROID__
			string Read()
			{
				if (GetType().Assembly.GetManifestResourceNames().First(a => a.EndsWith("Examples.xml")) is string res)
				{
					using (var stream = new StreamReader(GetType().Assembly.GetManifestResourceStream(res)))
					{
						return stream.ReadToEnd();
					}
				}

				return "";
			}

			var text = Read();

#elif !NETFX_CORE
			var text = File.ReadAllText("Data/Examples.xml");
#else
			var text = await Windows.Storage.PathIO.ReadTextAsync("ms-appx:///Data/Examples.xml");
#endif
			var doc = XDocument.Parse(text);
			_controls = this.GetControls(doc).ToArray();
			var dummyTextBlock = new TextBlock();

			for (var i = 0; i < _controls.Length; i++)
			{
				var controlData = _controls[i] as ControlData;
				var item = new Windows.UI.Xaml.Controls.NavigationViewItem()
				{
					Content = controlData.Name,
					DataContext = controlData
				};

				item.Icon = new FontIcon()
				{
					FontFamily = dummyTextBlock.FontFamily,
					Glyph = controlData.Name[0].ToString() + controlData.Name[1].ToString()
				};

//				NavigationViewControl.MenuItems.Add(item);
			}
		}

		private IEnumerable<ControlData> GetControls(XDocument doc)
		{

			return from control in doc.Descendants("Control")
				   select new ControlData
				   (
					   control.Attribute("Name").Value,
					   from example in control.Descendants("Example")
					   select new Example(example.Attribute("ClassName").Value, example.Attribute("DisplayName").Value)
					);
		}

		private void BackButtonClicked(object sender, RoutedEventArgs e)
		{
//			this.DataContext = MainPage.Source;
		}

		private void OnNavigationViewItemInvoked(Windows.UI.Xaml.Controls.NavigationView sender, Windows.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
		{

			for (var i = 0; i < _controls.Length; i++)
			{
				var controlData = _controls[i] as ControlData;
				if (controlData.Name == args.InvokedItem)
				{
					_examples = controlData.Examples.ToArray();
					break;
				}
			}

//			rootFrame.Navigate(typeof(SectionPage), _examples);
		}
	}
}
