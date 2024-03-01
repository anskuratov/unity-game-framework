using System;
using System.Collections.Generic;
using System.Text;
using AS.Framework.Utils;

namespace AS.Framework
{
	internal class LocalizationLoader
	{
		private readonly string PathToLocalizationFile =
			PathUtils.GetStreamingAssetsPath("localization.csv");

		public LocalizationData Data { get; private set; }

		private readonly IFileParser<CsvData> _fileParser;

		public LocalizationLoader()
		{
			_fileParser = new CsvFileParser();
		}

		public bool TryLoad()
		{
			var parseResult =  _fileParser.TryParse(PathToLocalizationFile, out var data);

			if (parseResult)
			{
				var locales = new List<Locale>();
				var keyValues = new Dictionary<string, Dictionary<Locale, string>>();
				var stringBuilder = new StringBuilder();

				var firstRow = data.Value[0];

				for (var i = 1; i < firstRow.Length; ++i)
				{
					var localeString = firstRow[i];
					localeString = localeString.ToLower();

					stringBuilder.Clear();
					stringBuilder.Append(localeString[0].ToString().ToUpper());
					stringBuilder.Append(localeString.Substring(1));

					localeString = stringBuilder.ToString();

					if (Enum.TryParse(localeString, out Locale locale) == false)
					{
						locale = Locale.Unknown;
					}

					locales.Add(locale);
				}

				for (var i = 1; i < data.Value.Count; ++i)
				{
					var localeToValue = new Dictionary<Locale, string>();
					keyValues.Add(data.Value[i][0], localeToValue);

					for (var k = 1; k < data.Value[i].Length; ++k)
					{
						// Удаляем символ = в начале фразы
						var value = data.Value[i][k];
						if (string.IsNullOrWhiteSpace(value) == false
						    && value[0] == '@')
						{
							value = value.Substring(1);
						}

						localeToValue.Add(locales[k - 1], value);
					}
				}

				Data = new LocalizationData(locales, keyValues);
			}

			return parseResult;
		}
	}
}