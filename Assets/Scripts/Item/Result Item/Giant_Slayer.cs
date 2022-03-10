using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant_Slayer : ItemInfo
{
    // ���� �л���
    public override void Item_Attack_Act(ChampionData champ) // ü�¿� ���� �߰����ظ� ��.
    {
        ChampionData target_Champ = champ.cur_Target.GetComponent<ChampionData>();

        if (target_Champ.MaxHP < 1800)
            target_Champ.Damaged(champ.Damage * 0.2f);
        else if(target_Champ.MaxHP >= 1800)
            target_Champ.Damaged(champ.Damage * 0.6f);
    }

    public override void Item_Skill_Act(ChampionData champ) // ü�¿� ���� �߰����ظ� ��.
    {
        ChampionData target_Champ = champ.cur_Target.GetComponent<ChampionData>();

        if (target_Champ.MaxHP < 1800)
            target_Champ.Damaged(champ.Skill_Damage[champ.Champion_Level] * 0.2f);
        else if (target_Champ.MaxHP >= 1800)
            target_Champ.Damaged(champ.Skill_Damage[champ.Champion_Level] * 0.6f);
    }
}
