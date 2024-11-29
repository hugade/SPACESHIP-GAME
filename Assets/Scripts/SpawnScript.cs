using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnScript : MonoBehaviour
{
    public Transform limitUp1;

    public Transform limitUp2;

    public Transform limitL1;

    public Transform limitL2;

    public Transform limitDown1;

    public Transform limitDown2;

    public Transform limitR1;

    public Transform limitR2;

    public GameObject[] meteoritos;

    private Vector3[] SpawnPositions;

    private Vector3 spawnPosition1, spawnPosition2, spawnPosition3, spawnPosition4;

    public float timeSpawn;

    public float repeatSpawn;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteoritos", timeSpawn, repeatSpawn);

        cam =  Camera.main;

        /*SpawnPositions = new Vector3[4];

        SpawnPositions[0] = spawnPosition1;

        SpawnPositions[1] = spawnPosition2;

        SpawnPositions[2] = spawnPosition3;

        SpawnPositions[3] = spawnPosition4;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMeteoritos()
    {
        Vector3 spawnPosition = new Vector3 (0, 0, 0);

           spawnPosition = new Vector3 (Random.Range(limitL2.position.x, limitR2.position.x), Random.Range(limitDown2.position.y, limitUp2.position.y), 0);

        if (spawnPosition.x <= -17 || spawnPosition.x >= 17 || spawnPosition.y <= -10 || spawnPosition.y >= 10)
        {
            GameObject meteorito = Instantiate(meteoritos[Random.Range(0, meteoritos.Length)], spawnPosition, gameObject.transform.rotation);
        }
    }

    /*public void SpawnMeteoritos()
    {
        Vector3 spawnPosition1 = new Vector3 (0, 0, 0);

            spawnPosition1 = new Vector3(Random.Range(-20, -17), Random.Range(-13, 13), 0);

        Vector3 spawnPosition2 = new Vector3(0, 0, 0);

            spawnPosition2 = new Vector3(Random.Range(-20, 20), Random.Range(10, 13), 0);

        Vector3 spawnPosition3 = new Vector3(0, 0, 0);

            spawnPosition3 = new Vector3(Random.Range(17, 20), Random.Range(-13, 13), 0);

        Vector3 spawnPosition4 = new Vector3(0, 0, 0);

            spawnPosition4 = new Vector3(Random.Range(-20, 20), Random.Range(-13, -10), 0);

        GameObject meteorito = Instantiate(meteoritos[Random.Range(0, meteoritos.Length)], SpawnPositions[Random.Range(0, SpawnPositions.Length)], gameObject.transform.rotation);
    }*/


}
