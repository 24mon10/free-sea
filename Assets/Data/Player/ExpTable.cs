using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpTable",menuName = "Scriptable Object/ExpTable")]
public class ExpTable : ScriptableObject
{
	//�o���l�ƃ��x���̑Ή����R�[�h�̃��X�g
	public List<ExpRecord> expRecords;
}
