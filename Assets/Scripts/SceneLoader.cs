using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{

    private GameManager m_manager = null;
    [SerializeField] private List<string> m_dragningsScenes;

    

    public void LoadLevel(string level)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != level)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(level);
        }
    }

    public void LoadMess()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "fakeMess")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("fakeMess");
        }
    }

    public void LoadDragning()
    {

    if (m_manager == null)
    {
        m_manager = GameObject.FindGameObjectWithTag("FirstController").GetComponent<GameManager>();
    }

    if (m_manager != null)
        {
            string level = m_dragningsScenes[Random.Range(0, m_dragningsScenes.Count)];
            while (level == m_manager.GetLastHytt())
            {
                level = m_dragningsScenes[Random.Range(0, m_dragningsScenes.Count - 1)];
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(level);
            m_manager.SetLastHytt(level);
        }
        else
            Debug.Log("failed to load because manager missing");
    }


}
