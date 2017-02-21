using UnityEngine;
using System.Collections;

public class Pokemon001 : BattleA {

    // Use this for initialization
    void Start()
    {
        choice = 0;
        flag = 1;
        attack = 2;
        hp = 4;
        //牌面数值改变
        this.GetComponentsInChildren<TextMesh>()[0].text = attack.ToString();
        this.GetComponentsInChildren<TextMesh>()[1].text = hp.ToString();
        //改变贴图
        this.GetComponent<Renderer>().material.mainTexture = (Texture)Resources.Load("001", typeof(Texture2D));

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
                if (other.tag == "CardB")
                {
                    other.GetComponent<Renderer>().material.color = Color.red;
                    hp -= other.GetComponent<BattleB>().attack;
                    other.GetComponent<BattleB>().hp -= attack;
                    //牌面数值改变
                    this.GetComponentsInChildren<TextMesh>()[1].text = hp.ToString();
                    other.GetComponentsInChildren<TextMesh>()[1].text = other.GetComponent<BattleB>().hp.ToString();
                    print(name + "攻击了" + other.name + " 造成了" + attack + "点伤害，" + name + "剩余" + hp + "点生命值" + other.name + "剩余" + other.GetComponent<BattleB>().hp + "点生命值\n");
                    reset();
                }
            }

        }
        if (hp <= 0)
        {
            print(name + "被击败\n");
            GameObject.DestroyObject(this.gameObject);
        }

    }
    // Update is called once per frame
    void reset()
    {
        GetComponent<Renderer>().material.color = Color.white;
        other.GetComponent<Renderer>().material.color = Color.white;
        choice = 0;
        flag = 1;
        if(hp<4)
        {
            hp += 1;
            this.GetComponentsInChildren<TextMesh>()[1].text = hp.ToString();
            print("妙蛙草的叶绿素特性发动，恢复一点生命值");
        }
        other = null;
    }
}
