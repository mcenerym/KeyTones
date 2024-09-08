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

			using( NotifyIcon icon = new NotifyIcon() )
			{
				icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon( Application.ExecutablePath );
				icon.ContextMenuStrip = new ContextMenuStrip()
				{
					Items = { new ToolStripMenuItem( "Exit", null, Exit ) }
				};

				icon.Visible = true;
				Application.Run();
			}
		}

		static void Exit( object? sender, EventArgs e )
		{
			Application.Exit();
		}
	}
}