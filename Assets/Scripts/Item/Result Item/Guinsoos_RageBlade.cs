using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guinsoos_RageBlade : ItemInfo
{
    // ���μ��� �ݳ�� : �⺻ ���ݽ� �������������� ���ݼӵ� + 6% ȹ��
    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        champ.item_Add_Attack_Delay += 6f; // ���� �� ���� ���ݼӵ� 6 % ����
    }
}
