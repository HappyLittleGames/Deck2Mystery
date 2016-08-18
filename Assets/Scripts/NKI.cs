using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NKI : MonoBehaviour {

    private int m_nki = 0;
    [SerializeField] private Text m_nkiText = null;
    [SerializeField] private float m_decay;
    [SerializeField] bool m_timedMode = false;
    private float m_time = 0;
    private int m_startSize = 0;

    
	void Start ()
    {
	    if ( m_nkiText == null)
        {
            m_nkiText = gameObject.GetComponent<Text>();
        }
        m_startSize = m_nkiText.fontSize;
	}

	void Update ()
    {
        m_time += Time.deltaTime;

        if ( (m_time > m_decay) && (m_timedMode) )
        {
            if (m_nki > 0)
                m_nki--;
            m_time = 0;
        }

        m_nkiText.text = "NKI: " + m_nki + "%";
        if (m_nkiText.fontSize > m_startSize)
            m_nkiText.fontSize -= 5;
        if (m_nkiText.color != Color.white)
            m_nkiText.color += Color.white * Time.deltaTime;
    }

    public void AddNki(int amount)
    {
        m_nki += amount;
        m_nkiText.text = "NKI: " + m_nki + "%";
        m_nkiText.fontSize = m_startSize * 4;
        m_nkiText.color = Color.green;
    }

    public void DeductNki(int amount)
    {
        m_nki -= amount;
        m_nkiText.text = "NKI: " + m_nki + "%";
        m_nkiText.fontSize = m_startSize * 4;
        m_nkiText.color = Color.red;
    }
}
