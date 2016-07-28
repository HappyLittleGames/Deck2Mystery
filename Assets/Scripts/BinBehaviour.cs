using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BinBehaviour : MonoBehaviour, IPointerUpHandler
{
    private GameManager m_manager = null;

    public void OnPointerUp(PointerEventData eventData)
    {
        if (m_manager == null)
        {
            m_manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
        if ((m_manager != null) && ( m_manager.GetHolding().tag == "lakan"))
        {
            Destroy(m_manager.GetHolding());
            m_manager.ReleaseHolding();
            Debug.Log("threw some lakans");
        }
    }
}
