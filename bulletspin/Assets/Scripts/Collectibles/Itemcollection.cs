using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcollection : MonoBehaviour
{
    public void React(GameObject obj)
    {
        float boost = obj.GetComponent<Properties>().boosterFactor;
        Player player = GetComponent<Player>();
        GetComponent<Player>().Speed *= boost;
        StartCoroutine(timer(obj.GetComponent<Properties>().boosterTimer));
        player.Speed /= boost;
        Destroy(obj);
    }

    IEnumerator timer(float t)
    {
        yield return new WaitForSeconds(t);
    }

}
