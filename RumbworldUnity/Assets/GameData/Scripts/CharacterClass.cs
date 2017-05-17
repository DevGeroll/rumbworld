using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterClass {

    [SerializeField]
    private int m_ID;
    public int id
    {
        get { return m_ID; }
    }

    [SerializeField]
    private string m_Name;
    public string name
    {
        get { return m_Name; }
    }

    [SerializeField]
    private string m_Description;
    public string description
    {
        get { return m_Description; }
    }

    [SerializeField]
    private Sprite m_Icon;
    public Sprite icon
    {
        get { return m_Icon; }
    }
}
