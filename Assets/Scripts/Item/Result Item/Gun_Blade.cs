using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Blade : ItemInfo
{
    public override void Item_Skill_Act(ChampionData champ, bool attack_Type)
    {
        if (!attack_Type) // 마법 피해일 경우에만 체력 회복 효과 발동
        {
            champ.Champion_Restore_HP(champ.get_Magic_Attack);
        }
    }
}
