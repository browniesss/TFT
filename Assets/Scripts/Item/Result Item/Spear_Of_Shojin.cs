using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Of_Shojin : ItemInfo
{
    // 쇼진의 창 기본 공격 시 추가로 마나를 8획득.
    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        champ.MP += 8; 
    }
}
