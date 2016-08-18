using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeTracker : MonoBehaviour
{
    [SerializeField] private Text m_timeText;
    int m_hClock = 15;
    int m_mClock = 30;
    float m_deltaSeconds = 0;
    [SerializeField] float m_secondsPerMinute = 1;

    void Update ()
    {
        if (m_deltaSeconds > m_secondsPerMinute)
        {
            m_deltaSeconds = 0;
            m_mClock++;
            if (m_mClock > 59)
            {
                m_hClock++;
                m_mClock = 0;
            }
        }

        m_timeText.text = "kl: " +  m_hClock.ToString("##") + ":" + m_mClock.ToString("##"); //  fel formatering ;I

        m_deltaSeconds += Time.deltaTime;

        if((m_hClock >= 18) && (m_mClock >= 30))
        {
            GameOver();
        }

    }

    void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("intro");
    }
}
