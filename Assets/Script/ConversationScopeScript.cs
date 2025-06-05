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
			Debug.Log("Player�ɂԂ�����");
			//�@Player���߂Â������b����Ƃ��Ď����̃Q�[���I�u�W�F�N�g��n��
			col.GetComponent<PlayerTalkScript>().SetConversationPartner(transform.parent.gameObject);
		}
	}


	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player"
			&& col.GetComponent<Player>().GetState() != Player.State.Talk
			)
		{
			//�@Player���������������b���肩��O��
			col.GetComponent<PlayerTalkScript>().ResetConversationPartner(transform.parent.gameObject);
		}
	}
}
