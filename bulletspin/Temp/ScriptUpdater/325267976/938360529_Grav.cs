using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grav : MonoBehaviour
{
    [SerializeField]
    private GameObject attractedObj;
    [SerializeField]
    private GameObject thisObject;
    private Rigidbody2D thisRB;
    private Rigidbody2D attractedObjRB;

    private float G = 6.67408f;
    private float massProduct;
    private Vector3 radius;
    private float forceMagnitude;
    private Vector3 gravVect;
    private Vector3 forceDir;

    void Awake()
    {
        thisRB = thisObject.GetComponent<Rigidbody2D>();
        attractedObjRB = attractedObj.GetComponent<Rigidbody2D>();
    }

    public void FauxGrav(Rigidbody2D otherRB)
    { 
        massProduct = thisRB.mass * otherRB.mass;
        radius = thisRB.position - otherRB.position;

        if (radius.magnitude == 0)
        {
            return;
        }
        Debug.Log("Gravity");
        forceMagnitude = (G * massProduct) / Mathf.Pow(radius.magnitude, 2);
        forceDir = radius.normalized;
        gravVect = forceDir * forceMagnitude;
        Debug.Log($"Physics{forceMagnitude},{forceDir},{gravVect}");
        attractedObj.GetComponent<Rigidbody2D>().AddForce(gravVect, ForceMode.Impulse);
        //otherRB.AddForce(gravVect);
        Debug.Log(otherRB);
    }

    void Update()
    {
        if (thisRB == null || attractedObjRB == null)
        {
            return;
        }
        FauxGrav(attractedObjRB);
    }

}
