using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcollection : MonoBehaviour
{
    float boost = 0;
    public void React(GameObject obj)
    {
        boost = obj.GetComponent<Properties>().boosterFactor;
        GetComponent<Player>();
        GetComponent<Player>().Speed *= boost;
        StartCoroutine(timer(obj.GetComponent<Properties>().boosterTimer));
        //player.Speed /= boost;
        Destroy(obj);
    }

    IEnumerator timer(float t)
    {
        yield return new WaitForSeconds(t);
        GetComponent<Player>().Speed /= boost;
    }

}
