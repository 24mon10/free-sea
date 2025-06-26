using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class BattlePlayer : MonoBehaviour
{

	[SerializeField] GameObject rio;
	Animator animator; // アニメーション

	[SerializeField] int level;
	[SerializeField] int n_exp;
	[SerializeField] int hp;
	[SerializeField] int mp;
	[SerializeField] int strength;
	[SerializeField] int guard;
	[SerializeField] int speed;

	private int h_Exp = 0;
	public int pLevel = 1;
	public int g_Exp;
	// Start is called before the first frame update
	void Start()
    {
		animator = rio.GetComponent<Animator>();
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
