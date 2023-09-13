using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private Transform[] spawnPositions;
    private TimeManager timeManager;
    private float nextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime && timeManager.gameOver == false && timeManager.gameFinished == false)
        {
            // Sonraki çalýþma zamanýný güncelle
            nextSpawnTime += spawnRate;
            SpawnObject(objects[RandomObjectNumber()], spawnPositions[RandomSpawnNumber()]);
            
        }
    }
    private void SpawnObject (GameObject objectToSpawn, Transform newPositin)
    {
        Instantiate(objectToSpawn, newPositin.position,newPositin.rotation);
    }

    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }

    private int RandomObjectNumber()
    {
        return Random.Range(0,objects.Length);
    }
   
}
