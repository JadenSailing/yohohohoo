using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Yohoo.Core;
using Yohoo.Resource;
public class DataManager : Singleton<DataManager>, ICommon
{
    private List<HeroBase> _heroList = null;

    private Dictionary<string, HeroData> _heroDataDict = new Dictionary<string, HeroData>();

    public void Init()
    {
        this.LoadHeroList();
        this.LoadHeroData();
    }

    public void Tick(int deltaTime)
    {

    }

    public void Release()
    {

    }

    public List<HeroBase> GetHeroList()
    {
        if(_heroList != null)
        {
            return _heroList;
        }
        else
        {
            return null;
        }
    }

    private void LoadHeroList()
    {
        string str = ResourceManager.Instance.LoadText(DataPath.HeroList);
        SimpleJson.JsonObject obj = SimpleJson.SimpleJson.DeserializeObject(str) as SimpleJson.JsonObject;
        obj = obj["result"] as SimpleJson.JsonObject;
        SimpleJson.JsonArray heroes = obj["heroes"] as SimpleJson.JsonArray;
        _heroList = new List<HeroBase>();
        for (int i = 0; i < heroes.Count; i++)
        {
            SimpleJson.JsonObject hero = heroes[i] as SimpleJson.JsonObject;
            HeroBase hb = new HeroBase();
            hb.dbName = hero[0].ToString();
            hb.dbNameShort = hb.dbName.Substring(14);
            hb.id = int.Parse(hero[1].ToString());
            hb.localName = hero[2].ToString();
            hb.smallImg = "UI/Image/heroes/selection/" + hb.dbName;
            hb.bigImg = "UI/Image/heroes/" + hb.dbNameShort;
            _heroList.Add(hb);
        }
    }

    public HeroData GetHeroData(string dbName)
    {
        if (_heroDataDict.ContainsKey(dbName))
        {
            return _heroDataDict[dbName];
        }
        else
        {
            return null;
        }
    }

    private Regex heroReg = new Regex("npc_dota_hero_[^\"]+");
    private void LoadHeroData()
    {
        string str = ResourceManager.Instance.LoadText(DataPath.HeroData);

        string[] lines = str.Split('\r','\n');

        bool enterHero = false;
        HeroData hero = null;
        int layNum = 0;
        System.Type heroType = typeof(HeroData);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            if(string.IsNullOrEmpty(line))
            {
                continue;
            }
            if(line.Contains("//"))
            {
                continue;
            }

            if(enterHero)
            {
                if(line.Contains("{"))
                {
                    layNum++;
                    continue;
                }
                if (line.Contains("}"))
                {
                    layNum--;
                    if(layNum == 0)
                    {
                        _heroDataDict[hero.dbName] = hero;
                        enterHero = false;
                    }
                    continue;
                }

                if(layNum > 1)
                {
                    continue;
                }

                if(layNum == 1)
                {
                    string[] attArr = line.Split('\t', '\"', ' ');
                    FieldInfo field = null;
                    heroType = hero.GetType();
                    for (int j = 0; j < attArr.Length; j++)
                    {
                        if(!string.IsNullOrEmpty(attArr[j]))
                        {
                            if (field != null)
                            {
                                field.SetValue(hero, attArr[j]);
                                break;
                            }
                            else
                            {
                                field = heroType.GetField(attArr[j]);
                            }
                        }
                    }
                }
                continue;
            }
            else
            {
                if(line.Contains("npc_dota_hero"))
                {
                    enterHero = true;
                    Match match = heroReg.Match(line);
                    if(match.Success)
                    {
                        hero = new HeroData();
                        hero.dbName = match.Value;   
                        continue;
                    }
                }

            }
        }

        UnityEngine.Debug.Log("heroDataDict.Count=" + _heroDataDict.Count);
    }
}
