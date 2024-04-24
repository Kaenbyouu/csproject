using UnityEngine;

public class BlackHoleSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject BlackHole_prefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(BlackHole_prefab, new Vector3(30, -3, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
