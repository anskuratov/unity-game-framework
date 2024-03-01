using System.Collections;
using UnityEngine;

namespace AS.Framework
{
	public interface ICoroutines
	{
		Coroutine Run(IEnumerator routine);
		void Stop(Coroutine coroutine);
	}
}