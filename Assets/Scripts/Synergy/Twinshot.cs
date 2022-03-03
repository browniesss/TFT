using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinshot : Synergy
{
    private int[] init_Power; // 처음 추가되는 능력치
    private int[] act_chance; // 레벨에 따른 확률

    void Start()
    {
        Synergy_Init();
    }

    public override void Synergy_Init()
    {
        synergy_Name = "쌍발총";
        synergy_Level = 0;
        synergy_MaxLevel = 3;
        synergy_Code = 5;
        needChamp_Count = new int[4];
        init_Power = new int[4];
        act_chance = new int[4];

        needChamp_Count[1] = 2;
        needChamp_Count[2] = 4;
        needChamp_Count[3] = 6;

        init_Power[0] = 0;
        init_Power[1] = 5;
        init_Power[2] = 40;
        init_Power[3] = 80;

        act_chance[1] = 0;
        act_chance[0] = 40;
        act_chance[2] = 70;
        act_chance[3] = 100;
    }

    public override void Synergy_Battle_Init(ChampionData champ) // 전투 시작 시 아카데미 효과
    {
        Debug.Log("쌍발총 Init 함수");
        champ.Damage += init_Power[synergy_Level];
        champ.Ability_Power += init_Power[synergy_Level];
    }

    public override void Synergy_Attack_Act(ChampionData champ)
    {
        int randVal = Random.Range(1, 101); // 1 부터 100까지 랜덤으로 수를 뽑음

        Debug.Log("쌍발총 공격랜덤 " + randVal);
        if (randVal < act_chance[synergy_Level]) // 현재 시너지 레벨의 확률보다 낮다면 발동
        {
            Debug.Log("쌍발총 공격발동 ");
            champ.GetComponent<Animator>().Play("Attack", -1, 0f);
            champ.twin_Shot_Check = true;
        }
    }

    void Update()
    {

    }
}
