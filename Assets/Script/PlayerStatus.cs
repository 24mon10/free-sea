using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

	[SerializeField] int level;
	[SerializeField] int n_exp;
	[SerializeField] int hp;
	[SerializeField] int mp;
	[SerializeField] int strength;
	[SerializeField] int guard;
	[SerializeField] int speed;
	private int h_Exp = 0;
	public int pLevel = 1;
	public int g_Exp;

	[SerializeField] StateDrow stateDrow;


	// Start is called before the first frame update
	void Start()
    {
		DataService ds = new DataService("RPG.db");
		PlayerData playerData = ds.GetPlayerData(pLevel);
		level = playerData.level;
		n_exp = playerData.n_exp;
		hp = playerData.hp;
		mp = playerData.mp;
		strength = playerData.strength;
		guard = playerData.guard;
		speed = playerData.speed;

		g_Exp = playerData.n_exp;
	}

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown(KeyCode.T))
		{
			if (pLevel == 5) return;
			h_Exp = 5;
			g_Exp -= h_Exp;
			stateDrow.ExpDraw();
			if (g_Exp == 0)
			{
				pLevel++;
				DataService ds = new DataService("RPG.db");
				PlayerData playerData = ds.GetPlayerData(pLevel);
				level = playerData.level;
				n_exp = playerData.n_exp;
				hp = playerData.hp;
				mp = playerData.mp;
				strength = playerData.strength;
				guard = playerData.guard;
				speed = playerData.speed;

				g_Exp = playerData.n_exp;
				h_Exp = 0;
				stateDrow.NextLevelDraw();
			}

		}

	}
}
