namespace AS.Framework
{
	public interface IListener<TMessage>
		where TMessage : struct
	{
		void Handle(TMessage message);
	}
}