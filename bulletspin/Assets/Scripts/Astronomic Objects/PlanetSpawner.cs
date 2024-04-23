using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Planet_prefab;
  


    void Start()
    {
        Instantiate(Planet_prefab, new Vector3(20,-2, 0), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
