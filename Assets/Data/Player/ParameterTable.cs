using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParameterTable", menuName = "Scriptable Object/ParameterTable")]
public class ParameterTable : ScriptableObject
{
	//レベルとパラメーターの対応レコードリスト
	public List<ParameterRecord> parameterRecords;

}
