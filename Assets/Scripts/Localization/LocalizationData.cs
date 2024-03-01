using System.Collections.Generic;

namespace AS.Framework
{
	public readonly struct LocalizationData
	{
		public readonly List<Locale> Locales;
		public readonly Dictionary<string, Dictionary<Locale, string>> KeyValues;

		public LocalizationData(List<Locale> locales,
			Dictionary<string, Dictionary<Locale, string>> keyValues)
		{
			Locales = locales;
			KeyValues = keyValues;
		}
	}
}