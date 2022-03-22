using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zzrot_Portal : ItemInfo
{
    // ����� 
    public override void Item_Death_Act(ChampionData champ)
    {
        GameObject zzrot = GameManager.Resource.Instantiate("Characters/Zzrot_Prefab"); // ��� ����

        zzrot.transform.position = champ.transform.position;
        zzrot.gameObject.tag = champ.gameObject.tag;
    }
}
