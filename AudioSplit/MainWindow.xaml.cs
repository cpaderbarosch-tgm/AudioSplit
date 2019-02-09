using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

namespace AudioSplit
{
	public partial class MainWindow : Window
	{
		private LoopbackRecorder lr = new LoopbackRecorder();
		private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\test.wav";

		public MainWindow()
		{
			// UI
			InitializeComponent();
			this.Hide();

			// Key Handling
			//HandleKeyPress();

			Console.Read();
		}

		private void HandleKeyPress()
		{
			new Thread(() =>
			{
				ConsoleKeyInfo keyinfo;
				for (;;)
				{
					keyinfo = Console.ReadKey();
					if (keyinfo.Key == ConsoleKey.Spacebar)
					{
						if (!lr.IsRecording)
						{
							Console.WriteLine("Started recording");
							lr.StartRecording(path);
						}
						else
						{
							Console.WriteLine("Stopped recording");
							lr.StopRecording();
						}
					}
					else if (keyinfo.Key == ConsoleKey.Enter)
					{
						var info = new ProcessStartInfo("cmd", @"/C ipconfig")
						{
							UseShellExecute = false
						};
						Process.Start(info).WaitForExit();
					}
				}
			}).Start();
		}
	}
}