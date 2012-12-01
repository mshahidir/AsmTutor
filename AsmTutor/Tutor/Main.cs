using System;
using Gtk;

namespace Tutor
{
	namespace UserInterface
	{
		class MainClass
		{
			public static void Main (string[] args)
			{
				Application.Init ();
				AsmTutorWindow win = new AsmTutorWindow ();
				win.Show ();
				Application.Run ();
			}
		}
	}
}