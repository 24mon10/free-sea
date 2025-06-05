using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationScopeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<Player>(out var player))
		{
			//　Playerが近づいたら会話相手として自分のゲームオブジェクトを渡す
			other.GetComponent<PlayerTalkScript>().SetConversationPartner(transform.parent.gameObject);
		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<Player>(out var player))
		{
			//　Playerが遠ざかったら会話相手から外す
			other.GetComponent<PlayerTalkScript>().ResetConversationPartner(transform.parent.gameObject);
		}
	}
}
