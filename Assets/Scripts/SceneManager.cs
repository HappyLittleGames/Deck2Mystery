﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private GameObject m_currentlyHolding = null;
    [SerializeField] private GameObject[] m_sceneObjects = null;
    private int m_objectIndex = 0;
    public bool m_isCabin = true;

    public virtual GameObject NextObject()
    {
        if (m_sceneObjects[m_objectIndex] != null)
        {
            m_objectIndex++;
            return m_sceneObjects[m_objectIndex - 1];
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


    public void SetHolding(GameObject thing)
    {
        m_currentlyHolding = thing;
        Debug.Log("Grabbed a " + thing.tag);
    }

    public void ReleaseHolding()
    {
        m_currentlyHolding = null;
    }

    public GameObject GetHolding()
    {
        if (m_currentlyHolding != null)
        {
            return m_currentlyHolding;
        }
        else
        {

            Debug.Log("Attempted to get a thing from nobody-s hands (GameManager)");
            return null;
        }
    }

    public NKI GetNki()
    {
        GameObject controller = null;
        if (controller = GameObject.FindGameObjectWithTag("FirstController"))
        {
            return controller.GetComponentInChildren<NKI>();
        }
        else
            return null;
    }

    public TimeTracker GetTimeTracker()
    {
        GameObject controller = null;
        if (controller = GameObject.FindGameObjectWithTag("FirstController"))
        {
            return controller.GetComponentInChildren<TimeTracker>();
        }
        else
            return null;
    }

   public void DoubleCabinCount()
    {

        GameManager manager = GameObject.FindGameObjectWithTag("FirstController").GetComponent<GameManager>();
        manager.SetCabinCount((manager.GetCabinCount() * 2) - 1);
    }
}