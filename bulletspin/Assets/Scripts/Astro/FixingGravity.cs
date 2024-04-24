using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixingGravity : MonoBehaviour
{
    public GameObject attractedObj_kind;
    private float G = 6.674083E-2f;
    private List<GameObject> allObj;

    // Start is called before the first frame update
    void Start()
    {
        allObj = GetClonesOfKind();
        foreach (GameObject clone in allObj)
        {
            Debug.Log("Found clone: " + clone.name);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject attractedObj_Instance in allObj)
        {
            Rigidbody2D AOrb;
            float mass;

            AOrb = attractedObj_Instance.GetComponent<Rigidbody2D>();
            mass = attractedObj_Instance.GetComponent<Rigidbody2D>().mass;
            //Debug.Log($"COM AT ORIGIN?????{AOrb.centerOfMass}: {attractedObj_Instance.transform.position}");

            float r = (AOrb.position - GetComponent<Rigidbody2D>().position ).magnitude;
            float resF = -G * (mass) / Mathf.Pow(r, 2);

            Vector3 Fg = transform.position + ((transform.position).normalized) * resF;

            GetComponent<Rigidbody2D>().AddForce(Fg);
            
        }

    }

    List<GameObject> GetClonesOfKind()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        List<GameObject> prefabClones = new List<GameObject>();

        foreach (GameObject obj in allObjects)
        {

            if (obj != null && obj.name.Substring(0, attractedObj_kind.name.Length) == attractedObj_kind.name)
            {
                prefabClones.Add(obj);
            }
        }
        return prefabClones;

    }

}
