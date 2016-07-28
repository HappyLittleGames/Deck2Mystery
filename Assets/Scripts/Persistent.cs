using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour
{

    void OnLevelWasLoaded()
    {
        if (gameObject.tag == "FirstController")
        {
            foreach (GameObject controller in GameObject.FindGameObjectsWithTag("PersistentController"))
            {
                if (controller != gameObject)
                {
                    Destroy(controller);
                }
            }
        }
    }
	void Start ()
    {
        if (gameObject.tag == "PersistentController")
        {
            gameObject.tag = "FirstController";
        }
        GameObject.DontDestroyOnLoad(gameObject);
	}
}
