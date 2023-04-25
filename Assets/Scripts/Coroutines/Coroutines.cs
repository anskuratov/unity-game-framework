using System.Collections;
using UnityEngine;

namespace AS.Framework
{
	public class Coroutines : MonoBehaviour,
		ICoroutines
	{
		public Coroutine Run(IEnumerator enumerator)
		{
			return StartCoroutine(enumerator);
		}

		public void Stop(Coroutine coroutine)
		{
			StopCoroutine(coroutine);
		}
	}
}