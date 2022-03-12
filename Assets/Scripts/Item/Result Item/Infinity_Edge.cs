using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinity_Edge : ItemInfo
{
    /* 
    무한의 대검 : 치명타 피해량 10 % 증가 , 치명타 확률이 100%가 되면 추가 확률 1%당 피해량 1% 증가 
    */
    public override void Item_Init(ChampionData champ)
    {
        champ.item_Add_Critical_Damage += 10; // 해당 챔피언의 치명타 피해량을 올려줌. 

        if (champ.Critical_Chance >= 100) // 최대 치명타 확률이 되면 초과량만큼 치명타 피해량을 증가시켜줌.
            champ.item_Add_Critical_Damage += (champ.Critical_Chance - 100);
    }
}
