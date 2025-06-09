using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpTable",menuName = "Scriptable Object/ExpTable")]
public class ExpTable : ScriptableObject
{
	//経験値とレベルの対応レコードのリスト
	public List<ExpRecord> expRecords;
}
