using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeTracker : MonoBehaviour
{
    [SerializeField] private Text m_timeText;


	void Update ()
    {
        m_timeText.text = "time: " + (int)Time.realtimeSinceStartup;
	}
}
