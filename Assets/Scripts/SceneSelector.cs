using UnityEngine;
using System.Collections;

public class SceneSelector : MonoBehaviour
{

    private SceneCaretaker m_caretaker = null;
    void Start()
    {
        m_caretaker = gameObject.GetComponent<GameManager>().GetSceneCaretaker();
    }

	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneMemento sm = m_caretaker.ApplyScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(sm.GetNamme());

        }
	}
}
