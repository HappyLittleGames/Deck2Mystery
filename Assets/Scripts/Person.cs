using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour
{
    private Conversation m_conversation;

    [SerializeField] private bool m_fullscreen = false;
    [SerializeField] Vector2 m_thumbScale = Vector2.zero;
    [SerializeField] Vector2 m_fullScale = Vector2.zero;

    [SerializeField] private GameObject m_fullScreenVersion = null;
    [SerializeField] private GameObject m_thumbnailVersion = null;
    
    void Start()
    {
        if (m_thumbScale == Vector2.zero)
            m_thumbScale = new Vector2(1, 1);
        if (m_fullScale == Vector2.zero)
            m_fullScale = new Vector2(4, 4);
    }

    public void OnClicked()
    {
        m_fullscreen = !m_fullscreen;

        m_fullScreenVersion.gameObject.SetActive(m_fullscreen);
        //  m_thumbnailVersion.gameObject.SetActive(!m_fullscreen);

        Debug.Log("switched fullscreen mode");
    }

    public void SetState(bool fullScreen)
    {
        m_fullscreen = fullScreen;
        m_fullScreenVersion.gameObject.SetActive(m_fullscreen);
    }

    public void SwitchState()
    {
        m_fullscreen = m_fullScreenVersion.activeSelf;
        m_fullscreen = !m_fullscreen;
        m_fullScreenVersion.gameObject.SetActive(m_fullscreen);
    }
}