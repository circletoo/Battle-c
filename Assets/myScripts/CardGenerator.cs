using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CardGenerator : MonoBehaviour {

    // Use this for initialization
    public List<int> PokemonA = new List<int>();//A持有的宝可梦编号
    public List<int> PokemonB = new List<int>();//B持有的宝可梦编号
    public List<int> SkillA = new List<int>();  //A的技能编号
    public List<int> SkillB = new List<int>();  //B的技能编号
    public List<GameObject> CardA = new List<GameObject>();//A的手牌
    public List<GameObject> CardB = new List<GameObject>();//B的手牌
    int aChange,bChange; //A,B手牌的位移 
    float timer =0;
    int numA, numB;//A,B牌堆中卡牌数量

    void Awake()
    {
        //分别读取双方持有的宝可梦和技能卡牌
        PokemonA = GameObject.Find("HeroA").GetComponent<HeroShana>().Pokemon;
        PokemonB = GameObject.Find("HeroB").GetComponent<HeroShana>().Pokemon;
        SkillA = GameObject.Find("HeroA").GetComponent<HeroShana>().Skill;
        SkillB = GameObject.Find("HeroB").GetComponent<HeroShana>().Skill;
        print("调用awake");

    }
    void Start ()
    {
      
        
        aChange= bChange = 0;//手牌位移初值
        numA = numB = 10;
        print("Generator准备完毕");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GenerateSkillCard(Hero hero)
    {
        timer += Time.deltaTime;
        if(hero==Hero.HeroA)
        {            
            int random = (int)Random.Range(0,SkillA.Count);
            GameObject newcard=(GameObject)Instantiate(Resources.Load("Prefab/SkillCardA"));
            newcard.GetComponentsInChildren<Renderer>()[0].material.mainTexture = (Texture)Resources.Load("SkillCardPictures/"+ SkillA[random].ToString());
            SkillA.RemoveAt(random);     
            iTween.MoveTo(newcard, new Vector3(-2+aChange, 1, -4), 10);            
            iTween.RotateTo(newcard, new Vector3(-90, 180, -180), 2);            
            aChange++;
            CardA.Add(newcard);           
            CleanUp(CardA);
        }
        else if(hero==Hero.HeroB)
        {
            int random = (int)Random.Range(0, SkillB.Count);
            GameObject newcard = (GameObject)Instantiate(Resources.Load("Prefab/SkillCardB"));
//            newcard.AddComponent<BattleA>();
            newcard.GetComponentsInChildren<Renderer>()[0].material.mainTexture = (Texture)Resources.Load("SkillCardPictures/"+ SkillB[random].ToString());
            SkillB.RemoveAt(random);
            iTween.MoveTo(newcard, new Vector3(-2 + bChange, 1, 4), 10);            
            iTween.RotateTo(newcard, new Vector3(-90, 0, -180), 2);
            bChange++;
            CardB.Add(newcard);
            CleanUp(CardB);
        }
        
    }
    public void CleanUp(List<GameObject> list)
    {
        float space = 8.0f/ list.Count;
        int k=0;
        foreach(GameObject g in list)
        {
            if(list==CardA)
                iTween.MoveTo(g, new Vector3(-3 + space * k, 1, -4), 0.5f);
           
            if(list==CardB)
                iTween.MoveTo(g, new Vector3(-3 + space * k, 1, 4), 0.5f);
            k++;
        }
    }
    public void GenerateWeatherCard()
    {
        //随机产生天气卡牌，待补充
    }

}
