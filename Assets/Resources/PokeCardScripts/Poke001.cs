using UnityEngine;
using System.Collections;

public class Poke001 : BattleA
{

    // Use this for initialization
   public override void  setSingle()
    {
      
        attack = 2;
        hp = 4;
        GetComponentsInChildren<Renderer>()[0].material.mainTexture = (Texture)Resources.Load("PokeCardPictures/001", typeof(Texture2D));

    }
    
    // Update is called once per frame
    public override void reset()
    {
        GetComponentsInChildren<Renderer>()[0].material.color = Color.white;        
        choice = 0;
        flag = 1;
        if (hp < 4)
        {
            hp += 1;
            this.GetComponentsInChildren<UILabel>()[1].text = hp.ToString();
            print("妙蛙草的叶绿素特性发动，恢复一点生命值");
        }
        other = null;
    }
}
