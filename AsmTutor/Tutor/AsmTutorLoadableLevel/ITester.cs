using System;
using System.Collections.Generic;

namespace Tutor
{
	namespace Levels
	{
		public interface ITester
		{
			List<TestResult> Test(String program);
		}
	}
}