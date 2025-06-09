using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyConditionRecord : MonoBehaviour
{
	//�J�e�S��
	[SerializeField] ConditionCategory.Condition conditionCategory;

	//������r
	[SerializeField] ComparisonOperator.Conparison comparisonOparator;

	//�^�[�����̏����̒l
	[Header("�^�[�����̏�����0�ȏ�̐����Ŏw�肵�܂��B"),SerializeField]
	 int turnCriteria;

	//HP�̎c�ʏ����̒l
	[Header("HP�c�ʂ̊���������0����100�̊ԂŎw�肵�܂��B")]
	[Range(0, 100), SerializeField]
	float hpRateCriteria;

}
