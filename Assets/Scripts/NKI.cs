using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NKI : MonoBehaviour {

    private int m_nki = 0;
    [SerializeField] private Text m_nkiText = null;
    [SerializeField] private float m_decay;
    private float m_time = 0;

    
	void Start ()
    {
	    if ( m_nkiText == null)
        {
            m_nkiText = gameObject.GetComponent<Text>();
        }
	}

	void Update ()
    {
        m_time += Time.deltaTime;
        if (m_time > m_decay)
        {
            if (m_nki > 0)
                m_nki--;
            m_time = 0;
        }

        m_nkiText.text = "NKI: " + m_nki + "%";
    }

    public void AddNki(int amount)
    {
        m_nki += amount;
        m_nkiText.text = "NKI: " + m_nki + "%";
    }
}
