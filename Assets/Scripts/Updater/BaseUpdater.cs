using System.Collections.Generic;
using UnityEngine;

namespace AS.Framework
{
	public abstract class BaseUpdater : MonoBehaviour,
		IUpdater
	{
		protected readonly List<IUpdatable> updatables = new(4);

		public void Add(IUpdatable updatable)
		{
			if (updatables.Contains(updatable) == false)
			{
				updatables.Add(updatable);
			}
		}

		public void Remove(IUpdatable updatable)
		{
			if (updatables.Contains(updatable))
			{
				updatables.Remove(updatable);
			}
		}
	}
}