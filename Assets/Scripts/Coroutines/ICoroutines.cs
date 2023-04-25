using System.Collections;
using UnityEngine;

namespace AS.Framework
{
	public interface ICoroutines
	{
		Coroutine Run(IEnumerator enumerator);
		void Stop(Coroutine coroutine);
	}
}