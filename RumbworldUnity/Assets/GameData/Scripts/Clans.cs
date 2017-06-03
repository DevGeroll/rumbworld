using UnityEngine;

[System.Serializable]
public class Clans {
    
    private int m_ID;
    public int id
    {
        get { return m_ID; }
    }

    private string m_Name;
    public string name
    {
        get { return m_Name; }
    }

    private string m_Description;
    public string description
    {
        get { return m_Description; }
    }

    private Sprite m_Icon;
    public Sprite icon
    {
        get { return m_Icon; }
    }

    private int m_LocationId;
}
