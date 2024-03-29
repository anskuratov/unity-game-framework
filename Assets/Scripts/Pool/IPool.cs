namespace AS.Framework
{
	public interface IPool<T>
		where T : IReusable
	{
		T Get();
		void Put(T reusable);
	}
}