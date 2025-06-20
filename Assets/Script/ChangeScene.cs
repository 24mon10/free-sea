using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	[SerializeField] string sceneName;
	[SerializeField] GameObject player;
	[SerializeField] GameObject wPlayerPos;
	[SerializeField] GameObject bPlayerPos;
    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Initiate.Fade(sceneName, Color.black, 1.0f);
			if(sceneName == "WorldScene")
			{
				player.transform.position = wPlayerPos.transform.position;
				player.transform.rotation = wPlayerPos.transform.rotation;
			}
		}

	}
}
