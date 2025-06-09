using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ExpRecord
{
	//レベルの値
	[SerializeField] int level;

	//レベルに対する必要経験値
	[SerializeField] int exp;
}
