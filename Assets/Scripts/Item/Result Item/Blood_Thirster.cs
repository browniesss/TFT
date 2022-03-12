using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_Thirster : ItemInfo
{
    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        if(attack_Type) // 물리 피해일 경우에만 체력 회복 효과 발동
        {
            champ.Champion_Restore_HP(champ.get_Pysical_Attack);
        }
    }

    public override void Item_Skill_Act(ChampionData champ, bool attack_Type)
    {
        if (attack_Type) // 물리 피해일 경우에만 체력 회복 효과 발동
        {
            champ.Champion_Restore_HP(champ.get_Pysical_Attack);
        }
    }

}

