using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShowHide : MonoBehaviour
{     //这段代码不要挂在你要隐藏的物体上，否则隐藏后代码就失效了，无法再次激活
    GameObject[] cardA,cardB;

    void Start()
    {
        cardA = GameObject.FindGameObjectsWithTag("CardA");
        cardB = GameObject.FindGameObjectsWithTag("CardB");     //用两个是因为标签分开了A，B..
    }


    private void Update()
    {
        cardA = GameObject.FindGameObjectsWithTag("CardA");
        cardB = GameObject.FindGameObjectsWithTag("CardB");     //用两个是因为标签分开了A，B..
        foreach (GameObject cardx in cardA)
        {
            if (cardx.GetComponent<BattleA>().hp <= 0 && cardx.GetComponent<BattleA>().showflag == true)//若宝可梦被打败
            {
                cardx.SetActive(false);
                cardx.GetComponent<BattleA>().showflag = false;

                //这句删除脚本还没有写，因为出场三只的功能我还没有实现出来
//                Destroy(cardx.GetComponent(Type.GetType("Poke" + CallA.picture[CallA.num].ToString())));//(oo:删除原来的脚本)
                cardx.GetComponent<BattleA>().tag = "temp";           //(oo:更换标签)
                                                    //                call.choose = false;
            }
        }
        foreach (GameObject cardy in cardB)
            if (cardy.GetComponent<BattleB>().hp <= 0 && cardy.GetComponent<BattleB>().showflag == true)//若宝可梦被打败
            {
                CallB.cardnumberB--;                    //oo
                print(CallB.cardnumberB + "次数!!!");
                cardy.SetActive(false);
                cardy.GetComponent<BattleB>().showflag = false;
                cardy.GetComponent<BattleB>().tag = "temp";
                //                call.choose = false;
            }

        /*
        if (a.text == "0" && flag == true)                  //之前这部分代码放在Start()里面总是无法运行成功，注意这种细节
        {
            minioncard.SetActive(false);
            ++PicChange.number;
            print("图片编号为"+PicChange.number);
            flag = false;
            call.choose = false;
        }
        else if (a.text != "0" && flag == false && (call.choose) == true)
        {
            minioncard.SetActive(true);
            flag = true;
//            c.text = "8";
        }
        */
    }
}


