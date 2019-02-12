using System;

namespace Uno.Sample.ControlLibrary.Wasm
{
	public class Program
	{
		private static SampleApp.App _app;

		static void Main(string[] args)
		{
            Windows.UI.Xaml.Application.Start(_ => _app = new SampleApp.App()); 
		}
	}
}
