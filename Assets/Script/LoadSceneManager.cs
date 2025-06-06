using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
	private static LoadSceneManager loadSceneManager;
	//シーン移動に関するデータファイル
	[SerializeField] SceneMovementData sceneMovementData = null;
	//フェードプレハブ
	[SerializeField] GameObject fadePrefab = null;
	//フェードインスタンス
	private GameObject fadeInstance;
	//フェードの画像
	private Image fadePanel;

	[SerializeField] float fadeSpeed = 5f;

	private void Awake()
	{
		//LoadSceneManagerは常に１つだけにする
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

	//次のシーンを呼び出す
	public void GotoNextScene(SceneMovementData.SceneType scene)
	{
		sceneMovementData.SetSceneType(scene);
		StartCoroutine(FadeAndLoadScene(scene));
	}

	//フェードした後にシーンを読み込み
	IEnumerator FadeAndLoadScene(SceneMovementData.SceneType scene)
	{
		//フェードUIのインスタンス化
		fadeInstance = Instantiate<GameObject>(fadePrefab);
		fadePanel = fadeInstance.GetComponentInChildren<Image>();
		//フェードアウト処理
		yield return StartCoroutine(Fade(1f));

		//シーンの読み込み
		if(scene == SceneMovementData.SceneType.FirstVillage)
		{
			yield return StartCoroutine(LoadScene("VillageScene"));
		}
		else if(scene == SceneMovementData.SceneType.FirstVillageToWorldMap)
		{
			yield return StartCoroutine(LoadScene("WorldScene"));
		}

		//フェードUIのインスタンス化
		fadeInstance = Instantiate<GameObject>(fadePrefab);
		fadePanel = fadeInstance.GetComponentInChildren<Image>();
		fadePanel.color = new Color(0f, 0f, 0f, 1f);

		//フェードイン処理
		yield return StartCoroutine(Fade(0f));

		Destroy(fadeInstance);
	}

	//フェード処理
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

	//実際のシーンを読み込み処理
	IEnumerator LoadScene(string sceneName)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

		while(!async.isDone)
		{
			yield return null;
		}
	}

}
