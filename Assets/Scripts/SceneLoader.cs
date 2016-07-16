﻿using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public void LoadMess()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "fakeMess")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("fakeMess");
        }
    }

    public void LoadDass()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "dass")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("dass");
        }
    }

}
