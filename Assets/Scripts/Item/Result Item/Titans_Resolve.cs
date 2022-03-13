using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titans_Resolve : ItemInfo
{
    int titans_Reslove_Stack; // 거인의 결의 스택
    bool isFull = false; // 최대 스택인지 판별해주는 bool 변수

    // 피해를 입거나 기본 공격시 공격력 , 주문력 2씩 증가
    // 최대 스택인 25스택 달성시 방어력, 마법 저항력이 25씩 증가

    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        if (titans_Reslove_Stack < 25) // 최대 스택 25스택을 넘어가기 전까지만
        {
            titans_Reslove_Stack++; // 기본 공격 시 마다 스택을 하나씩 늘려줌.

            champ.item_Add_Damage += 2;
            champ.item_Add_Ap += 2;
        }
        else if (titans_Reslove_Stack >= 25 && !isFull) // 최대스택이고 이미 풀스택이 아니라면
        {
            isFull = true;
            champ.item_Add_Armor += 25;
            champ.item_Add_Magic_Resistance += 25;
        }
    }

    public override void Item_Damaged_Act(ChampionData champ)
    {
        if (titans_Reslove_Stack < 25) // 최대 스택 25스택을 넘어가기 전까지만
        {
            titans_Reslove_Stack++; // 피격시 마다 스택을 하나씩 늘려줌.

            champ.item_Add_Damage += 2;
            champ.item_Add_Ap += 2;
        }
        else if (titans_Reslove_Stack >= 25 && !isFull) // 최대스택이고 이미 풀스택이 아니라면
        {
            isFull = true;
            champ.item_Add_Armor += 25;
            champ.item_Add_Magic_Resistance += 25;
        }
    }

    public override void Item_Battle_End(ChampionData champ)
    {
        titans_Reslove_Stack = 0; // 스택 초기화
        isFull = false; // 풀스택 여부 초기화
    }
}
