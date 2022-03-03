using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Synergy : MonoBehaviour
{
    public int synergy_Level; // �ó��� ���� 
    public int synergy_MaxLevel; // �ó��� �ִ뷹��
    public int[] needChamp_Count; // ���� �������� �ʿ��� è�Ǿ� �� 
    public int curChamp_Count; // ���� è�Ǿ� �� 
    public string synergy_Name; // �ó��� �̸�
    public int synergy_Code; // �ó��� �ڵ�

    public abstract void Synergy_Init();

    public virtual void Synergy_Battle_Init(ChampionData champ) { }

    public virtual void Synergy_Skill_Act(ChampionData champ) { }

    public virtual void Synergy_Attack_Act(ChampionData champ) { }

}
