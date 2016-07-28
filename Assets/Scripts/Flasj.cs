using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flasj : MonoBehaviour
{

    [SerializeField] private bool m_flashing = false;

    private float m_time = 0;
    [SerializeField] private float m_interval = 0.7f;
    [SerializeField] private Color m_color1 = new Color(255, 227, 0, 255);
    [SerializeField] private Color m_color2 = new Color(255, 255, 255, 255);

    private Image m_image = null;

    void Start()
    {
        if (m_image == null)
        {
            m_image = gameObject.GetComponent<Image>();
        }
    }

    public void SetState(bool state)
    {
        m_flashing = state;
        if (!state)
            m_image.color = m_color2;
    }

    void Update()
    {
        if (m_flashing)
        {
            m_time += Time.deltaTime;
            {
                if (m_time > m_interval)
                {
                    m_time = 0;
                    if (m_image.color == m_color2)
                        m_image.color = m_color1;
                    else
                        m_image.color = m_color2;
                }
            }
        }
    }
}
