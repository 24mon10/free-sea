using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using static Cinemachine.DocumentationSortingAttribute;

public class StateDrow : MonoBehaviour
{
	[SerializeField] Player player;
	[SerializeField] TextMeshProUGUI levelText;
	[SerializeField] TextMeshProUGUI n_expText;
	[SerializeField] TextMeshProUGUI hpText;
	[SerializeField] TextMeshProUGUI mpText;
	[SerializeField] TextMeshProUGUI strengthText;
	[SerializeField] TextMeshProUGUI guardText;
	[SerializeField] TextMeshProUGUI speedText;

    // Start is called before the first frame update
    void Start()
	{ 
		player.GetComponent<Player>();
		
		DataService ds = new DataService("RPG.db");
		PlayerData playerData = ds.GetPlayerData(1);
		levelText.text += playerData.level;
		n_expText.text += playerData.n_exp;
		hpText.text += playerData.hp;
		mpText.text += playerData.mp;
		strengthText.text += playerData.strength;
		guardText.text += playerData.guard;
		speedText.text += playerData.speed;
	}

    // Update is called once per frame
    void Update()
    {
	}
	
	public void NextLevelDraw()
	{
		
		Debug.Log(player.pLevel);
		DataService ds = new DataService("RPG.db");
		
		PlayerData playerData = ds.GetPlayerData(player.pLevel);
		
		levelText.text += playerData.level;
		n_expText.text += playerData.n_exp.ToString();
		hpText.text += playerData.hp.ToString();
		mpText.text += playerData.mp.ToString();
		strengthText.text += playerData.strength.ToString();
		guardText.text += playerData.guard.ToString();
		speedText.text += playerData.speed.ToString();
	}
}
