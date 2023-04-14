using System;

namespace AS.Framework
{
	public interface IClickable
	{
		event Action OnClicked;

		void Click();
	}
}