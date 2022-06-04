using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron_Will : ItemInfo
{
    int temp_Number = 0;

    public override void Item_Init(ChampionData champ)
    {
        temp_Number = 0;
        temp_Number = champ.targeted_Count;
    }

    public override void Item_Constant_Act(ChampionData champ)
    {
        if(temp_Number != champ.targeted_Count)
        {
            champ.item_Add_Armor += (champ.targeted_Count - temp_Number) * 18;
            champ.item_Add_Magic_Resistance += (champ.targeted_Count - temp_Number) * 18;

            temp_Number = champ.targeted_Count;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
