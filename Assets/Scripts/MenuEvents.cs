using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuEvents : MonoBehaviour
{
   public void loadLevel (int index)
    {
        SceneManager.LoadScene(index);
    }
}
