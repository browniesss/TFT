using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titans_Resolve : ItemInfo
{
    int titans_Reslove_Stack; // ������ ���� ����
    bool isFull = false; // �ִ� �������� �Ǻ����ִ� bool ����

    // ���ظ� �԰ų� �⺻ ���ݽ� ���ݷ� , �ֹ��� 2�� ����
    // �ִ� ������ 25���� �޼��� ����, ���� ���׷��� 25�� ����

    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        if (titans_Reslove_Stack < 25) // �ִ� ���� 25������ �Ѿ�� ��������
        {
            titans_Reslove_Stack++; // �⺻ ���� �� ���� ������ �ϳ��� �÷���.

            champ.item_Add_Damage += 2;
            champ.item_Add_Ap += 2;
        }
        else if (titans_Reslove_Stack >= 25 && !isFull) // �ִ뽺���̰� �̹� Ǯ������ �ƴ϶��
        {
            isFull = true;
            champ.item_Add_Armor += 25;
            champ.item_Add_Magic_Resistance += 25;
        }
    }

    public override void Item_Damaged_Act(ChampionData champ)
    {
        if (titans_Reslove_Stack < 25) // �ִ� ���� 25������ �Ѿ�� ��������
        {
            titans_Reslove_Stack++; // �ǰݽ� ���� ������ �ϳ��� �÷���.

            champ.item_Add_Damage += 2;
            champ.item_Add_Ap += 2;
        }
        else if (titans_Reslove_Stack >= 25 && !isFull) // �ִ뽺���̰� �̹� Ǯ������ �ƴ϶��
        {
            isFull = true;
            champ.item_Add_Armor += 25;
            champ.item_Add_Magic_Resistance += 25;
        }
    }

    public override void Item_Battle_End(ChampionData champ)
    {
        titans_Reslove_Stack = 0; // ���� �ʱ�ȭ
        isFull = false; // Ǯ���� ���� �ʱ�ȭ
    }
}
