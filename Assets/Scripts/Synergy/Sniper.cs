using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Synergy
{
    void Start()
    {
        Synergy_Init();
    }

    public override void Synergy_Init()
    {
        synergy_Name = "Àú°Ý¼ö";
        synergy_Level = 0;
        synergy_MaxLevel = 3;
        synergy_Code = 3;
        needChamp_Count = new int[4];

        needChamp_Count[1] = 2;
        needChamp_Count[2] = 4;
        needChamp_Count[3] = 6;
    }

    void Update()
    {

    }
}
