using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class MagicEffect
{
	//�J�e�S��
	[SerializeField] MagicCategory.Category category;
	//���ʔ͈�
	[SerializeField] MagicTarget.Target target;
	//���ʗ�
	[SerializeField] int value;
}
