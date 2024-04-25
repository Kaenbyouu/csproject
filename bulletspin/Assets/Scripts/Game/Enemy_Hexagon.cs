using UnityEngine;

public class Enemy_Hexagon : MonoBehaviour
{
    public GameObject EnemyPrefab;

    void Start()
    {
        Instantiate(EnemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
