using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;
    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;

    [SerializeField]
    private Transform leftPos, rightPos;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }
    IEnumerator SpawnMonster() {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            //left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);

            }
            else if (randomSide == 1) 
                {
                    spawnedMonster.transform.position = rightPos.position;
                    spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10); //opposite direction
                    spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
        }
    }
