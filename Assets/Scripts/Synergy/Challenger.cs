using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenger : Synergy
{

    void Start()
    {
        Synergy_Init();
    }

    public override void Synergy_Init()
    {
        synergy_Level = 0; // 시너지 레벨 
        synergy_MaxLevel = 8; // 시너지 최대레벨
        needChamp_Count = new int[5]; // 현재 레벨에서 필요한 챔피언 수 
        curChamp_Count = 0; // 현재 챔피언 수 
        synergy_Name = "도전자"; // 시너지 이름
        synergy_Code =6; // 시너지 코드

        needChamp_Count[1] = 2;
        needChamp_Count[2] = 4;
        needChamp_Count[3] = 6;
        needChamp_Count[4] = 8;



    }





}
