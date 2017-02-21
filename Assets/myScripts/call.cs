using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call : MonoBehaviour
{
    static public bool choose = false;         //是否点击了召唤(true点击，false未点击)
    GameObject[] cardA;
    private int i;
    private int callflag;                       //当前召唤次数   
    // Use this for initialization

    void Start()
    {
        cardA = GameObject.FindGameObjectsWithTag("cardA");
        int[] picture = new int[] { 1, 2, 3, 4, 5, 6 };         //图片编号
        i = Random.Range(0,picture.Length);
        callflag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject cardx in cardA)
        {
            if (Input.GetMouseButtonDown(0))
            {    //首先判断是否点击了鼠标左键

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //定义一条射线，这条射线从摄像机屏幕射向鼠标所在位置
                RaycastHit hit;    //声明一个碰撞的点(暂且理解为碰撞的交点)
                if (Physics.Raycast(ray, out hit))    //如果真的发生了碰撞，ray这条射线在hit点与别的物体碰撞了
                {
                    if (hit.collider.gameObject.name == "call" && (cardx.GetComponent<BattleA>().hp <= 0) && cardx.GetComponent<BattleA>().showflag==false && callflag==0)    //如果碰撞的点所在的物体的名字是“StartButton”(collider就是检测碰撞所需的碰撞器)
                    {
                        cardx.GetComponent<BattleA>().hp += 20;
                        //卡牌上数值要保持的更新
                        cardx.GetComponent<BattleA>().GetComponentsInChildren<UILabel>()[1].text = cardx.GetComponent<BattleA>().hp.ToString();
                        //贴图改变
                        cardx.GetComponent<BattleA>().GetComponentsInChildren<Renderer>()[0].material.mainTexture = (Texture)Resources.Load("i", typeof(Texture2D));
                        cardx.GetComponent<BattleA>().GetComponentsInChildren<Renderer>()[0].material.mainTextureScale = new Vector2(-1, 1);                    //贴图出现反向情况
                             
                        cardx.SetActive(true);
                        choose = true;
                        cardx.GetComponent<BattleA>().showflag = true;
                        cardx.GetComponent<BattleA>().tag = "cardA";
                        print("召唤神奇宝贝！");
                        callflag = 1;
                    }
                }
            }
        }
    }
}

