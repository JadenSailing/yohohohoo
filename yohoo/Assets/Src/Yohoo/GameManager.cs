using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;

    public GameObject uiRoot = null;
    void Start()
    {
        m_Instance = this;
        DontDestroyOnLoad(this.gameObject);

        ResourceManager.Instance.Init();

        UIManager.Instance.Init();
        UIManager.Instance.uiRoot = uiRoot;

        DataManager.Instance.Init();

        _lastTickTime = Time.time;
    }

    private float _lastTickTime = 0.0f;
    void Update()
    {
        float time = Time.time;
        ResourceManager.Instance.Tick((int)((time - _lastTickTime) * 1000));
        _lastTickTime = time;
    }

    public static GameManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public GameObject MonoObject
    {
        get
        {
            return this.gameObject;
        }
    }

}
