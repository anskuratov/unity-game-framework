namespace AS.Framework
{
	public interface IInitializable
	{
		void Init();
	}

	public interface IInitializable<TInitData>
		where TInitData : struct
	{
		void Init(TInitData initData);
	}
}