using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NKI : MonoBehaviour {

    private int m_nki = 0;
    [SerializeField] private Text m_nkiText = null;

	void Start ()
    {
	    if ( m_nkiText == null)
        {
            m_nkiText = gameObject.GetComponent<Text>();
        }
	}

	void Update ()
    {
	
	}

    public void AddNki(int amount)
    {
        m_nki += amount;
        m_nkiText.text = "NKI: " + m_nki + "%";

    }
}
