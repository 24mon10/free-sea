using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CreateDBScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartSync();
	}

	private void StartSync()
	{
		var ds = new DataService("RPG.db");
		ds.CreateItemDB();
		ds.CreateMagicDB();
		ds.CreatePlayerDB();
		ds.CreateEnemiesDB();
	}
}
