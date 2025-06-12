using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ExistingDBScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var ds = new DataService ("existing.db");
		//ds.CreateDB ();
		var items= ds.GetItems();
		ToConsole (items);

	}
	
	private void ToConsole(IEnumerable<Items> item){
		foreach (var items in item) {
			ToConsole(items.ToString());
		}
	}

	private void ToConsole(string msg){
		
		Debug.Log (msg);
	}

}
