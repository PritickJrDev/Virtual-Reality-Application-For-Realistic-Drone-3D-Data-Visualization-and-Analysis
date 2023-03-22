using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject item1Prefab;
    public GameObject item2Prefab;
  
    public Transform spawnPoint;

    public void SpawnItem1()
    {
       
            Instantiate(item1Prefab, spawnPoint.position, Quaternion.identity);
   
    }

    public void SpawnItem2()
    {

        Instantiate(item2Prefab, spawnPoint.position, Quaternion.identity);
        
    }

}
