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

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player"
			&& col.GetComponent<Player>().GetState() != Player.State.Talk
			)
		{
			//　Playerが近づいたら会話相手として自分のゲームオブジェクトを渡す
			col.GetComponent<UnityChanTalkScript>().SetConversationPartner(transform.parent.gameObject);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player"
			&& col.GetComponent<Player>().GetState() != Player.State.Talk
			)
		{
			//　Playerが遠ざかったら会話相手から外す
			col.GetComponent<Player>().ResetConversationPartner(transform.parent.gameObject);
		}
	}
}
