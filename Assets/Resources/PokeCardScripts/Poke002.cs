using UnityEngine;
using System.Collections;

public class Poke002 : BattleA
{

    // Use this for initialization
    public override void setSingle() {
        attack = 5;
        hp = 7;
        GetComponentsInChildren<Renderer>()[0].material.mainTexture = (Texture)Resources.Load("PokeCardPictures/002", typeof(Texture2D));

    }
	
	// Update is called once per frame
	
}
