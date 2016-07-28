using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextPrompter : MonoBehaviour
{
    public void SetString(string str) { PushChars(str); }
    private List<char> m_letterList;
    private TextCaretaker m_caretaker = new TextCaretaker();

    private bool m_clicked = false;
    [SerializeField] private Button m_button = null;
    [SerializeField] private Button m_nextButton = null;
    [SerializeField] private Text m_text;
    [SerializeField] private string m_string;
    private bool m_isPrinting = false;
    private bool m_isDone = false;
    [SerializeField] private float m_printSpeed;
    private float m_printTime;
    private int m_printIndex;

    [SerializeField] private string[] m_strings = { };
    private int m_curentString = 0;

    private JawBounce m_jawBouncer = null;

    [SerializeField] private GameObject m_nextItem;

    void Start()
    {
        if(m_jawBouncer == null)
        {
            m_jawBouncer = gameObject.GetComponent<JawBounce>();
        }
        m_printTime = 0;

        m_text.verticalOverflow = VerticalWrapMode.Overflow;
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
        m_printTime += Time.deltaTime * Random.Range(0.9f, 1.05f);

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
        if (m_letterList.Count == m_printIndex)
        {
            if (m_nextButton != null)
            {
                m_nextButton.gameObject.SetActive(true);
            }
        }
    }
    
    public void ClickedButton()
    {
        m_clicked = true;
    }

    void Update()
    {
        if( m_button == null )
        {
            if (Input.anyKeyDown)
            {
                m_text.text = "";
                m_isPrinting = true;
                SetString(m_string);
            }
        }
        else
        {
            if (m_clicked)
            {
                m_nextButton.gameObject.SetActive(false);
                m_clicked = false;

                m_text.text = "";
                m_isPrinting = true;
                SetString(m_string);
            }
            
        }


        if (m_isPrinting)
        {
            PrintChars();
        }
    }

    public void NextButton()
    {
        if (m_curentString < m_strings.Length)
        {
            m_string = m_strings[m_curentString];
            SetString(m_strings[m_curentString]);
            ClickedButton();
            // SaveString(m_strings[m_curentString]);

            m_curentString++;
        }
        else
        {
            Debug.Log("Last index");
            gameObject.GetComponentInParent<Person>().SetState(false);
            if (m_nextItem != null)
            {
                if (m_nextItem.GetComponent<Flasj>())
                {
                    m_nextItem.GetComponent<Flasj>().SetState(true);
                }
            }
        }
    }

    public void ApplyMemento(TextMemento memento)
    {
        m_string = memento.GetString();
    }

    private void SaveString(string str)
    {
        TextMemento mem = new TextMemento();
        mem.SetString(str);
        m_caretaker.SaveString(mem);
    }
}