using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class WebManager : MonoBehaviour {

    private static WebManager instance;
    
    public const string BASE_URL = "http://rumbworlds.com/";
    private const string USERS_LIST = "users";

    public const string TEST_URL = "http://rumbworlds.com/site/users";

    private void Awake()
    {
        instance = this;
    }

    public static JSONResult GetRequest(string url, WebCallback onEnd = null)
    {
        WWW www = new WWW(url);
        JSONResult result = new JSONResult();

        instance.StartCoroutine(result.Request(www, onEnd));

        return result;
    }

    public static JSONResult PostRequest(string url, Dictionary<string, string> fields, WebCallback onEnd = null)
    {
        Hashtable postHeader = new Hashtable();

        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> field in fields)
        {
            form.AddField(field.Key, field.Value);
        }
        form.headers["Content-Type"] = "application/json; charset=utf-8";

        WWW www = new WWW(url, form);
        JSONResult result = new JSONResult();

        instance.StartCoroutine(result.Request(www, onEnd));

        return result;
    }

    public delegate void WebCallback(JSONNode node);

    public class JSONResult
    {
        private JSONNode m_Node = null;
        public JSONNode node
        {
            get { return m_Node; }
        }

        private bool m_IsFinished = false;
        public bool isFinished
        {
            get { return m_IsFinished; }
        }

        public IEnumerator Request(WWW www, WebCallback onEnd = null)
        {
            yield return www;

            // check for errors
            if (www.error == null)
            {
                Debug.Log("Result: " + www.data);

                m_Node = JSON.Parse(www.data);
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }

            if (onEnd != null)
                onEnd.Invoke(m_Node);

            m_IsFinished = true;
        }
    }
}
