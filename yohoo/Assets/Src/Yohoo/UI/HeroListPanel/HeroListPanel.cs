using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroListPanel : BaseUI {

    public UITable listTable;

    public HeroListItem itemTemplate;

    private List<HeroListItem> _itemList = new List<HeroListItem>();

	// Use this for initialization
	void Start () {
        this.InitUI();
	}

    private void InitUI()
    {
        List<HeroBase> list = DataManager.Instance.GetHeroList();
        for (int i = 0; i < list.Count; i++)
        {
            GameObject child = NGUITools.AddChild(listTable.gameObject, itemTemplate.gameObject);
            child.SetActive(true);
            HeroListItem item = child.GetComponent<HeroListItem>();
            item.heroData = list[i];
            _itemList.Add(item);
        }
        listTable.Reposition();

        this.ShowHero(list[0]);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowHero(HeroBase hero)
    {
        
    }

    public void OnClick(GameObject obj)
    {
       if(obj.name == "Close")
       {
           UIManager.Instance.CloseUI(UIPath.HeroListPanel);
           MainInterfacePanel.Instance.Show();
       }
    }
}
