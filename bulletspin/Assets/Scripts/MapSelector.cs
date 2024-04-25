using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapSelector : MonoBehaviour
{
    public static int selectedMap;
    public int mapNo;
    public Text mapDescription;

    void Start()
    {
        mapDescription.text = mapNo.ToString();
    }

    public void OpenScene()
    {
        selectedMap = mapNo;
        SceneManager.LoadScene($"Map{selectedMap}");
    }

}
