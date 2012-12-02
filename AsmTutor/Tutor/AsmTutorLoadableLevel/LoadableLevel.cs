using System;
using System.Collections.Generic;
using Gtk;

namespace Tutor
{
	namespace Levels
	{
		public abstract partial class LoadableLevel : ITester
		{
			public abstract List<TestResult> Test(String ans);
			public abstract Gtk.Widget BuildUi();
		}
	}
}