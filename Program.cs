using System.Media;
using System.Runtime.InteropServices;

namespace KeyTones
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new KeyTonesApplicationContext() );
		}
	}

	public class KeyTonesApplicationContext : ApplicationContext
	{
		private NotifyIcon TrayIcon { get; set; } = new();
		private WMPLib.WindowsMediaPlayer wplayer = new();

		public KeyTonesApplicationContext()
        {
			TrayIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon( Application.ExecutablePath );
			TrayIcon.ContextMenuStrip = new ContextMenuStrip()
			{
				Items = {
					new ToolStripMenuItem( "Exit", null, Exit )
				}
			};

			TrayIcon.Visible = true;

			StartKeyListening();
		}

		private void StartKeyListening()
		{
			var keyListeningThread = new Thread( new ThreadStart( ListenForKey ) );
			keyListeningThread.Start();
		}

		private void PlaySound()
		{
			var soundsDirectory = $@"{AppDomain.CurrentDomain.BaseDirectory}\sounds";
			wplayer.URL = $"{soundsDirectory}/blockturn.mp3";
			wplayer.settings.volume = 5;
			wplayer.controls.play();
		}

		private void Exit( object? sender, EventArgs e )
		{
			Application.Exit();
		}

		[DllImport( "User32.dll" )]
		private static extern short GetAsyncKeyState( int vKey );

		private static readonly int VK_SNAPSHOT = 0x2C; //This is the print-screen key.

		private void ListenForKey()
		{
			while( true )
			{
				short keyState = GetAsyncKeyState( VK_SNAPSHOT );

				//Check if the MSB is set. If so, then the key is pressed.
				bool prntScrnIsPressed = ( ( keyState >> 15 ) & 0x0001 ) == 0x0001;

				//Check if the LSB is set. If so, then the key was pressed since
				//the last call to GetAsyncKeyState
				bool unprocessedPress = ( ( keyState >> 0 )  & 0x0001 ) == 0x0001;

				if( prntScrnIsPressed )
				{
					PlaySound();
				}

				if( unprocessedPress )
				{
					PlaySound();
				}

				Thread.Sleep( 100 );
			}
		}
	}
}