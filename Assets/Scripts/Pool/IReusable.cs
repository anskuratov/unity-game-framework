namespace AS.Framework
{
	public interface IReusable
	{
		void Prepare();
		void Release();
	}
}