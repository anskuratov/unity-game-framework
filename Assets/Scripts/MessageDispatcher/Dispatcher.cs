using System.Collections.Generic;

namespace AS.Framework
{
	public sealed class Dispatcher<TMessage> : IDispatcher<TMessage>
		where TMessage : struct
	{
		private readonly List<IListener<TMessage>> _listeners;

		public Dispatcher()
		{
			_listeners = new List<IListener<TMessage>>();
		}

		public void AddListener(IListener<TMessage> listener)
		{
			if (_listeners.Contains(listener) == false)
			{
				_listeners.Add(listener);
			}
		}

		public void RemoveListener(IListener<TMessage> listener)
		{
			if (_listeners.Contains(listener))
			{
				_listeners.Remove(listener);
			}
		}

		public void Send(TMessage message)
		{
			foreach (var listener in _listeners)
			{
				listener?.Handle(message);
			}
		}
	}
}