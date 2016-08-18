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
    [SerializeField] private CabinCounter m_cabinCounter = null;
    private string m_lastHytt = "nothing";
    private SceneCaretaker m_sceneCaretaker = new SceneCaretaker();


    void OnLevelWasLoaded(int level)
    {  
        if (m_sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>())
        {
            // make memento pattern out of thissss
            if (m_sceneManager.m_isCabin)
            {
                Debug.Log("SceneManager connected, queued scene " + level);
                if (m_sceneManager.m_isCabin)
                {
                    Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                    m_sceneCaretaker.AddScene(new SceneMemento(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name));
                }

                m_cabinQueue.Enqueue(level);
                if (m_cabinIndex != 0)
                    m_cabinIndex--;
            }
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

    public SceneCaretaker GetSceneCaretaker()
    {
        return m_sceneCaretaker;
    }
    public string GetLastHytt()
    {
        return m_lastHytt;
    }
    public void SetLastHytt(string hytt)
    {
        m_lastHytt = hytt;
    }

    public void SetCabinCount(int amount)
    {
        if (m_cabinCounter != null)
        {
            m_cabinCounter.SetAmount(amount);
        }
    }
    public int GetCabinCount()
    {
        if (m_cabinCounter != null)
        {
            return m_cabinCounter.GetAmount();
        }
        else
            return 0;
    }
    public void LeaveCabin()
    {
        if (m_cabinCounter != null)
        {
            if (m_sceneManager.m_isCabin)
                m_cabinCounter.SetAmount(m_cabinCounter.GetAmount() - 1);

            if (m_cabinCounter.GetAmount() < 1)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("intro");
            }
        }
    }
}