using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClansDatabase : MonoBehaviour {

    private static ClansDatabase m_Instance;

    [SerializeField]
    private Clans[] m_Clans;
    public Clans[] clans
    {
        get { return m_Clans; }
    }

    private void Awake()
    {
        m_Instance = this;
    }

    private void LoadClans()
    {
        WebManager.GetRequest(WebManager.TEST_URL, (JSONNode node) => {
            if (node != null)
            {
                Debug.Log(node["username"].Value);
            }
        });
    }

    public static Clans Get(int id)
    {
        int clanId = System.Array.FindIndex(m_Instance.m_Clans, x => x.id == id);
        if(clanId != -1)
        {
            return m_Instance.m_Clans[clanId];
        }

        return null;
    }
}
