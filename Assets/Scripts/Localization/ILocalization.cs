using System.Collections.Generic;

namespace AS.Framework
{
	public interface ILocalization
	{
		Dispatcher<LocaleChanged> LocaleChangedDispatcher { get; }

		public Locale Locale { get; }
		public IReadOnlyList<Locale> Locales { get; }

		string Localize(string key);
		bool HasKey(string key);
	}

	public interface IMutableLocalization : ILocalization
	{
		void SetLocale(Locale locale);
	}
}