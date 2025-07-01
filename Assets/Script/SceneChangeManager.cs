using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager
{
	static readonly string PlayerSceneName = "PlayerScene";

	public static string currentSceneName = "";

	static public void AddPlayerScene()
	{
		Debug.Log("AddPlayerScene");
		SceneManager.LoadScene(PlayerSceneName, LoadSceneMode.Additive);
	}

	static public void SubPlayerScene()
	{
		Debug.Log("SubPlayerScene");
		SceneManager.UnloadSceneAsync(PlayerSceneName);
	}

	static public void ChangeScene(string sceneName)
	{
		if(currentSceneName.Length > 0)
		{
			Debug.Log("UnloadSceneAsync:" + currentSceneName);
			SceneManager.UnloadSceneAsync(currentSceneName);
		}

		
		SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
		currentSceneName = sceneName;
		Debug.Log("LoadScene(Additive):" + currentSceneName);
	}
}
