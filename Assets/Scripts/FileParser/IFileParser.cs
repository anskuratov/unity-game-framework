namespace AS.Framework
{
	public interface IFileParser<TData>
		where TData : struct
	{
		bool TryParse(string pathToFile, out TData data);
	}
}