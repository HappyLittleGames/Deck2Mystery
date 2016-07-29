using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     // finn denna varje scen
    private SceneManager m_sceneManager = null;

    // att gå om från början vid varje grej (dragning, städning, bäddning, moppning)
    // ingen SceneManager i event-scener.
    private int m_cabinIndex = 0;
    // man drar ett random gäng hytter, sedan är detta cabinAmount.
    private int m_cabinAmount;

    public void SetCabinAmount(int amount) { m_cabinAmount = amount; }
    public int GetCabinAmount() { return m_cabinAmount; }

    [SerializeField] private Queue<int> m_cabinQueue = new Queue<int>();
    public int GetCabinAt(int index) { int[] levelArr = m_cabinQueue.ToArray(); return levelArr[index]; }

    void OnLevelWasLoaded(int level)
    {  
        if (m_sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>())
        {
            // make memento pattern out of thissss

            Debug.Log("SceneManager connected, queued scene " + level);
            m_cabinQueue.Enqueue(level);
            if (m_cabinIndex != 0)
                m_cabinIndex--;
        }
        else
        {
            Debug.Log("No SceneManager found");
        } 
    }


    public void NextItem()
    {
        m_sceneManager.NextObject();
    }

}