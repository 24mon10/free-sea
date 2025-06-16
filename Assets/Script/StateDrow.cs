using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class StateDrow : MonoBehaviour
{
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
		DataService ds = new DataService("RPG.db");
		PlayerData playerData = ds.GetPlayerData(5);
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
}
