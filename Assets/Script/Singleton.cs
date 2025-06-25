using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
	static bool existInstance = false;

	private void Awake()
	{
		if(existInstance)
		{
			Destroy(gameObject);
			return;
		}

		existInstance = true;
		DontDestroyOnLoad(gameObject);
	}
}
