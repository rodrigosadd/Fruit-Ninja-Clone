using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform [] spawnPoints;
    public float timeToSpawn;
    private float _countdown;

    void Update()
    {
        CountdownToSpawn();
    }

    void CountdownToSpawn()
    {
        if(!GameManager.instance.isEndGame)
        {
            if(_countdown < 1)
            {   
                _countdown += Time.deltaTime / timeToSpawn;
            }   
            else
            {
                _countdown = 0;
                int indexSpanwPoint = Random.Range(0, spawnPoints.Length);
                float percentageChance = Random.Range(0f, 1f);

                if(percentageChance < 0.3f)
                {
                    Transform spawnPoint = spawnPoints[indexSpanwPoint]; 
                    Bomb bomb = GameManager.GetPool().TryToGetBomb();
                    bomb.rbody.velocity = Vector3.zero;
                    bomb.transform.position = spawnPoint.position;
                    bomb.transform.rotation = spawnPoint.rotation;
                    bomb.rbody.AddForce(bomb.transform.up * bomb.impulseForce, ForceMode.Impulse);                                    
                }
                else
                {
                    Transform spawnPoint = spawnPoints[indexSpanwPoint]; 
                    Fruit fruit = GameManager.GetPool().TryToGetFruit();
                    fruit.rbody.velocity = Vector3.zero;
                    fruit.transform.position = spawnPoint.position;
                    fruit.transform.rotation = spawnPoint.rotation;
                    fruit.rbody.AddForce(fruit.transform.up * fruit.impulseForce, ForceMode.Impulse);
                }
            }
        }
    }
}
