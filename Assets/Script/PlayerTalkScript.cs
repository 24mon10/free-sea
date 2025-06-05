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
	//��b�\�ȑ���
	private GameObject conversationPartner;
	//��b�\�A�C�R��
	[SerializeField]GameObject talkIcon = null;

	//TalkUI�Q�[���I�u�W�F�N�g
	[SerializeField] GameObject talkUI = null;
	//���b�Z�[�WUI
	private TextMeshProUGUI messageText = null;
	//�\�����郁�b�Z�[�W
	private string allMessage = null;
	//�g�p���镪��������
	[SerializeField] string splitString = "<>";
	//�����������b�Z�[�W
	private string[] splitMessage;
	//�����������b�Z�[�W�̉��Ԗڂ�
	private int messageNum;
	//�e�L�X�g�X�s�[�h
	[SerializeField] float textSpeed = 0.05f;
	//�o�ߎ���
	private float elapsedTime = 0f;
	//���Ă��镶���ԍ�
	private int nowTextNum = 0;
	//�{�^���̉����𑣂��A�C�R��
	[SerializeField]Image pushIcon = null;
	//�A�C�R���̓_�ŕb��
	[SerializeField] float pushFlashTime = 0.2f;
	//1�񕪂̃��b�Z�[�W���\�����ꂽ���ǂ���
	bool isOneMessage = false;
	//���b�Z�[�W��S�ĕ\���������ǂ���
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
		//�@���b�Z�[�W���I����Ă��邩�A���b�Z�[�W���Ȃ��ꍇ�͂���ȍ~�������Ȃ�
		if (isEndMessage || allMessage == null)return;

		//���ɕ\�����郁�b�Z�[�W��\�����Ă��Ȃ�
		if(!isOneMessage)
		{
			//�e�L�X�g�̕\�����Ԃ��o�߂����烁�b�Z�[�W��ǉ�
			if(elapsedTime >= textSpeed)
			{
				messageText.text += splitMessage[messageNum][nowTextNum];

				nowTextNum++;
				elapsedTime = 0f;

				//���b�Z�[�W��S���\���A�܂��͍s�����ő�\�����ꂽ
				if(nowTextNum >= splitMessage[messageNum].Length)
				{
					isOneMessage = true;
				}
			}
			elapsedTime += Time.deltaTime;


			if (player.Decision == true)
			{
				//�@�����܂łɕ\�����Ă���e�L�X�g�Ɏc��̃��b�Z�[�W�𑫂�
				messageText.text += splitMessage[messageNum].Substring(nowTextNum);
				isOneMessage = true;
				player.Decision = false;
			}
			//���ɕ\�����郁�b�Z�[�W��\������
		}
		else
		{
			elapsedTime += Time.deltaTime;

			//�v�b�V���A�C�R���̓_�Ŏ��Ԃ𒴂����ꍇ�A���]
			if(elapsedTime >= pushFlashTime)
			{
				pushIcon.enabled = !pushIcon.enabled;
				elapsedTime = 0f;
			}

			//�{�^���������ꂽ�玟�̕����\������
			if (player.Decision == true)
			{
				nowTextNum = 0;
				messageNum++;
				messageText.text = "";
				pushIcon.enabled = false;
				elapsedTime = 0f;
				isOneMessage= false;

				player.Decision = false;
				//���b�Z�[�W���S���\������Ă�����Q�[���I�u�W�F�N�g���̂̍폜
				if(messageNum >= splitMessage.Length)
				{
					EndTalking();
				}
			}
		}

	}
	private void LateUpdate()
	{
		//�@��b���肪����ꍇ��TalkIcon�̈ʒu����b����̓���ɕ\��
		if (conversationPartner != null)
		{
			talkIcon.transform.Find("Panel").position = Camera.main.GetComponent<Camera>().WorldToScreenPoint(conversationPartner.transform.position + Vector3.up * 2f);
		}
	}

	//�@��b�����ݒ�
	public void SetConversationPartner(GameObject partnerObj)
	{
		talkIcon.SetActive(true);
		conversationPartner = partnerObj;
		Debug.Log(conversationPartner);
	}

	//�@��b��������Z�b�g
	public void ResetConversationPartner(GameObject partnerObj)
	{
		//�@��b���肪���Ȃ��ꍇ�͉������Ȃ�
		if (conversationPartner == null)
		{
			return;
		}
		//�@��b����ƈ����Ŏ󂯎�������肪�����C���X�^���XID�����Ȃ��b������Ȃ���
		if (conversationPartner.GetInstanceID() == partnerObj.GetInstanceID())
		{
			talkIcon.SetActive(false);
			conversationPartner = null;
		}
	}
	//�@��b�����Ԃ�
	public GameObject GetConversationPartner()
	{
		return conversationPartner;
	}

	//��b���J�n����
	public void StartTalking()
	{
		var villager = conversationPartner.GetComponent<Villager>();
		villager.SetState(Villager.State.Talk, transform);
		this.allMessage = villager.GetConversation().GetConversationMessage();
		//����������ň��ɕ\�����郁�b�Z�[�W�𕪊�����
		splitMessage = Regex.Split(allMessage, @"\s*" + Regex.Escape(splitString) + @"\s*");
		//����������
		nowTextNum = 0;
		messageNum = 0;
		messageText.text = "";
		talkUI.SetActive(true);
		talkIcon.SetActive(false);
		isOneMessage = false;
		isEndMessage = false;
		//��b�J�n���̓��͈͂�U���Z�b�g
		Input.ResetInputAxes();
	}
	//�@��b���I������
	void EndTalking()
	{
		isEndMessage = true;
		talkUI.SetActive(false);
		//�@���j�e�B�����Ƒ��l�����̏�Ԃ�ύX����
		var villagerScript = conversationPartner.GetComponent<Villager>();
		villagerScript.SetState(Villager.State.Wait);
		GetComponent<Player>().SetState(Player.State.Normal);
	}
}
