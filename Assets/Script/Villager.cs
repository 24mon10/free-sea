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

	//�@��b���e�ێ��X�N���v�g
	[SerializeField]
	private Conversation conversation = null;
	//�@���l�̏��
	private State state;

	//�@���j�e�B������Transform
	private Transform conversationPartnerTransform;
	//�@���l�����j�e�B�����̕����ɉ�]����X�s�[�h
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
			//�@���l�����j�e�B�����̕�����������x�����܂ŉ�]������
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
	//�@���l�̏�ԕύX
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

	//�@Conversion�X�N���v�g��Ԃ�
	public Conversation GetConversation()
	{
		return conversation;
	}

}
