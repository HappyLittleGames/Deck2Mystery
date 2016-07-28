using UnityEngine;
using System.Collections;

public class ScreenScaler : MonoBehaviour
{
    [SerializeField] private Vector2 m_resolution = new Vector2(540, 960); 
	void Start ()
    {
        int width = (int)m_resolution.x;
        int height = (int)m_resolution.y;
        Screen.SetResolution(width, width, true);
	}

}
