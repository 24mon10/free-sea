using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	[SerializeField] public string sceneName;
	public string sceneManager;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(sceneName);
			SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
			SceneManager.LoadScene("SystemScene", LoadSceneMode.Additive);

			
		}

	}
}
