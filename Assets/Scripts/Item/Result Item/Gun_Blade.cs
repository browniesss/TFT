using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Blade : ItemInfo
{
    public override void Item_Skill_Act(ChampionData champ, bool attack_Type)
    {
        if (!attack_Type) // ���� ������ ��쿡�� ü�� ȸ�� ȿ�� �ߵ�
        {
            champ.Champion_Restore_HP(champ.get_Magic_Attack);
        }
    }
}
