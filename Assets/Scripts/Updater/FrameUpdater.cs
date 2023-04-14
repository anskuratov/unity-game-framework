using UnityEngine;

namespace AS.Framework
{
	public class FrameUpdater : BaseUpdater
	{
		public void Update()
		{
			foreach (var updatable in Updatables)
			{
				updatable.Update(Time.deltaTime);
			}
		}
	}
}