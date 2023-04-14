namespace AS.Framework
{
	public interface IFactory<T>
	{
		T Create();
	}
}