using System.Collections.Generic;

namespace AS.Framework
{
	public class Localization : IMutableLocalization
	{
		private const string LocalizationError = "#ERROR#";

		public Dispatcher<LocaleChanged> LocaleChangedDispatcher { get; }

		public Locale Locale { get; private set; }
		public IReadOnlyList<Locale> Locales => _localizationLoader.Data.Locales;

		private readonly LocalizationLoader _localizationLoader;

		public Localization()
		{
			LocaleChangedDispatcher = new Dispatcher<LocaleChanged>();

			_localizationLoader = new LocalizationLoader();
		}

		public bool Init()
		{
			var result = _localizationLoader.TryLoad();
			SetLocale(_localizationLoader.Data.Locales[0]);
			return result;
		}

		public string Localize(string key)
		{
			var result = LocalizationError;

			if (_localizationLoader.Data.KeyValues.TryGetValue(key, out var localesValues)
			    && localesValues.TryGetValue(Locale, out var value))
			{
				result = value;
			}

			return result;
		}

		public bool HasKey(string key)
		{
			return _localizationLoader.Data.KeyValues.ContainsKey(key);
		}

		public void SetLocale(Locale locale)
		{
			Locale = locale;
			LocaleChangedDispatcher.Send(new LocaleChanged(Locale));
		}
	}
}