using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant_Slayer : ItemInfo
{
    // 거인 학살자
    public override void Item_Attack_Act(ChampionData champ, bool attack_Type) // 체력에 따라 추가피해를 줌.
    {
        ChampionData target_Champ = champ.cur_Target.GetComponent<ChampionData>();

        if (target_Champ.MaxHP < 1800)
            target_Champ.Damaged(champ.Damage * 0.2f, attack_Type);
        else if (target_Champ.MaxHP >= 1800)
            target_Champ.Damaged(champ.Damage * 0.6f, attack_Type);
    }

    public override void Item_Skill_Act(ChampionData champ, bool attack_Type) // 체력에 따라 추가피해를 줌.
    {
        ChampionData target_Champ = champ.cur_Target.GetComponent<ChampionData>();

        if (target_Champ.MaxHP < 1800)
            target_Champ.Damaged(champ.Skill_Damage[champ.Champion_Level] * 0.2f, attack_Type);
        else if (target_Champ.MaxHP >= 1800)
            target_Champ.Damaged(champ.Skill_Damage[champ.Champion_Level] * 0.6f, attack_Type);
    }
}
