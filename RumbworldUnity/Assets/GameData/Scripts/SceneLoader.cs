using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private static SceneLoader instance;

    public enum Scenes
    {
        Init,
        Login,
        Characters,
        Game
    }

    [SerializeField]
    private bool m_FirstLoading = true;

    [SerializeField]
    private Scenes m_FirstScene;
    [SerializeField]
    private Scenes[] m_LoadingScenes;
    
    private void Awake()
    {
        instance = this;

        if(m_FirstLoading)
            LoadScene(m_FirstScene);
    }

    public static void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);
    }
}
