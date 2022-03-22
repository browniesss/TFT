using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zzrot_Portal : ItemInfo
{
    // »ç¸Á½Ã 
    public override void Item_Death_Act(ChampionData champ)
    {
        GameObject zzrot = GameManager.Resource.Instantiate("Characters/Zzrot_Prefab"); // Áî·Ô »ý¼º

        zzrot.transform.position = champ.transform.position;
        zzrot.gameObject.tag = champ.gameObject.tag;
    }
}
