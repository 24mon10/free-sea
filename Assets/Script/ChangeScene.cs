using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	[SerializeField] public string sceneName;
	[SerializeField] public int posIndex;
	[SerializeField] private GameObject m_fade;
	 private Fade fadeScript;

	private void Start()
	{
		m_fade = GameObject.Find("Canvas");
		fadeScript = m_fade.GetComponent<Fade>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Action on_completed = () =>
			{
				SceneChangeManager.ChangeScene(sceneName);
				PlayerNextPosIndex.Index = posIndex;
				fadeScript.FadeIn(1.0f);
			};

			fadeScript.FadeOut(1.0f, on_completed);
			
		}
	}
}
