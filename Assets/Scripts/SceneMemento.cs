using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneMemento
{
    public SceneMemento(string level)
    {
        m_name = level;
    }

    private string m_name;


    public void SetName(string name)
    {
        m_name = name; 
    }
    public string GetNamme()
    {
        return m_name;
    }
}