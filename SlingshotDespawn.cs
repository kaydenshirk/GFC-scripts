using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotDespawn : MonoBehaviour
{
    public GameObject SlingshotPrefab;
    private float StartDelay = 1;
    private float spawnInterval = 25.0f;
    private float spawnRangeZ = 20;

    void Start()
    {
        InvokeRepeating("SpawnSlingshot", StartDelay, spawnInterval); 
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }  

    void SpawnSlingshot()
    {
        Quaternion rotation = Quaternion.identity;
        Vector3 spawnPos = Vector3.zero;

        spawnPos = new Vector3(-1, 30, Random.Range(-spawnRangeZ, spawnRangeZ));

        Instantiate(SlingshotPrefab, spawnPos, rotation);
    }  
}
