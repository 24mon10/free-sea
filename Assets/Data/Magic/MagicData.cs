using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicData", menuName = "Scriptable Object/MagicData")]
public class MagicData : ScriptableObject
{
	//ID
	[SerializeField] int magicId;
	//���O
	[SerializeField] string magicName;
	//����
	[SerializeField] string magicDesc;
	//����MP
	[SerializeField] int cost;
	//���ʃ��X�g
	public List<MagicEffect> magicEffects;
}
