using System;
using System.Collections.Generic;
using Tutor.Levels;
using Gtk;

namespace TutorLevels
{
	public class Level : LoadableLevel
	{
		private const String name = "Level1";
		private Gtk.Bin ui = null;

		public override List<TestResult> Test (string ans)
		{
			List<TestResult> result = new List<TestResult>();
			result.Add(new TestResult("Line 4", "The line doesn't exist"));
			return result;
		}

		public override Gtk.Widget BuildUi ()
		{
			ui = new LevelBox();
			ui.Show();
			return ui;
		}
	}
}