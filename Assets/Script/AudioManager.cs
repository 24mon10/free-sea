using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	[SerializeField] AudioSource a_bgm;
	[SerializeField] AudioSource b_bgm;

	private string beforeScene;

	private void Start()
	{
		beforeScene = "VillageScene";
		a_bgm.Play();

		//ƒV[ƒ“‘JˆÚ‘JˆÚ‚µ‚½‚çBGM‚ğØ‚è‘Ö‚¦‚éˆ—
		SceneManager.activeSceneChanged += OnActiveSceneChange;
	}

	void OnActiveSceneChange(Scene prevScene, Scene nextScene)
	{
		if(beforeScene == "VillageScene" && nextScene.name == "WorldScene")
		{
			a_bgm.Stop();
			b_bgm.Play();
		}

		if (beforeScene == "WorldScene" && nextScene.name == "VillageScene")
		{
			a_bgm.Play();
			b_bgm.Stop();
		}

		if(beforeScene == "WorldScene" && nextScene.name == "BattleScene")
		{
			b_bgm.Stop();
		}
		
		if(beforeScene == "BattleScene" && nextScene.name == "WorldScene")
		{
			b_bgm.Play();
		}

			//‘JˆÚŒã‚ÌƒV[ƒ“‚ğ1‚Â‘O‚ÌƒV[ƒ“‚Æ‚µ‚Ä“o˜^
			beforeScene = nextScene.name;
	}
}
