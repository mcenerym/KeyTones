﻿namespace KeyTones
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			notify_icon = new NotifyIcon( components );
			SuspendLayout();
			// 
			// notify_icon
			// 
			notify_icon.Text = "notifyIcon1";
			notify_icon.Visible = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF( 7F, 15F );
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size( 800, 450 );
			Name = "Form1";
			Text = "Form1";
			ResumeLayout( false );
		}

		#endregion

		private NotifyIcon notify_icon;
	}
}
