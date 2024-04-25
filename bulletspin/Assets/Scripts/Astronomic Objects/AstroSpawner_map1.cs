using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Planet_prefab;

    [SerializeField]
    public GameObject BlackHole_prefab;

    [SerializeField]
    public GameObject coin;
    
    public List<GameObject> prefabBoosterList = new List<GameObject>();

    // for my level I want to have 100% control over the placement of the objects
    void Start()
    {
        Instantiate(BlackHole_prefab, new Vector3(-9.5f, -3f, 0f), Quaternion.identity);

        Instantiate(Planet_prefab, new Vector3(16f, 11f, 0f), Quaternion.identity);
        Instantiate(Planet_prefab, new Vector3(-31f, -13f, 0f), Quaternion.identity);
        Instantiate(coin, new Vector3(-7f, 11f, 0f), Quaternion.identity);
        Instantiate(coin, new Vector3(24f, -4f, 0f), Quaternion.identity);
        Instantiate(coin, new Vector3(24f, 4f, 0f), Quaternion.identity);
        Instantiate(coin, new Vector3(31f, 15f, 0f), Quaternion.identity);
        Instantiate(prefabBoosterList[0], new Vector3(15f, -11f, 0f), Quaternion.identity);
        Instantiate(prefabBoosterList[0], new Vector3(-14f, -17f, 0f), Quaternion.identity);
        Instantiate(prefabBoosterList[1], new Vector3(-29f, 10f, 0f), Quaternion.identity);
    }


}
