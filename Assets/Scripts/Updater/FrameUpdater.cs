using UnityEngine;

namespace AS.Framework
{
	public class FrameUpdater : BaseUpdater
	{
		public void Update()
		{
			foreach (var updatable in updatables)
			{
				updatable.Update(Time.deltaTime);
			}
		}
	}
}