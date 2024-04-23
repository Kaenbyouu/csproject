using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGravity : MonoBehaviour
{
    public GameObject attractedObj;
    private float mass;
    Rigidbody2D AOrb;
    private float G = 6.674083E-2f;

    // Start is called before the first frame update
    void Start()
    {
        AOrb = attractedObj.GetComponent<Rigidbody2D>();
        mass = attractedObj.GetComponent<Rigidbody2D>().mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float r = (GetComponent<Rigidbody2D>().position - AOrb.position).magnitude;
        float resF = -G*(mass) / Mathf.Pow(r, 2);
        Vector3 Fg = (transform.position).normalized * resF;
        GetComponent<Rigidbody2D>().AddForce(Fg);
    }
}
