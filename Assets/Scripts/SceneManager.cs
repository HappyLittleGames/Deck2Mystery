using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_sceneObjects = null;
    private int m_objectIndex = 0;

    public virtual GameObject NextObject()
    {
        if (m_sceneObjects[m_objectIndex] !=null)
        {
            m_objectIndex++;
            return m_sceneObjects[m_objectIndex-1];
        }
        else
        {
            Debug.Log("returned null object from SceneManager");
            return null;
        }
    }

    public virtual GameObject ObjectAt(int index)
    {
        if (m_sceneObjects[index] != null)
        {
            return m_sceneObjects[m_objectIndex];
        }
        else
        {
            Debug.Log("returned null object from SceneManager");
            return null;
        }
    }

    public virtual void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("intro");
    }
}