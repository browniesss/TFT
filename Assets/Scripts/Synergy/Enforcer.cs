using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enforcer : Synergy
{
    void Start()
    {
        Synergy_Init();
    }

    public override void Synergy_Init()
    {
        synergy_Name = "มýวเภฺ";
        synergy_Level = 0;
        synergy_MaxLevel = 2;
        synergy_Code = 4;
        needChamp_Count = new int[3];

        needChamp_Count[1] = 2;
        needChamp_Count[2] = 4;
    }

    void Update()
    {

    }
}
