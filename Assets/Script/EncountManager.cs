using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	[SerializeField] Player player;
	AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
		SetDestinationTime();
		audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		//プレイヤーが動いていなければ計測しない
		if (player._inputMove == Vector2.zero) return;

		//プレイヤーが何かしらの状態に変化していたら計測を止める
		if (player.GetState() == Player.State.Talk
			|| player.GetState() == Player.State.Menu
			|| player.GetState() == Player.State.Battle) return;
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= destinationTime)
		{
			Debug.Log("遭遇");
			Initiate.Fade(sceneName, Color.black, 2.0f);
			audioSource.Play();
			player.SetState(Player.State.Battle);
			elapsedTime = 0.0f;
			SetDestinationTime();
		}
		
		DontDestroyOnLoad(gameObject);
	}
	public void SetDestinationTime()
	{
		destinationTime = Random.Range(encountMinTime, encountMaxTime);
	}
}
