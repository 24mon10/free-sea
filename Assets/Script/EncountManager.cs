using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncountManager : MonoBehaviour
{
	[SerializeField] string sceneName;
	//�G�Ƒ������郉���_������
	[SerializeField] float encountMinTime = 3.0f;
	[SerializeField] float encountMaxTime = 10.0f;
	//�o�ߎ���
	[SerializeField] float elapsedTime;
	//�ړI�̎���
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
		//�v���C���[�������Ă��Ȃ���Όv�����Ȃ�
		if (player._inputMove == Vector2.zero) return;

		//�v���C���[����������̏�Ԃɕω����Ă�����v�����~�߂�
		if (player.GetState() == Player.State.Talk
			|| player.GetState() == Player.State.Menu
			|| player.GetState() == Player.State.Battle) return;
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= destinationTime)
		{
			Debug.Log("����");
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
