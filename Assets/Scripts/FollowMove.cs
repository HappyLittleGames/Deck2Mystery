using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FollowMove : MonoBehaviour
{
    [SerializeField] float m_radius = 1;
    private bool m_following;
    private Vector2 m_startPos;
    private bool m_movable = true;

    public void SetMovable(bool state)
    {
        m_movable = state;
    }

	void Start ()
    {
        m_startPos = gameObject.transform.position;
        m_following = false;
	}
	
	void Update ()
    {
        if (m_movable)
        {
            if (Input.GetMouseButtonDown(0) && (Vector2.Distance(Input.mousePosition, gameObject.transform.position) < m_radius))
            {
                m_following = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                m_following = false;
                gameObject.transform.position = m_startPos;
            }


            if (m_following)
            {
                gameObject.transform.position = Input.mousePosition;
            }
        }
	}

    void SetFollowing(bool state)
    {
        m_following = state;
    }


}
