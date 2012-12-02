using System;
using Gtk;

namespace Tutor
{
	namespace UserInterface
	{
		public partial class LoadErrorPane : Gtk.Bin
		{
			public LoadErrorPane (String reason)
			{
				this.Build ();
				ErrorPane.LabelProp = reason;
				this.Show();
			}
		}
	}
}

