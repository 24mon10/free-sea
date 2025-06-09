using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class MagicEffect
{
	//ƒJƒeƒSƒŠ
	[SerializeField] MagicCategory.Category category;
	//Œø‰Ê”ÍˆÍ
	[SerializeField] MagicTarget.Target target;
	//Œø‰Ê—Ê
	[SerializeField] int value;
}
