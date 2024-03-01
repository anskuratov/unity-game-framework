using System.Collections.Generic;
using System.IO;

namespace AS.Framework
{
	public class CsvFileParser : IFileParser<CsvData>
	{
		public bool TryParse(string pathToFile, out CsvData data)
		{
			var result = false;

			if (File.Exists(pathToFile))
			{
				using var reader = new StreamReader(pathToFile);

				var dataList = new List<string[]>();

				while (reader.EndOfStream == false)
				{
					var rowString = reader.ReadLine();
					var rowStringArray = rowString?.Split(';');
					dataList.Add(rowStringArray);
				}

				data = new CsvData(dataList);
				result = true;
			}
			else
			{
				data = default;
			}

			return result;
		}
	}
}