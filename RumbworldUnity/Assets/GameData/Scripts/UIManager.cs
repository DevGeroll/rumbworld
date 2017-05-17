using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIManager instance;

    [SerializeField]
    private GameObject m_LoadingObject;
    private RectTransform m_LoadingRectTransform;

    private void Awake()
    {
        instance = this;

        m_LoadingRectTransform = m_LoadingObject.GetComponent<RectTransform>();
    }

    public static void ShowLoading(Transform parent)
    {
        instance.m_LoadingRectTransform.SetParent(parent);
        instance.m_LoadingRectTransform.anchorMin = Vector2.zero;
        instance.m_LoadingRectTransform.anchorMax = Vector2.one;
        instance.m_LoadingRectTransform.sizeDelta = Vector2.zero;

        instance.m_LoadingRectTransform.localPosition = Vector3.zero;
        instance.m_LoadingRectTransform.localScale = Vector3.one;

        instance.m_LoadingObject.SetActive(true);
    }

    public static void HideLoading()
    { 
        instance.m_LoadingObject.SetActive(false);
    }
}
