namespace AS.Framework
{
	public struct LocaleChanged
	{
		public readonly Locale Value;

		public LocaleChanged(Locale value)
		{
			Value = value;
		}
	}
}