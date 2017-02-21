using UnityEngine;
using System.Collections;


public class BattleA : MonoBehaviour {
    public int attack, hp;
    public int choice;//是否被选中，被选中时值为1
    public GameObject other;
    public int flag;//本轮是否攻击，若已攻击则值为1
    public bool showflag; //oo卡牌显示状态。true在显示，false未被显示
    void Start()
    {
        choice = 0;
        flag = 1;
        //攻击力和血量在一定范围内随机
        showflag = true;
        //该函数可以设定每张牌的攻击血量和贴图
        setSingle();
        //牌面数值改变
        GetComponentsInChildren<UILabel>()[0].text=attack.ToString();
        GetComponentsInChildren<UILabel>()[1].text = hp.ToString();
      
    }

    void Update()
    {
        if (choice == 1 && Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                other = hit.collider.gameObject;
                if (other.tag == "CardB" )
                {
                   
                    hp -= other.GetComponent<BattleB>().attack;
                    other.GetComponent<BattleB>().hp -= attack;
                    //牌面数值改变
                    this.GetComponentsInChildren<UILabel>()[1].text = hp.ToString();
                    other.GetComponentsInChildren<UILabel>()[1].text = other.GetComponent<BattleB>().hp.ToString();
                    print(name + "攻击了" + other.name + " 造成了" +attack + "点伤害，" + name + "剩余" + hp + "点生命值" + other.name + "剩余" + other.GetComponent<BattleB>().hp + "点生命值\n");
                     reset();
                }
            }

        }
        if (hp <= 0&&showflag==true)
        {
            print(name + "被击败\n");
            //GameObject.DestroyObject(this.gameObject);            
        }
       
    }
    void OnMouseDown()
    {
         if (flag!=1&&choice!=1)
        {
            GetComponentsInChildren<Renderer>()[0].material.color = Color.green;
            choice = 1;
        }            
    }

    public virtual void reset()
    {
        GetComponentsInChildren<Renderer>()[0].material.color = Color.white;
        choice = 0;
        flag = 1;
        other = null;
    }
   public virtual void setSingle()
    {
        attack = Random.Range(2, 5);
        hp = Random.Range(3, 8);

    }
}
