using UnityEngine;
using System.Collections;

public class Wiper : MonoBehaviour
{

    [SerializeField] private GameObject m_nkiObject = null;
    [SerializeField] private GameObject m_stain = null;
    [SerializeField] private GameObject m_wipe = null;
    [SerializeField] private float m_range = 10;
    void Start ()
    {
        if (m_stain == null)
            m_stain = gameObject;
        else if (m_wipe == null)
            m_wipe = gameObject;
	}
	
	
	void Update ()
    {
	    if (Vector2.Distance(m_stain.transform.position, m_wipe.transform.position) < m_range)
        {
            if (m_nkiObject != null)
            {
                m_nkiObject.GetComponent<NKI>().AddNki(2);
            }
            Destroy(m_stain);
        }
	}
}
