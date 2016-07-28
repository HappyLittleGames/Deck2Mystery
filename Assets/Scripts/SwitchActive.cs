using UnityEngine;
using System.Collections;

public class SwitchActive : MonoBehaviour
{
    public void Switch()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void SetState(bool state)
    {
        gameObject.SetActive(state);
    }
}
