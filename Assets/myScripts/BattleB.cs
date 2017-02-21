using UnityEngine;
using System.Collections;

public class BattleB : MonoBehaviour {
    public int attack, hp;
    public int choice,flag;
   public bool showflag; //oo

    void Start()
    {
        choice = 0;
        //攻击力和血量在一定范围内随机
        showflag = true;
        attack =Random.Range(2,4);
        flag = 1;
        hp = Random.Range(8,18);//8，,18
        //牌面数值改变
        this.GetComponentsInChildren<UILabel>()[0].text = attack.ToString();
        this.GetComponentsInChildren<UILabel>()[1].text = hp.ToString();
    }
    void Update()
    {
     
        if (hp <= 0)
        {
            print(name + "被击败\n");
//          this.gameObject.SetActive(false);          
        }
    }
    //作为对手，自动选择对手攻击
    public void fight()
    {
        if(flag==0)
        { 
        GameObject[] CardA = GameObject.FindGameObjectsWithTag("CardA");
        //系统AI部分
        //当前的方法是找出当前对面血量最低的卡
        int minHp = 100,minNum=0;        
        for(int j=0;j<CardA.Length;j++)
        {
            if (CardA[j].GetComponent<BattleA>().hp < minHp)
            {
                minHp = CardA[j].GetComponent<BattleA>().hp;
                minNum = j;
            }
        }
        
       
        //系统AI选卡部分结束
        hp -= CardA[minNum].GetComponent<BattleA>().attack;
        CardA[minNum].GetComponent<BattleA>().hp -= attack;
        //牌面数值改变
        this.GetComponentsInChildren<UILabel>()[1].text = hp.ToString();
        CardA[minNum].GetComponentsInChildren<UILabel>()[1].text = CardA[minNum].GetComponent<BattleA>().hp.ToString();

            //增加攻击动画
         GameObject old = new GameObject();
         old.GetComponent<Transform>().position = GetComponent<Transform>().transform.position;
         iTween.MoveTo(this.gameObject, CardA[minNum].transform.position, 10f);
         iTween.MoveTo(this.gameObject, old.GetComponent<Transform>().position, 10f);
          
         print(name + "攻击了" + CardA[minNum].name + " 造成了" + attack + "点伤害，" + name + "剩余" + hp + "点生命值" + CardA[minNum].name + "剩余" + CardA[minNum].GetComponent<BattleA>().hp + "点生命值\n");
         flag = 1;
        }
    }

    void OnMouseDown()
    {
    }

   public void reset()
    {       
        choice = 0;
        flag = 0;
    }

}
