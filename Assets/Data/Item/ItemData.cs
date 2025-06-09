using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
	//アイテムのID
	[SerializeField] int itemId;
	//名前
	[SerializeField] string itemName;
	//説明
	[SerializeField] string itemDesc;
	//カテゴリ
	[SerializeField] ItemCategory.Category itemCategory;
	//効果量
	[SerializeField] int value;
	//使用可能回数
	[SerializeField] int numberOfUse;
	//攻撃の補正
	[SerializeField] int strength;
	//防御の補正
	[SerializeField] int guard;
	//素早さの補正
	[SerializeField] int speed;
	//価格
	[SerializeField] int price;
}
