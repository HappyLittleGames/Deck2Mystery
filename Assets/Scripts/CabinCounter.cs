using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CabinCounter : MonoBehaviour
{
    [SerializeField] private Text m_text = null;
    [SerializeField] private int m_cabinAmount = 0;

	void Start ()
    {
	    if (m_text == null)
        {
            m_text = gameObject.GetComponent<Text>();
        }   
	}

    public void SetAmount(int amount)
    {      
        m_cabinAmount = amount;
        if (m_cabinAmount == 0)
        {
            m_text.text = "";
        }
        else
        {
            m_text.text = m_cabinAmount + "hytter kvar";
        }
    }

    public int GetAmount()
    {
        return m_cabinAmount;
    }

    private void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("intro");
    }
}
