using System.Collections;
using UnityEngine;

namespace AS.Framework
{
	public class Coroutines : MonoBehaviour,
		ICoroutines
	{
		public Coroutine Run(IEnumerator routine)
		{
			return StartCoroutine(routine);
		}

		public void Stop(Coroutine coroutine)
		{
			StopCoroutine(coroutine);
		}
	}
}