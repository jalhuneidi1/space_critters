using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugSpawner : MonoBehaviour
{
    public GameObject bugPrefab;
    public List<GameObject> spawnLocations;


    // Start is called before the first frame update
    void Start()
    {
        SpawnBugs();
    }

    // Update is called once per frame
    void SpawnBugs()
    {
        for(int i = 0; i < spawnLocations.Count; i++)
        {
            Instantiate(bugPrefab, spawnLocations[i].transform.position, Quaternion.identity);
        }
    }
}
