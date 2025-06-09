using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object/EnemyData")]
public class EnemyData :ScriptableObject
{
	//敵のID
	[SerializeField] int enemyId;
	//名前
	[SerializeField] string enemyName;
	//敵のオブジェクト
	[SerializeField] GameObject enemyObj;
	//体力
	[SerializeField] int hp;
	//力
	[SerializeField] int strength;
	//守り
	[SerializeField] int guard;
	//素早さ
	[SerializeField] int speed;
	//経験値
	[SerializeField] int exp;
	//金
	[SerializeField] int gold;


}
