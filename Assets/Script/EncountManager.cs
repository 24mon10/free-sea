using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	[SerializeField]private GameObject player;
	private Player playerScript;
	AudioSource audioSource;
	public static string currentSceneName;
	private GameObject initScene;
	private InitScene initSceneScript;

	

	public static EncountManager Instance
	{
		get; private set;
	}

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		playerScript = player.GetComponent<Player>();
		SetDestinationTime();
		audioSource = GetComponent<AudioSource>();

		
    }

    // Update is called once per frame
    void Update()
    {
		currentSceneName = SceneChangeManager.currentSceneName;
		
		//���݂̃V�[����WorldScene����Ȃ�������v�����Ȃ�
		if (currentSceneName != "WorldScene")return;

		//�v���C���[�������Ă��Ȃ���Όv�����Ȃ�
		if (playerScript._inputMove == Vector2.zero) return;

		//�v���C���[����������̏�Ԃɕω����Ă�����v�����~�߂�
		if (playerScript.GetState() == Player.State.Talk
			|| playerScript.GetState() == Player.State.Menu) return;
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= destinationTime)
		{
			Debug.Log("����");
			SceneChangeManager.ChangeScene(sceneName);
			audioSource.Play();
			elapsedTime = 0.0f;
			SetDestinationTime();
		}
		
	}

	public void SetDestinationTime()
	{
		destinationTime = UnityEngine.Random.Range(encountMinTime, encountMaxTime);
	}

}
