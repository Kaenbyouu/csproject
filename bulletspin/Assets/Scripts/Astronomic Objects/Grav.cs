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

    private float G = 6.674083f;
    private float massProduct;
    private Vector2 radius;
    private float forceMagnitude;
    private Vector2 gravVect;
    private Vector2 forceDir;

    void Awake()
    {
        thisRB = thisObject.GetComponent<Rigidbody2D>();
        attractedObjRB = attractedObj.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (thisRB == null || attractedObjRB == null)
        {
            return;
        }
        Debug.Log("notnull");
        FauxGrav(attractedObjRB);
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

        // Apply force to attracted object
        attractedObjRB.AddForce(gravVect, ForceMode2D.Force);
        Debug.Log("AddedVect");
    
    }


}
