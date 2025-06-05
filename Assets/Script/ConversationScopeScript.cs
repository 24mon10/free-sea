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
			//�@Player���߂Â������b����Ƃ��Ď����̃Q�[���I�u�W�F�N�g��n��
			other.GetComponent<PlayerTalkScript>().SetConversationPartner(transform.parent.gameObject);
		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<Player>(out var player))
		{
			//�@Player���������������b���肩��O��
			other.GetComponent<PlayerTalkScript>().ResetConversationPartner(transform.parent.gameObject);
		}
	}
}
