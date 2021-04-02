using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public GameObject enemyGroup;
    private bool isPlaying = true;

    public void OffSpawner()
    {
        isPlaying = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isPlaying)
        {
            int spawnPer = Random.Range(0, 1001);
            if (spawnPer < 1000)
            {
                Enemy e = Instantiate(enemy);

                float posY = Random.Range(-4.3f, 4.3f);
                int isLeftInstatiate = Random.Range(0, 2);

                if (isLeftInstatiate == 0)
                {
                    e.transform.position = new Vector3(-8.3f, posY, -1);
                    e.transform.rotation = new Quaternion(0, 0, 0, 0);
                    e.SetDirectionVector(1);
                }
                else
                {
                    e.transform.position = new Vector3(8.3f,posY,-1);
                    e.transform.rotation = new Quaternion(0, 0, 180, 0);
                    e.SetDirectionVector(-1);
                }
                e.transform.parent = enemyGroup.transform;
            }
        }
    }
}
