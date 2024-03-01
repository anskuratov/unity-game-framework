using UnityEngine;

namespace AS.Framework
{
	public class FixedUpdater : BaseUpdater
	{
		public void FixedUpdate()
		{
			foreach (var updatable in updatables)
			{
				updatable.Update(Time.fixedDeltaTime);
			}
		}
	}
}