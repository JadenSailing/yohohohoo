using UnityEngine;
using System.Collections;

public class TestAPI : MonoBehaviour {

    private string getHeroUrl = "http://api.steampowered.com/IEconDOTA2_570/GetHeroes/v1/?key=0D43163FE27EE364B70C260F5E339943&language=zh_cn";
	// Use this for initialization

    private int loadIndex = 0;
	void Start () {
        loadIndex = ResourceManager.Instance.LoadRemoteTextByWWW(getHeroUrl, OnResourceLoaded);
	}

    private void OnResourceLoaded(int index, System.Object obj)
    {
        Debug.Log(obj);
    }
}
