using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncountManager : MonoBehaviour
{
	[SerializeField] string sceneName;
	//敵と遭遇するランダム時間
	[SerializeField] float encountMinTime = 3.0f;
	[SerializeField] float encountMaxTime = 10.0f;
	//経過時間
	[SerializeField] float elapsedTime;
	//目的の時間
	[SerializeField] float destinationTime;

	[SerializeField]private GameObject player;
	private Player playerScript;
	AudioSource audioSource;
	public static string currentSceneName;

	[SerializeField] private Fade m_fade = null;
	[SerializeField]
	AudioManager.Bgm bmg;

	public static EncountManager Instance
	{
		get; private set;
	}

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		playerScript = player.GetComponent<Player>();
		SetDestinationTime();
		audioSource = GetComponent<AudioSource>();
		
	}

    // Update is called once per frame
    void Update()
    {
		currentSceneName = SceneChangeManager.currentSceneName;
		
		//現在のシーンがWorldSceneじゃなかったら計測しない
		if (currentSceneName != "WorldScene")return;

		//プレイヤーが動いていなければ計測しない
		if (playerScript._inputMove == Vector2.zero) return;

		//プレイヤーが何かしらの状態に変化していたら計測を止める
		if (playerScript.GetState() == Player.State.Talk
			|| playerScript.GetState() == Player.State.Menu) return;
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= destinationTime)
		{
			Action on_completed = () =>
			{
				SceneChangeManager.ChangeScene(sceneName);
				m_fade.FadeIn(2.0f);
			};
			GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().Play(bmg);
			m_fade.FadeOut(2.0f ,on_completed );
			Debug.Log("遭遇");
			elapsedTime = 0.0f;
			SetDestinationTime();
		}
		
	}

	public void SetDestinationTime()
	{
		destinationTime = UnityEngine.Random.Range(encountMinTime, encountMaxTime);
	}

}
