using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerTalkScript : MonoBehaviour
{
	//会話可能な相手
	private GameObject conversationPartner;
	//会話可能アイコン
	[SerializeField]GameObject talkIcon = null;

	//TalkUIゲームオブジェクト
	[SerializeField] GameObject talkUI = null;
	//メッセージUI
	private TextMeshProUGUI messageText = null;
	//表示するメッセージ
	private string allMessage = null;
	//使用する分割文字列
	[SerializeField] string splitString = "<>";
	//分割したメッセージ
	private string[] splitMessage;
	//分割したメッセージの何番目か
	private int messageNum;
	//テキストスピード
	[SerializeField] float textSpeed = 0.05f;
	//経過時間
	private float elapsedTime = 0f;
	//見ている文字番号
	private int nowTextNum = 0;
	//ボタンの押下を促すアイコン
	[SerializeField]Image pushIcon = null;
	//アイコンの点滅秒数
	[SerializeField] float pushFlashTime = 0.2f;
	//1回分のメッセージが表示されたかどうか
	bool isOneMessage = false;
	//メッセージを全て表示したかどうか
	bool isEndMessage = false;

	[SerializeField]
	Player player;


	// Start is called before the first frame update
	void Start()
    {
		pushIcon.enabled = false;
		messageText = talkUI.GetComponentInChildren<TextMeshProUGUI>();
    }

	
    // Update is called once per frame
    void Update()
    {
		//　メッセージが終わっているか、メッセージがない場合はこれ以降何もしない
		if (isEndMessage || allMessage == null)return;

		//一回に表示するメッセージを表示していない
		if(!isOneMessage)
		{
			//テキストの表示時間を経過したらメッセージを追加
			if(elapsedTime >= textSpeed)
			{
				messageText.text += splitMessage[messageNum][nowTextNum];

				nowTextNum++;
				elapsedTime = 0f;

				//メッセージを全部表示、または行数が最大表示された
				if(nowTextNum >= splitMessage[messageNum].Length)
				{
					isOneMessage = true;
				}
			}
			elapsedTime += Time.deltaTime;


			if (player.Decision == true)
			{
				//　ここまでに表示しているテキストに残りのメッセージを足す
				messageText.text += splitMessage[messageNum].Substring(nowTextNum);
				isOneMessage = true;
				player.Decision = false;
			}
			//一回に表示するメッセージを表示した
		}
		else
		{
			elapsedTime += Time.deltaTime;

			//プッシュアイコンの点滅時間を超えた場合、反転
			if(elapsedTime >= pushFlashTime)
			{
				pushIcon.enabled = !pushIcon.enabled;
				elapsedTime = 0f;
			}

			//ボタンが押されたら次の文字表示処理
			if (player.Decision == true)
			{
				nowTextNum = 0;
				messageNum++;
				messageText.text = "";
				pushIcon.enabled = false;
				elapsedTime = 0f;
				isOneMessage= false;

				player.Decision = false;
				//メッセージが全部表示されていたらゲームオブジェクト自体の削除
				if(messageNum >= splitMessage.Length)
				{
					EndTalking();
				}
			}
		}

	}
	private void LateUpdate()
	{
		//　会話相手がいる場合はTalkIconの位置を会話相手の頭上に表示
		if (conversationPartner != null)
		{
			talkIcon.transform.Find("Panel").position = Camera.main.GetComponent<Camera>().WorldToScreenPoint(conversationPartner.transform.position + Vector3.up * 2f);
		}
	}

	//　会話相手を設定
	public void SetConversationPartner(GameObject partnerObj)
	{
		talkIcon.SetActive(true);
		conversationPartner = partnerObj;
		Debug.Log(conversationPartner);
	}

	//　会話相手をリセット
	public void ResetConversationPartner(GameObject partnerObj)
	{
		//　会話相手がいない場合は何もしない
		if (conversationPartner == null)
		{
			return;
		}
		//　会話相手と引数で受け取った相手が同じインスタンスIDを持つなら会話相手をなくす
		if (conversationPartner.GetInstanceID() == partnerObj.GetInstanceID())
		{
			talkIcon.SetActive(false);
			conversationPartner = null;
		}
	}
	//　会話相手を返す
	public GameObject GetConversationPartner()
	{
		return conversationPartner;
	}

	//会話を開始する
	public void StartTalking()
	{
		var villager = conversationPartner.GetComponent<Villager>();
		villager.SetState(Villager.State.Talk, transform);
		this.allMessage = villager.GetConversation().GetConversationMessage();
		//分割文字列で一回に表示するメッセージを分割する
		splitMessage = Regex.Split(allMessage, @"\s*" + Regex.Escape(splitString) + @"\s*");
		//初期化処理
		nowTextNum = 0;
		messageNum = 0;
		messageText.text = "";
		talkUI.SetActive(true);
		talkIcon.SetActive(false);
		isOneMessage = false;
		isEndMessage = false;
		//会話開始時の入力は一旦リセット
		Input.ResetInputAxes();
	}
	//　会話を終了する
	void EndTalking()
	{
		isEndMessage = true;
		talkUI.SetActive(false);
		//　ユニティちゃんと村人両方の状態を変更する
		var villagerScript = conversationPartner.GetComponent<Villager>();
		villagerScript.SetState(Villager.State.Wait);
		GetComponent<Player>().SetState(Player.State.Normal);
	}
}
