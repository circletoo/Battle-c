using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CallA : MonoBehaviour
{
    static public bool choose = false;         //是否点击了召唤(true点击，false未点击)
    static public int callflagA;                       //当前召唤次数 
    GameObject[] cardA;
    static public List<string> picture = new List<string>();
    static public int num;//图片编号
    public int i;

    static bool initialflag;//第一次的初始化

    void Start()
    {
        cardA = GameObject.FindGameObjectsWithTag("CardA");
        //        List<int> picture =new List<int>();//图片编号
        picture.Add("001");
        picture.Add("002");
        picture.Add("003");
        picture.Add("004");
        i = picture.Count;             //
        num = (int)UnityEngine.Random.Range(0, i);    //  Random.Range()包前不包后，这个地方必须用i，不能用picture.Count,为什么啊！
        callflagA = 0;
        initialflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(initialflag==false)
        {


        }
        foreach (GameObject cardx in cardA)
        {
            if (Input.GetMouseButtonDown(0))
            {    //首先判断是否点击了鼠标左键

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //定义一条射线，这条射线从摄像机屏幕射向鼠标所在位置
                RaycastHit hit;    //声明一个碰撞的点(暂且理解为碰撞的交点)
                if (Physics.Raycast(ray, out hit))    //如果真的发生了碰撞，ray这条射线在hit点与别的物体碰撞了
                {
                    if (GameController.hero== Hero.HeroA && hit.collider.gameObject.name == "PokeBallA" && (cardx.GetComponent<BattleA>().hp <= 0) && cardx.GetComponent<BattleA>().showflag == false && callflagA==0)    //如果碰撞的点所在的物体的名字是“StartButton”(collider就是检测碰撞所需的碰撞器)
                    {
                        cardx.GetComponent<BattleA>().hp += 20;
                        //卡牌上数值要保持的更新
                        cardx.GetComponent<BattleA>().GetComponentsInChildren<UILabel>()[1].text = cardx.GetComponent<BattleA>().hp.ToString();
                        //贴图改变
                        cardx.GetComponent<BattleA>().GetComponentsInChildren<Renderer>()[0].material.mainTexture = (Texture)Resources.Load("PokeCardPictures/" + picture[num].ToString(), typeof(Texture2D));
                        //                        cardx.GetComponent<BattleA>().GetComponentsInChildren<Renderer>()[0].material.mainTextureScale = new Vector2(-1, 1);                    //贴图出现反向情况


                        if (picture != null)
                        {
                            print(num + " " + i + " " + picture[num]);
                            picture.RemoveAt(num);
                            //i = picture.Count;   // 每次remove后的size都会发生变化，但是迭代基数没有根据remove后的size动态调整，导致越界及集合遍历不完全。 
                            i--;
                            num = (int)UnityEngine.Random.Range(0, i - 1);
                        }

                        cardx.SetActive(true);
                        choose = true;
                        cardx.GetComponent<BattleA>().showflag = true;
                        cardx.GetComponent<BattleA>().tag = "CardA";
                        cardx.AddComponent(Type.GetType("Poke" + picture[num].ToString()));
                        print("召唤神奇宝贝！");
                        callflagA++;
                        Invoke("Update", 5f);
                    }
                }
            }    
        }
        callflagA = 0;
    }
}
