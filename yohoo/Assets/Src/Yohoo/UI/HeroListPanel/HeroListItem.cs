using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroListItem : MonoBehaviour {

    [HideInInspector]
    public HeroBase heroData;

    public HeroListPanel panel;

    public UITexture icon;

	// Use this for initialization
	void Start () {
        icon.mainTexture = ResourceManager.Instance.LoadObject(heroData.smallImg) as Texture2D;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick(GameObject obj)
    {
        panel.ShowHero(heroData);
    }
}
