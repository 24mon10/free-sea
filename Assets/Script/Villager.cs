using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
	public enum State
	{
		Wait,
		Talk
	}

	//　会話内容保持スクリプト
	[SerializeField]
	private Conversation conversation = null;
	//　村人の状態
	private State state;

	//　ユニティちゃんのTransform
	private Transform conversationPartnerTransform;
	//　村人がユニティちゃんの方向に回転するスピード
	[SerializeField]
	private float rotationSpeed = 2f;
	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{

		if (state == State.Talk)
		{
			//　村人がユニティちゃんの方向をある程度向くまで回転させる
			if (Vector3.Angle(transform.forward, new Vector3(conversationPartnerTransform.position.x, transform.position.y, conversationPartnerTransform.position.z) - transform.position) > 5f)
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(conversationPartnerTransform.position.x, transform.position.y, conversationPartnerTransform.position.z) - transform.position), rotationSpeed * Time.deltaTime);
				//animator.SetFloat("Speed", 1f);
			}
			else
			{
				//animator.SetFloat("Speed", 0f);
			}
		}
	}
	//　村人の状態変更
	public void SetState(State state,Transform conversationPartnerTransform = null)
	{
		this.state = state;
		if (state == State.Wait)
		{
		}else if (state == State.Talk)
		{
			this.conversationPartnerTransform = conversationPartnerTransform;
		}
	}

	//　Conversionスクリプトを返す
	public Conversation GetConversation()
	{
		return conversation;
	}

}
