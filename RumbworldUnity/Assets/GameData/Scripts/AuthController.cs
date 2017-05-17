using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

//Player prefs:
//Last user name - login_username

public class AuthController : MonoBehaviour {
    
    [Header("Sign in")]
    [SerializeField]
    private InputField m_SignInUsername;
    [SerializeField]
    private InputField m_SignInPassword;

    [SerializeField]
    private Button m_SignInButton;

    [Header("Sign up")]
    [SerializeField]
    private Transform m_SignUpWindow;
    [SerializeField]
    private InputField m_SignUpUsername;
    [SerializeField]
    private InputField m_SignUpEmail;
    [SerializeField]
    private InputField m_SignUpPassword;
    [SerializeField]
    private InputField m_SignUpPasswordReply;

    [SerializeField]
    private Button m_SignUpButton;

    private void Awake()
    {
        m_SignInButton.onClick.AddListener(Auth);
        m_SignUpButton.onClick.AddListener(SignUp);

        m_SignInUsername.text = PlayerPrefs.GetString(Session.PREFS_LAST_LOGIN, "");
    }

    void Start ()
    {
         WebManager.GetRequest(WebManager.TEST_URL, (JSONNode node) => {
            if(node != null)
            {
                Debug.Log(node["username"].Value);
            }
        });

        WebManager.PostRequest(WebManager.BASE_URL + "site/post", new Dictionary<string, string>()
        {
            { "id", (23).ToString() }
        }, (JSONNode node) => {
            if(node != null)
            {
                Debug.Log(node["id"].Value);
            }
        });
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            SetRandomValues();
        }
    }

    public void SetRandomValues()
    {
        m_SignUpUsername.text = "Test" + Random.Range(0, 9999);
        m_SignUpEmail.text = "test" + Random.Range(0, 9999) + "@gmail.com";
        m_SignUpPassword.text = "121314";
        m_SignUpPasswordReply.text = "121314";
    }

    public void Auth()
    {
        if(string.IsNullOrEmpty(m_SignInUsername.text) || string.IsNullOrEmpty(m_SignInPassword.text))
            return;

        UIManager.ShowLoading(m_SignUpWindow);

        WebManager.PostRequest(WebManager.BASE_URL + "site/auth", new Dictionary<string, string>()
        {
            { "username", m_SignInUsername.text },
            { "password", m_SignInPassword.text }
        }, (JSONNode node) => {
            if (node != null)
            {
                if (node["success"].AsBool)
                {
                    Session.SetData(node["user"]["id"], node["user"]["username"]);

                    Debug.Log("Log in");

                    SceneLoader.LoadScene(SceneLoader.Scenes.Game);
                }
            }

            UIManager.HideLoading();
        });
    }

    public void SignUp()
    {
        if (string.IsNullOrEmpty(m_SignUpUsername.text) || string.IsNullOrEmpty(m_SignUpEmail.text) || string.IsNullOrEmpty(m_SignUpPassword.text) || string.IsNullOrEmpty(m_SignUpPasswordReply.text))
            return;

        if (m_SignUpPassword.text != m_SignUpPasswordReply.text)
        {
            Debug.Log("Password and password reply dosn't same!");

            return;
        }

        UIManager.ShowLoading(m_SignUpWindow);

        WebManager.PostRequest(WebManager.BASE_URL + "site/signup", new Dictionary<string, string>()
        {
            { "username", m_SignUpUsername.text },
            { "email", m_SignUpEmail.text },
            { "password", m_SignUpPassword.text }
        }, (JSONNode node) => {
            if (node != null)
            {
                if(node["error"] != null)
                {
                    Debug.LogError(node["error"].Value);
                }
                else
                {
                    Debug.Log("Sign up");
                }
            }

            UIManager.HideLoading();
        });
    }
}
