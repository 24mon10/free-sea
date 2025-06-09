using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyConditionRecord : MonoBehaviour
{
	//カテゴリ
	[SerializeField] ConditionCategory.Condition conditionCategory;

	//条件比較
	[SerializeField] ComparisonOperator.Conparison comparisonOparator;

	//ターン数の条件の値
	[Header("ターン数の条件を0以上の整数で指定します。"),SerializeField]
	 int turnCriteria;

	//HPの残量条件の値
	[Header("HP残量の割合を％で0から100の間で指定します。")]
	[Range(0, 100), SerializeField]
	float hpRateCriteria;

}
