using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParameterTable", menuName = "Scriptable Object/ParameterTable")]
public class ParameterTable : ScriptableObject
{
	//���x���ƃp�����[�^�[�̑Ή����R�[�h���X�g
	public List<ParameterRecord> parameterRecords;

}
