using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyActionRecord
{
	//カテゴリ
	[SerializeField] EnemyActionCategory.ActionCategory actionCategory;
	//条件リスト
	[SerializeField] List<EnemyConditionRecord> enemyConditionRecords;
	//行動が魔法だった時の対象データ
	[Header("行動が魔法だった時の対象魔法データを指定します。"),SerializeField]
	MagicData magicData;
	//行動の優先度
	[Header("行動の優先度を0から100までの整数で指定します。数値の大きい方が優先されます。"), SerializeField]
	int priority;
}
