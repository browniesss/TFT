using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protector : Synergy
{
    void Start()
    {
        Synergy_Init();
    }

    public override void Synergy_Init()
    {
        synergy_Name = "ºÀ¼âÀÚ";
        synergy_Level = 0;
        synergy_MaxLevel = 4;
        synergy_Code = 2;
        needChamp_Count = new int[5];

        needChamp_Count[1] = 2;
        needChamp_Count[2] = 3;
        needChamp_Count[3] = 4;
        needChamp_Count[4] = 5;
    }

    void Update()
    {

    }
}
