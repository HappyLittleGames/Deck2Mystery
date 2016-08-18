using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class StringRepo : MonoBehaviour
{
    [SerializeField] private List<string> m_selves;
    [SerializeField] private List<string> m_things;
    [SerializeField] private List<string> m_opinions;

    void Start()
    {
        // selves
        m_selves.Add(" enligt marconi");
        m_selves.Add(" tycker markönigsegg");
        m_selves.Add(", musikfamilj givetvis");
        m_selves.Add(" "); // tomma är okej här, men i andra?
        m_selves.Add(", göm era döttrar");
        m_selves.Add("... som en cadillac-singel");

        // things
        m_things.Add(" svensk politik under Palme");
        m_things.Add(" att vara från en musikfamilj");
        m_things.Add(" radiohead, ändå, ");
        m_things.Add(" frölunda");

        // opinions
        m_opinions.Add(" är ju fan farligare än MMA");
        m_opinions.Add(" är inget annat än fitter");
        m_opinions.Add(" är ju fan farligare än MMA");
        m_opinions.Add(", vidrig");
        m_opinions.Add(", är dålig.");
    }

    public string[] GetSelves()
    {
        return m_selves.ToArray();
    }

    public string[] GetThings()
    {
        return m_things.ToArray();
    }

    public string[] GetOpinions()
    {
        return m_opinions.ToArray();
    }


    public string GetRandomSelf()
    {
        return m_selves[Random.Range(0, m_selves.Count -1)];
    }

    public string GetRandomThing()
    {
        return m_things[Random.Range(0, m_things.Count -1)];
    }

    public string GetRandomOpinion()
    {
        return m_opinions[Random.Range(0, m_opinions.Count - 1)];
    }
}