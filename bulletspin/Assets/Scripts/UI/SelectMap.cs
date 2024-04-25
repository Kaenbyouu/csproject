using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    public static int selectedMap;
    public int mapNo;
    

    public void OpenScene()
    {
        selectedMap = mapNo;
        SceneManager.LoadScene($"Map1");
    }
}
