using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guinsoos_RageBlade : ItemInfo
{
    // 구인수의 격노검 : 기본 공격시 전투끝날때까지 공격속도 + 6% 획득
    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        champ.item_Add_Attack_Delay += 6f; // 공격 시 마다 공격속도 6 % 증가
    }
}
