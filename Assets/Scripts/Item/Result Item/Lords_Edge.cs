using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lords_Edge : ItemInfo
{
    public override void Item_Init(ChampionData champ)
    {
        switch (champ.Champion_Level)
        {
            case 0:
                {
                    champ.item_Add_Damage += 50;
                }
                break;
            case 1:
                {
                    champ.item_Add_Damage += 75;
                }
                break;
            case 2:
                {
                    champ.item_Add_Damage += 100;
                }
                break;
        }
    }
}
