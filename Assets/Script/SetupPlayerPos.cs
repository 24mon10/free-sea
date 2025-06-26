using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayerPos : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> initPosList = new List<GameObject>();

	private void Start()
	{
		int index = PlayerNextPosIndex.Index;

		GameObject player = GameObject.FindWithTag("Player");
		player.GetComponent<CharacterController>().enabled = false;
		player.transform.position = initPosList[index].transform.position;
		player.transform.rotation = initPosList[index].transform.rotation;
		player.GetComponent<CharacterController>().enabled = true;

		Debug.Log("SetupPlayerPos:" + initPosList[index].transform.position);
	}
}
