using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSceneManager : MonoBehaviour
{
	[SerializeField] GameObject mainPlayer;
	[SerializeField] GameObject battlePlayer;

	private string nowScene;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer.SetActive(true);
		battlePlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		nowScene = EncountManager.currentSceneName;
		if (nowScene == "BattleScene")
		{
			mainPlayer.SetActive(false);
			battlePlayer.SetActive(true);
		}
		else
		{
			mainPlayer.SetActive(true);
			battlePlayer.SetActive(false);
		}
    }
}
