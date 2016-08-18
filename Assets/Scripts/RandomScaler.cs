using UnityEngine;
using System.Collections;

public class RandomScaler : MonoBehaviour {

    private Vector3 m_startScale;
    [SerializeField] private float m_factor = 1;
     
	void Start ()
    {
        gameObject.transform.localScale = gameObject.transform.localScale * Random.Range(1, 1 + m_factor);
    }
}
