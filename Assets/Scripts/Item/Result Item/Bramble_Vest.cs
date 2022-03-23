using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bramble_Vest : ItemInfo
{
    bool isCooldown = false;  // 피해를 입히는 쿨타임
                              // 가시 갑옷  : 치명타 피해를 입었을 경우 치명타 피해를 무시, 기본공격에 맞을 경우 주변 적들에게 피해를 입힘(2.5초마다 한번)
    public override void Item_Damaged_Act(ChampionData champ)
    {
        if(!isCooldown) // 쿨타임중이 아니라면
        {
            isCooldown = true;

            StartCoroutine(coolDown_Coroutine());
        }

    }

    IEnumerator coolDown_Coroutine()
    {
        yield return new WaitForSeconds(2.5f);

        isCooldown = false;
    }
}
