using System;
using System.Windows.Forms;

namespace Lab2
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new LighteningFilter());
			Application.Run (window);
		}
	}
}
