using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSceneManager : MonoBehaviour
{
	[SerializeField] GameObject mainPlayer;
	[SerializeField] GameObject battlePlayer;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer.SetActive(true);
		battlePlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
