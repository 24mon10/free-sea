using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
	[SerializeField] AudioSource[] audioSources;
	public enum Bgm
	{
		VILLAGE,
		WORLD,
		BATTLE,
	}

	Bgm currentBgm;

	public void Play(Bgm bgm)
	{
		audioSources[(int)currentBgm].Stop();
		audioSources[(int)bgm].Play();
		currentBgm = bgm;
	}

	//public void PlayAudio(Audio au)
	//{
	//	switch (audioEnum)
	//	{
	//		case Audio.VILLAGE:
	//			audioSources[0].Play();
	//			break;
	//		case Audio.WORLD: 
	//			audioSources[1].Play();
	//			break;
	//		case Audio.BATTLE:
	//			audioSources[2].Play();
	//			break;
	//	}
	//}
}
