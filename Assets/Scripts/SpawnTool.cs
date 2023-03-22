using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTool : MonoBehaviour
{
    public GameObject toolPrefab;
    public Transform spawnPoint;

    private void Update()
    {
        //pos = pos + spawnPoint.position * Time.deltaTime;
    }

    public void SpawnTools()
    {

        Instantiate(toolPrefab, spawnPoint.position, Quaternion.identity);

    }
}
