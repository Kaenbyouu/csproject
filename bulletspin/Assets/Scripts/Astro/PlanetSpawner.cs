using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Planet_prefab;
  


    void Start()
    {
        Instantiate(Planet_prefab, new Vector3(16,6, 0), Quaternion.identity);
        //Instantiate(Planet_prefab, new Vector3(-25, -12, 0), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
