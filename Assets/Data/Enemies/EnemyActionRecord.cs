using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyActionRecord
{
	//�J�e�S��
	[SerializeField] EnemyActionCategory.ActionCategory actionCategory;
	//�������X�g
	[SerializeField] List<EnemyConditionRecord> enemyConditionRecords;
	//�s�������@���������̑Ώۃf�[�^
	[Header("�s�������@���������̑Ώۖ��@�f�[�^���w�肵�܂��B"),SerializeField]
	MagicData magicData;
	//�s���̗D��x
	[Header("�s���̗D��x��0����100�܂ł̐����Ŏw�肵�܂��B���l�̑傫�������D�悳��܂��B"), SerializeField]
	int priority;
}
