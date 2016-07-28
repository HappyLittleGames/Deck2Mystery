using UnityEngine;
using System.Collections;

public class Wiper : Clickable
{
    [SerializeField] private string m_wiperTag = "mopp";

    [SerializeField] private GameObject m_nkiObject = null;
    private NKI m_nki = null;
    [SerializeField] private GameObject m_stain = null;
    [SerializeField] private GameObject m_wipe = null;
    [SerializeField] private float m_range = 10;
    void Start ()
    {
        if (m_stain == null)
            m_stain = gameObject;    
	}
	
	
	void Update ()
    {
        if (m_wipe != null)
        {
            if (Vector2.Distance(m_stain.transform.position, m_wipe.transform.position) < m_range)
            {
                if (m_nkiObject == null)
                {
                    m_nki = GameObject.FindGameObjectWithTag("FirstController").GetComponentInChildren<NKI>();
                }
                else
                {
                    m_nki = m_nkiObject.GetComponent<NKI>();
                }


                if (m_nki != null)
                {
                    m_nki.AddNki(2);
                }
                Destroy(m_stain);
            }
                       
        }
        GameObject wiperObject = null;
        if (wiperObject = GameObject.FindGameObjectWithTag(m_wiperTag))
        {
            if (Vector2.Distance(gameObject.transform.position, wiperObject.transform.position) < m_range)
            {
                Debug.Log(m_wiperTag + " treff");
                Destroy(gameObject);
            }
        }

    }
}
