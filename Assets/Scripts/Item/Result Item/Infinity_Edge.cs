using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinity_Edge : ItemInfo
{
    /* 
    ������ ��� : ġ��Ÿ ���ط� 10 % ���� , ġ��Ÿ Ȯ���� 100%�� �Ǹ� �߰� Ȯ�� 1%�� ���ط� 1% ���� 
    */
    public override void Item_Init(ChampionData champ)
    {
        champ.item_Add_Critical_Damage += 10; // �ش� è�Ǿ��� ġ��Ÿ ���ط��� �÷���. 

        if (champ.Critical_Chance >= 100) // �ִ� ġ��Ÿ Ȯ���� �Ǹ� �ʰ�����ŭ ġ��Ÿ ���ط��� ����������.
            champ.item_Add_Critical_Damage += (champ.Critical_Chance - 100);
    }
}
