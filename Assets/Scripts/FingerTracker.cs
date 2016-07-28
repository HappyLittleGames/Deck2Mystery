using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class FingerTracker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Vector2 m_handleOffset = new Vector2(0,0);
    private bool m_following;
    private Vector2 m_startPos;
    private bool m_isMoving = false;
    [SerializeField] private bool m_clickOffset = false;

    public void SartFollowing()
    {
        m_isMoving = true;
        if (m_clickOffset)
        {
            // too tired for this, do if you want.
            // m_handleOffset = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) - new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    public void StopFollowing()
    {
        m_isMoving = false;
        gameObject.transform.position = m_startPos;
        m_handleOffset = new Vector2(0, 0);
    }

    void Start()
    {
        m_startPos = gameObject.transform.position;
        m_following = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(screenToWorld, Vector2.zero);
            if (hit.collider != null)
            {
                // Debug.Log("Found a thing, it's name is " hit.collider.name); // googla skiten, canvas raycast eller nåt, eler använd eget ButtonScript heh
                if (hit.transform.gameObject == gameObject)
                {
                    SartFollowing();
                }
            }
        }
     
        if (m_isMoving)
        {
            gameObject.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + m_handleOffset;
        }
        //else if (new Vector2(gameObject.transform.position.x, gameObject.transform.position.x) != m_startPos)
        //{
        //    gameObject.transform.position = m_startPos;
        //}

        if (Input.GetMouseButtonUp(0))
        {
            StopFollowing();
        }
    }

    void SetFollowing(bool state)
    {
        m_following = state;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SartFollowing();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopFollowing();
    }

}
