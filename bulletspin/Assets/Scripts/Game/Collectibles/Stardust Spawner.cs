using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject coin;
    public List<GameObject> prefabBoosterList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(coin, new Vector3(-19, -5, 0), Quaternion.identity);
        foreach (GameObject booster in prefabBoosterList)
        {
            float i = Random.Range(-13f,13f);
            float j = Random.Range(-31f, 30f);
           
            Instantiate(booster, new Vector3(j, i, 0), Quaternion.identity);
        }
    }
}
