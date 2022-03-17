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

        if (attack_Count == 3) // 3�� �⺻������ �ߴٸ�
        {
            List<GameObject> other_TargetList = Util.Instance.FindNearestObjectsByTag(champ.cur_Target, "Enemy");

            int listCount = 0;
            foreach (GameObject obj in other_TargetList)
            {
                obj.GetComponent<ChampionData>().Damaged(70f, false); // ���� �������� ����.
                Debug.Log("����ƽ���� ������ ������ : " + obj.name);
                listCount++;

                if (listCount >= 4) // ��ó 4����� �������� ����
                    break;
            }
            attack_Count = 0;
        }
    }

}
