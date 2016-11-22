using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainInterfacePanel : MonoBehaviour
{

    private static MainInterfacePanel m_instance;

    public static MainInterfacePanel Instance
    {
        get
        {
            return m_instance;
        }
    }

    void Awake()
    {
        m_instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClick(GameObject obj)
    {
        switch (obj.name)
        {
            case "hero":
                UIManager.Instance.ShowUI(UIPath.HeroListPanel);
                break;
            case "item":
                break;
        }
        this.Hide();
    }
}
