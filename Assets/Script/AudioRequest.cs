using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRequest : MonoBehaviour
{
	[SerializeField]
	AudioManager.Bgm bmg;

	private void Awake()
	{
		GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().Play(bmg);
	}
}
