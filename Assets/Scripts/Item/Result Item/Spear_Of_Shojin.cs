using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Of_Shojin : ItemInfo
{
    // ������ â �⺻ ���� �� �߰��� ������ 8ȹ��.
    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        champ.MP += 8; 
    }
}
