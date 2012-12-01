using System;
using Gtk;

public partial class AsmTutorWindow: Gtk.Window
{	
	public AsmTutorWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
