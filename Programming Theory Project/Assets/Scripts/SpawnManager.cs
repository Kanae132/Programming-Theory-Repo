using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] eneSpawn;
    public GameObject[] powerSpawn;
    public GameManager gameManager;

    public float spawnX;
    public float negSpawnX;
    public float spawnY;
    public float spawnZ;
    private float delayTime = 1;
    private float eachTime = 0.5f;

    void Start()
    {
        EneSpawner();
        PowerSpawner();
    }

    void Update()
    {

    }

    void EneTopSpawn()
    {
        int spawnIndex = Random.Range(0, eneSpawn.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnX, negSpawnX), spawnY, spawnZ);
        Instantiate(eneSpawn[spawnIndex], spawnPos, eneSpawn[spawnIndex].transform.rotation);
    }

    void PowerTopSpawn()
    {
        int spawnIndex = Random.Range(0, powerSpawn.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnX, negSpawnX), spawnY, spawnZ);
        Instantiate(powerSpawn[spawnIndex], spawnPos, powerSpawn[spawnIndex].transform.rotation);
    }
    void EneSpawner()
    {
        InvokeRepeating("EneTopSpawn", delayTime, eachTime);
    }

    void PowerSpawner()
    {
        InvokeRepeating("PowerTopSpawn", delayTime + 10   , eachTime + 10  );
    }


}
