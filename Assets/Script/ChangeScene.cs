using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	[SerializeField] public string sceneName;
	[SerializeField] public int posIndex;

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			SceneChangeManager.ChangeScene(sceneName);
			PlayerNextPosIndex.Index = posIndex;
		}
	}
}
