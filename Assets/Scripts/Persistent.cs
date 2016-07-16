using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour
{

	void Start ()
    {
        GameObject.DontDestroyOnLoad(gameObject);
	}
}
