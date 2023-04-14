namespace AS.Framework
{
	public interface IUpdater
	{
		void Add(IUpdatable updatable);
		void Remove(IUpdatable updatable);
	}
}