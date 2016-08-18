using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Conversation : MonoBehaviour
{

    [SerializeField] private JawBounce m_jawBouncer;
    [SerializeField] private TextPrompter m_questionPrompter;
    [SerializeField] private List<string> m_questions;
    private int m_questionIndex = 0;
    [SerializeField] private List<string> m_answers;

    [SerializeField] private List<string> m_questionButtons;

    [SerializeField] private int buttonCount = 3;
    [SerializeField] private List <Button> m_answerButtons;
    
    [SerializeField] private int m_correctRange = 0;
    [SerializeField] private string m_correctAnswer = "";


    public void ButtonPress(int buttonIndex)
    {
        if (CheckAnswer(m_answerButtons[buttonIndex].GetComponentInChildren<Text>().text))
        {
            NextQuestion();
        }
    }

    private void NextQuestion()
    {
        if (m_questionIndex < m_questions.Count)
        {
            m_questionIndex++;
            m_questionPrompter.SetString(m_questions[m_questionIndex]);
            m_questionPrompter.ClickedButton();
        }
    }

    private bool CheckAnswer(string answer)
    {
        bool check = false;
        if (m_correctAnswer != "")
        {
            if (answer == m_correctAnswer)
            {
                check = true;
            }
        }
        if (m_correctRange != 0)
        {
            if (m_answers.Contains(answer))
            {
                if (m_answers.LastIndexOf(answer) <= m_correctRange)
                {
                    check = true;
                }
            }
        }
        return check;
    }
}
