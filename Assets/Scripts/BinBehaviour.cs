using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class BinBehaviour : MonoBehaviour //, IPointerUpHandler
{

    // [RequireComponent] Image;
    private Image m_image = null;

    [SerializeField] private SceneManager m_manager = null;
    [SerializeField] private string m_targetTag = "sops";

    void Start()
    {
        if (m_manager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>())
        {
            Debug.Log(gameObject.name + "found SceneManager");
        }
        else
        {
            Debug.Log(gameObject.name + "did not find SceneManager");
        }
        m_image = gameObject.GetComponent<Image>();
    }

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    RaycastResult ray = eventData.pointerPressRaycast;


    //    Debug.Log("Released over a " + gameObject.name + "with BinBehaviour");
    //    if (m_manager != null)
    //    {
    //        if (m_manager.GetHolding().tag == m_targetTag)
    //        {
    //            Destroy(m_manager.GetHolding());
    //            m_manager.ReleaseHolding();
    //            Debug.Log("threw some " + m_targetTag + "s" + "into " + gameObject.tag);
    //        }
    //    }

    //}

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // not great touch usability
            if (m_manager.GetHolding() != null)
            {
                // CheckTheDropped(Input.mousePosition);
                FindThrowables();
            }
        }
    }

    private void CheckTheDropped(Vector2 mousePos)
    {
        Rect binBounds = m_image.GetPixelAdjustedRect();
        if (binBounds.Contains(mousePos))
        {
            Debug.Log("Released in the dumping well of " + gameObject.name);
            if (m_manager.GetHolding().tag == m_targetTag)
            {
                Debug.Log("and " + m_manager.GetHolding().name + " had the correct tag");
            }
        }
    }

    private void FindThrowables()
    {       
        GraphicRaycaster graphicRaycaster = this.GetComponentInParent<GraphicRaycaster>();      
        PointerEventData ped = new PointerEventData(null);        
        ped.position = Input.mousePosition;       
        List<RaycastResult> results = new List<RaycastResult>();       
        graphicRaycaster.Raycast(ped, results);

        bool overBin = false;
        foreach (RaycastResult thing in results)
        {
            if (thing.gameObject == gameObject)
            {
                overBin = true;
                Debug.Log("BinBehaviour detected release over " + this.name);
            }
        }
        if (overBin)
        {
            if (m_manager.GetHolding().tag != null)
            {
                if (m_manager.GetHolding().tag == m_targetTag)
                {
                    Debug.Log("That's the right thing in the right place even! :D:D");
                    Destroy(m_manager.GetHolding());
                    m_manager.ReleaseHolding();
                    NKI nki = null;
                    if (nki = m_manager.GetNki())
                        nki.AddNki(2);
                }
                else
                {
                    Debug.Log("BinBehaviour detected throwable: " + m_manager.GetHolding().name + ", over " + this.name);
                    Destroy(m_manager.GetHolding());
                    m_manager.ReleaseHolding();
                    NKI nki = null;
                    if (nki = m_manager.GetNki())
                        nki.DeductNki(1);
                }
            }
        }
        
    }
}
