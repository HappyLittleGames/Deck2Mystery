using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneCaretaker
{
    private Stack<SceneMemento> m_sceneStack = new Stack<SceneMemento>();

    public void AddScene(SceneMemento scene)
    {
        m_sceneStack.Push(scene);
    }

    public SceneMemento ApplyScene()
    {
        return m_sceneStack.Pop();
    }
}