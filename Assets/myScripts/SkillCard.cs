using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCard : MonoBehaviour {

    // Use this for initialization
    string CardName;
    public int choice;
	void Start () {
        choice = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
   void OnMouseDown()
    {
      
        choice = 1;
        print(choice);
    }
}
