using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicData", menuName = "Scriptable Object/MagicData")]
public class MagicData : ScriptableObject
{
	//ID
	[SerializeField] int magicId;
	//–¼‘O
	[SerializeField] string magicName;
	//à–¾
	[SerializeField] string magicDesc;
	//Á”ïMP
	[SerializeField] int cost;
	//Œø‰ÊƒŠƒXƒg
	public List<MagicEffect> magicEffects;
}
