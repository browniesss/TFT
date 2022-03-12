using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rapid_FireCannon : ItemInfo
{
    public override void Item_Init(ChampionData champ)
    {
        champ.Attack_Range += 240;
    }
}
