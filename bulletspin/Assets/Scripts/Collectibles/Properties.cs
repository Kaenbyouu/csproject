using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    [Header("Properties of Collectible Item")]
    [SerializeField]
    public float pts = 0f;
    [SerializeField]
    public bool booster;
    [SerializeField]
    public float boosterTimer = 0f;
    public float boosterFactor = 1.5f;

    void Start()
    {
        if (booster == true)
        {
            gameObject.tag = "booster";
        }
        else
        {
            gameObject.tag = "coin";
        }
    }
    public void selfDestruct()
    {
        Destroy(this);
    }
}
