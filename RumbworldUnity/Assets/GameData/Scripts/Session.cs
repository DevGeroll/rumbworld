using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour {

    public const string PREFS_LAST_LOGIN = "login_username";

    private static Session instance;

    private UserData m_UserData;

    public static int id
    {
        get { return instance.m_UserData.userId; }
    }

    public static string username
    {
        get { return instance.m_UserData.userName; }
    }

    public static bool isLogged = false;

    private void Awake()
    {
        instance = this;
    }

    public static void SetData(int id, string name)
    {
        instance.m_UserData = new UserData(id, name);

        isLogged = true;

        PlayerPrefs.SetString(PREFS_LAST_LOGIN, name);
    }

    [System.Serializable]
    private class UserData
    {
        [SerializeField]
        private int m_UserId;
        public int userId
        {
            get { return m_UserId; }
        }

        [SerializeField]
        private string m_UserName;
        public string userName
        {
            get { return m_UserName; }
        }

        public UserData(int id, string name)
        {
            m_UserId = id;
            m_UserName = name;
        }
    }
}
