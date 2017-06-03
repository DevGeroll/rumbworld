using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

sealed public class Initialiser : MonoBehaviour
{
    [SerializeField, Tooltip("Objects with IInitialized interface")]
    private ScriptableObject[] m_InitObjects;
    
    void Awake()
    {
        for(int i = 0; i < m_InitObjects.Length; i++)
        {
            if(m_InitObjects[i] is IInitialized)
                (m_InitObjects[i] as IInitialized).Init();
        }

        DontDestroyOnLoad(this.gameObject);

        Destroy(this);
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Initialiser))]
    public class InitialiserEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button("Clear Prefs"))
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }
#endif
}
