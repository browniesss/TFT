using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Academy : Synergy
{
    private int[] init_Power; // 처음 추가되는 능력치
    private int[] add_Power; // 스킬 쓸때마다 추가되는 능력치

    void Start()
    {
        Synergy_Init();
    }

    public override void Synergy_Init()
    {
        synergy_Name = "아카데미";
        synergy_Level = 0;
        synergy_MaxLevel = 4;
        synergy_Code = 1;
        needChamp_Count = new int[5];
        init_Power = new int[5];
        add_Power = new int[5];

        needChamp_Count[1] = 2;
        needChamp_Count[2] = 4;
        needChamp_Count[3] = 6;
        needChamp_Count[4] = 8;

        init_Power[1] = 18;
        init_Power[2] = 40;
        init_Power[3] = 50;
        init_Power[4] = 70;

        add_Power[1] = 3;
        add_Power[2] = 5;
        add_Power[3] = 10;
        add_Power[4] = 15;
    }

    public void Academy_Battle_Init(ChampionData champ) // 전투 시작 시 아카데미 효과
    {
        champ.Damage += init_Power[synergy_Level];
        champ.Ability_Power += init_Power[synergy_Level];

        Debug.Log("init_Power : " + init_Power[synergy_Level] + "level : " + synergy_Level);
    }

    void Update()
    {

    }
}
