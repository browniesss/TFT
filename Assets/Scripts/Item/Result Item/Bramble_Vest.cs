using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bramble_Vest : ItemInfo
{
    bool isCooldown = false;  // 피해를 입히는 쿨타임
                              // 가시 갑옷  : 치명타 피해를 입었을 경우 치명타 피해를 무시, 기본공격에 맞을 경우 주변 적들에게 피해를 입힘(3회 피격마다 한번)
    int attacked_Count = 0;

    public override void Item_Init(ChampionData champ)
    {
        isCooldown = false;
        attacked_Count = 0;
    }


    public override void Item_Damaged_Act(ChampionData champ)
    {
        Debug.Log("가갑맞음" + "현재상태 :" + isCooldown);

        if (!isCooldown) // 쿨타임중이 아니라면
        {
            Debug.Log("쿨다운 아님");
            isCooldown = true;

            GameObject shock_Wave = GameManager.Resource.Instantiate("Item/Shock_Wave", champ.transform);
            shock_Wave.transform.position = champ.transform.position;
            Shock_Wave sw = shock_Wave.GetComponent<Shock_Wave>();

            sw.Shock_Wave_Init();
            sw.destroy_Coroutine_Start();
        }
        else
        {
            attacked_Count++;
            if (attacked_Count >= 3)
                isCooldown = false;
        }
    }
}
