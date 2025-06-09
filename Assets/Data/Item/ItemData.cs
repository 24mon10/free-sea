using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
	//�A�C�e����ID
	[SerializeField] int itemId;
	//���O
	[SerializeField] string itemName;
	//����
	[SerializeField] string itemDesc;
	//�J�e�S��
	[SerializeField] ItemCategory.Category itemCategory;
	//���ʗ�
	[SerializeField] int value;
	//�g�p�\��
	[SerializeField] int numberOfUse;
	//�U���̕␳
	[SerializeField] int strength;
	//�h��̕␳
	[SerializeField] int guard;
	//�f�����̕␳
	[SerializeField] int speed;
	//���i
	[SerializeField] int price;
}
