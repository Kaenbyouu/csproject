using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCOM_LocalPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().centerOfMass = transform.localPosition;
        Debug.Log($"Planet--{GetComponent<Rigidbody2D>().centerOfMass}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
