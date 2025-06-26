using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
	[SerializeField]
	public string sceneName;

    void Awake()
    {
		SceneChangeManager.AddPlayerScene();
		SceneChangeManager.ChangeScene(sceneName);
    }
}
