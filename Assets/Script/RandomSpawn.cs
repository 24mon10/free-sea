using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
	[SerializeField] GameObject[] randomEnemy;
	[SerializeField] GameObject enemySpawnPos;
	// Start is called before the first frame update
	void Start()
    {
		
		
		int randomValue = Random.Range(0, 101);
		Debug.Log(randomValue);
		if (randomValue < 51) 
		{
			Instantiate(randomEnemy[0], enemySpawnPos.transform.position, enemySpawnPos.transform.rotation);
			
		}
		else if(randomValue < 71)
		{
			Instantiate(randomEnemy[1], enemySpawnPos.transform.position, enemySpawnPos.transform.rotation);
			
		}
		else
		{
			Instantiate(randomEnemy[2], enemySpawnPos.transform.position, enemySpawnPos.transform.rotation);
			
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
