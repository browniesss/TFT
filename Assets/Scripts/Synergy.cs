using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Synergy : MonoBehaviour
{
    public int synergy_Level; // 시너지 레벨 
    public int synergy_MaxLevel; // 시너지 최대레벨
    public int[] needChamp_Count; // 현재 레벨에서 필요한 챔피언 수 
    public int curChamp_Count; // 현재 챔피언 수 
    public string synergy_Name; // 시너지 이름
    public int synergy_Code; // 시너지 코드

    public abstract void Synergy_Init();

    public virtual void Synergy_Battle_Init(ChampionData champ) { }

    public virtual void Synergy_Skill_Act(ChampionData champ) { }

    public virtual void Synergy_Attack_Act(ChampionData champ) { }

}
