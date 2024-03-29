using System;

namespace AS.Framework
{
	public interface IDraggable
	{
		event Action OnDragStarted;
		event Action OnDragEnded;
		event Action<IPointer> OnDragged;

		bool Disabled { get; }

		void StartDrag();
		void EndDrag();
		void Drag(IPointer pointer);
	}
}