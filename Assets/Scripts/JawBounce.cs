using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JawBounce : MonoBehaviour
{

    [SerializeField] private GameObject m_face = null;
    [SerializeField] private GameObject m_jaw = null;

    private bool m_opening;
    private bool m_closing;
    private bool m_talking;
    public  void SetOpening(bool state) { m_opening = state; }

    [SerializeField]private float m_maxOffset;
    private float m_origMaxOffset;
    private float m_startPos;

    [SerializeField] private float m_speed;
    [SerializeField] private float m_rate;

    void Start ()
    {
        m_startPos = m_jaw.transform.position.y;
        m_maxOffset = m_startPos - m_maxOffset;
        m_origMaxOffset = m_maxOffset;
        m_talking = false;
        m_closing = false;
    }
	
	
	void Update ()
    {
        //if (Input.anyKeyDown)
        //{
        //    SetOpening(true);
        //    Debug.Log("StartOpening");
        //    m_talking = true;
        //}
        MoveJaw();        
	}

    void MoveJaw()
    {
        if (!m_closing)
        {
            if (m_opening)
            {
                if (m_jaw.transform.position.y > m_maxOffset)
                {
                    m_jaw.transform.position = new Vector2(m_jaw.transform.position.x, m_jaw.transform.position.y + (-m_speed * Time.deltaTime));
                }
                else
                {
                    m_opening = false;
                    m_closing = true;
                }
            }
        }
        else
        {
            m_opening = false;
            if (m_jaw.transform.position.y < m_startPos)
            {
                m_jaw.transform.position = new Vector2(m_jaw.transform.position.x, m_jaw.transform.position.y + (m_speed * Time.deltaTime));
            }
            else if (m_jaw.transform.position.y >= m_startPos)
            {
                m_talking = false;
                m_closing = false;
                m_maxOffset = m_origMaxOffset * Random.Range(0.95f, 1.05f);
            }
        }
        
    }
}


