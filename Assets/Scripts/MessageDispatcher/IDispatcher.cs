namespace AS.Framework
{
	public interface IDispatcher<TMessage>
		where TMessage : struct
	{
		void AddListener(IListener<TMessage> listener);
		void RemoveListener(IListener<TMessage> listener);
	}
}