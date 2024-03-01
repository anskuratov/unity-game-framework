using System.Collections.Generic;

namespace AS.Framework
{
	public readonly struct CsvData
	{
		public readonly List<string[]> Value;

		public CsvData(List<string[]> value)
		{
			Value = value;
		}
	}
}