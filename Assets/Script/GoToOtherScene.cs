using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToOtherScene : MonoBehaviour
{
	private LoadSceneManager sceneManager;
	//どのシーンへ遷移するか
	[SerializeField] SceneMovementData.SceneType scene = SceneMovementData.SceneType.FirstVillage;
	//シーン遷移中かどうか
	private bool isTransition;

	private void Awake()
	{
		sceneManager = FindObjectOfType<LoadSceneManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent<Player>(out var player) && !isTransition)
		{
			isTransition = true;
			sceneManager.GotoNextScene(scene);
		}
	}

}
