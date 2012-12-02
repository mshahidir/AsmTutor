using System;
using System.IO;
using System.Reflection;
using Gtk;
using Tutor.Levels;

namespace Tutor
{
	namespace UserInterface
	{
		public partial class AsmTutorWindow: Gtk.Window
		{
			private Assembly levelAssembly = null;
			private LoadableLevel level = null;

			public AsmTutorWindow (): base (Gtk.WindowType.Toplevel)
			{
				Build ();
			}
	
			protected void OnDeleteEvent (object sender, DeleteEventArgs a)
			{
				Application.Quit ();
				a.RetVal = true;
			}

			protected void OnQuitButtonClicked (object sender, EventArgs e)
			{
				Application.Quit ();
			}

			protected void OnLoadButtonClicked (object sender, EventArgs e)
			{
				// Remove an already loaded level ui
				foreach (Gtk.Widget w in LevelContainer.AllChildren) {
					w.Destroy ();
				}
				// Reload levelAssembly from file everytime
				try
				{
					levelAssembly = Assembly.LoadFile ("../Levels/Level1.dll");
					level = (LoadableLevel)levelAssembly.CreateInstance ("TutorLevels.Level");
					Gtk.Widget a = level.BuildUi();
					LevelContainer.Child = a;
					a.Show();
				}
				catch (FileLoadException ex)
				{
					levelAssembly = null;
					level = null;
					LevelContainer.Child = new LoadErrorPane (ex.Message);
				}
				catch (FileNotFoundException ex)
				{
					levelAssembly = null;
					level = null;
					LevelContainer.Child = new LoadErrorPane(ex.Message);
				}
			}

			protected void OnStepButtonClicked (object sender, EventArgs e)
			{
				throw new System.NotImplementedException ();
			}

			protected void OnRestartButtonClicked (object sender, EventArgs e)
			{
				throw new System.NotImplementedException ();
			}

			protected void OnTestButtonClicked (object sender, EventArgs e)
			{
				throw new System.NotImplementedException ();
			}
		}
	}
}