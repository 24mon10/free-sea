using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor;
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
		DrawState();
	}

    // Update is called once per frame
    void Update()
    {
	}
	
	public void NextLevelDraw()
	{
		DrawState();
	}

	public void DrawState()
	{
		DataService ds = new DataService("RPG.db");
		PlayerData playerData = ds.GetPlayerData(player.pLevel);

		levelText.text = "Lv ." + playerData.level.ToString();
		n_expText.text = "NextEXP : " + playerData.n_exp.ToString() + " / " + playerData.n_exp.ToString();
		hpText.text = "HP : " + playerData.hp.ToString();
		mpText.text = "MP : " + playerData.mp.ToString();
		strengthText.text = "Strength : " + playerData.strength.ToString();
		guardText.text = "Guard : " + playerData.guard.ToString();
		speedText.text = "Speed : " + playerData.speed.ToString();
	}

	public void ExpDraw()
	{
		DataService ds = new DataService("RPG.db");
		PlayerData playerData = ds.GetPlayerData(player.pLevel);

		n_expText.text = "NextEXP : " + player.g_Exp + " / " + playerData.n_exp.ToString();
	}
}
