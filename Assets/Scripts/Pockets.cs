using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Pockets : MonoBehaviour
{

    private List<Clickable> m_clickables = null;

    void AddItem(Clickable item)
    {
        m_clickables.Add(item);
    }

    void HidePockets()
    {
        foreach (Clickable item in m_clickables)
        {
            item.gameObject.SetActive(false);
        }
    }

    void ShowPockets()
    {
        foreach (Clickable item in m_clickables)
        {
            item.gameObject.SetActive(true);
        }
    }

    void ArrangePockets(Vector2 position, float size)
    {
        for (int i = 0; i < m_clickables.Count; i++)
        {
            int count = 0;
            int columns = 5;
            int row = 0;
            if (count <= columns)
            {
                m_clickables[i].gameObject.transform.position = position + new Vector2(count * size, - row * size);
                if(count == 5)
                {
                    count = 0;
                    row++;
                }
                else
                {
                    count++;
                }
                
            }
        }
    }

    void MoveablePockets(bool state)
    {
        foreach(Clickable item in m_clickables)
        {
            item.GetMover().SetMovable(state);
        }
    }
}