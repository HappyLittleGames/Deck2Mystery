using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Clickable : MonoBehaviour
{

    private FollowMove m_mover;
    public FollowMove GetMover() { return m_mover; }

    void Start()
    {
        m_mover = new FollowMove();
    }
}
