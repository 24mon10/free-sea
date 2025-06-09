using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object/EnemyData")]
public class EnemyData :ScriptableObject
{
	//�G��ID
	[SerializeField] int enemyId;
	//���O
	[SerializeField] string enemyName;
	//�G�̃I�u�W�F�N�g
	[SerializeField] GameObject enemyObj;
	//�̗�
	[SerializeField] int hp;
	//��
	[SerializeField] int strength;
	//���
	[SerializeField] int guard;
	//�f����
	[SerializeField] int speed;
	//�o���l
	[SerializeField] int exp;
	//��
	[SerializeField] int gold;


}
