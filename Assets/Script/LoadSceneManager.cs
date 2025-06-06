using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
	private static LoadSceneManager loadSceneManager;
	//�V�[���ړ��Ɋւ���f�[�^�t�@�C��
	[SerializeField] SceneMovementData sceneMovementData = null;
	//�t�F�[�h�v���n�u
	[SerializeField] GameObject fadePrefab = null;
	//�t�F�[�h�C���X�^���X
	private GameObject fadeInstance;
	//�t�F�[�h�̉摜
	private Image fadePanel;

	[SerializeField] float fadeSpeed = 5f;

	private void Awake()
	{
		//LoadSceneManager�͏�ɂP�����ɂ���
		if(loadSceneManager == null)
		{
			loadSceneManager = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	//���̃V�[�����Ăяo��
	public void GotoNextScene(SceneMovementData.SceneType scene)
	{
		sceneMovementData.SetSceneType(scene);
		StartCoroutine(FadeAndLoadScene(scene));
	}

	//�t�F�[�h������ɃV�[����ǂݍ���
	IEnumerator FadeAndLoadScene(SceneMovementData.SceneType scene)
	{
		//�t�F�[�hUI�̃C���X�^���X��
		fadeInstance = Instantiate<GameObject>(fadePrefab);
		fadePanel = fadeInstance.GetComponentInChildren<Image>();
		//�t�F�[�h�A�E�g����
		yield return StartCoroutine(Fade(1f));

		//�V�[���̓ǂݍ���
		if(scene == SceneMovementData.SceneType.FirstVillage)
		{
			yield return StartCoroutine(LoadScene("VillageScene"));
		}
		else if(scene == SceneMovementData.SceneType.FirstVillageToWorldMap)
		{
			yield return StartCoroutine(LoadScene("WorldScene"));
		}

		//�t�F�[�hUI�̃C���X�^���X��
		fadeInstance = Instantiate<GameObject>(fadePrefab);
		fadePanel = fadeInstance.GetComponentInChildren<Image>();
		fadePanel.color = new Color(0f, 0f, 0f, 1f);

		//�t�F�[�h�C������
		yield return StartCoroutine(Fade(0f));

		Destroy(fadeInstance);
	}

	//�t�F�[�h����
	IEnumerator Fade(float alpha)
	{
		var fadePanelAlpha = fadePanel.color.a;
		
		while(Mathf.Abs(fadePanelAlpha = alpha) > 0.01f)
		{
			fadePanelAlpha = Mathf.Lerp(fadePanelAlpha, alpha, fadeSpeed * Time.deltaTime);
			fadePanel.color = new Color(0f, 0f, 0f, fadePanelAlpha);
			yield return null;
		}
	}

	//���ۂ̃V�[����ǂݍ��ݏ���
	IEnumerator LoadScene(string sceneName)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

		while(!async.isDone)
		{
			yield return null;
		}
	}

}
