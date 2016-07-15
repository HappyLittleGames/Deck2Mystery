using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextPrompter : MonoBehaviour
{
    public void SetString(string str) {PushChars(str); }
    private List<char> m_letterList; 

    [SerializeField] private Text m_text;
    private bool m_isPrinting;
    [SerializeField] private float m_printSpeed;
    private float m_printTime;
    private int m_printIndex;

    private JawBounce m_jawBouncer = null;

    void Start()
    {
        if(m_jawBouncer == null)
        {
            m_jawBouncer = gameObject.GetComponent<JawBounce>();
        }
        m_printTime = 0;
    }

    private void PushChars(string str)
    {
        m_letterList = new List<char>();
        char[] chArray = str.ToCharArray();

        for (int i = 0; i < chArray.Length; i++)
        {
            m_letterList.Add(chArray[i]);
        }

        m_printIndex = 0;
    }

    private void PrintChars()
    {
        m_printTime += Time.deltaTime * Random.Range(0.9f, 1.1f);
        if(m_letterList.Count > m_printIndex)
        {
            if (m_printTime > m_printSpeed)
            {
                m_jawBouncer.SetOpening(true);
                m_text.text += m_letterList[m_printIndex].ToString();
                m_printIndex++;
     
                Debug.Log(m_printIndex);
            }
        }   
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            m_isPrinting = true;
            SetString("okej, här kommer texten");
        }


        if (m_isPrinting)
        {
            PrintChars();
        }
    }
}
