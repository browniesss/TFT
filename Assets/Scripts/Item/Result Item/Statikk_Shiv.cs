using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statikk_Shiv : ItemInfo
{
    // 3��° ���ݸ��� 4���� ������ ƨ��� ���������� ���� 70�� �������ظ� ���� �� ����� �������׷� 5�ʵ��� 50% ����   
    int attack_Count = 0; // ���� ī��Ʈ

    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        attack_Count++;

        if(attack_Count == 3) // 3�� �⺻������ �ߴٸ�
        {
            GameObject other_Target = Util.Instance.FindNearestObjectByTag(champ.cur_Target, "Enemy");
        }
    }

}
