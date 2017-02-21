using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroShana : MonoBehaviour {

    string HeroName;
    public GameObject HeroModel;
    public  List<int> Pokemon=new List<int>();//持有的宝可梦编号
    public  List<int> Skill = new List<int>();  //技能编号,公共技能和专属技能写在一起    
	// Use this for initialization
	void Start ()
    {
        HeroName = "莎娜";
        //补充莎娜模型并显示在指定位置
        //给公共两种技能卡数组赋值
        int[] a = new int[]{ 001, 002, 003, 001, 002, 003 };
        int[] b = new int[] {1, 2, 3, 1, 2, 3, 1, 2,3,1 };
        AddRange(a, b); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void AddRange(int[] a,int[] b)
    {
        Pokemon.AddRange(a);
        Skill.AddRange(b);
    }
}
