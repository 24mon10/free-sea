using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
	DataService ds = new DataService("RPG.db");
	[SerializeField] int id;
	[SerializeField] string name;
	[SerializeField] int hp;
	[SerializeField] int mp;
	[SerializeField] int strength;
	[SerializeField] int guard;
	[SerializeField] int speed;
	[SerializeField] int expg;
	[SerializeField] int gold;
	// Start is called before the first frame update
	void Start()
    {
		Enemies enemies = ds.GetEnemiesData(1);
		id = enemies.id;
		name = enemies.name;
		hp = enemies.hp;
		mp = enemies.mp;
		strength = enemies.strength;
		guard = enemies.guard;
		speed = enemies.speed;
		expg = enemies.expg;
		gold = enemies.gold;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
