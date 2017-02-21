using UnityEngine;
using System.Collections;

public class Poke003 : BattleA {

    // Use this for initialization
    public override void setSingle()
    {       
        attack = 7;
        hp = 10;       
        GetComponentsInChildren<Renderer>()[0].material.mainTexture = (Texture)Resources.Load("PokeCardPictures/003", typeof(Texture2D));

    }

    // Update is called once per frame
    
}
