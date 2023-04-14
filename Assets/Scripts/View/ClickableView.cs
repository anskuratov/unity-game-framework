using System;

namespace AS.Framework
{
	public abstract class ClickableView : View,
		IClickable
	{
		public event Action OnClicked;

		public void Click()
		{
			HandleClick();
			OnClicked?.Invoke();
		}

		protected virtual void HandleClick()
		{
		}
	}
}