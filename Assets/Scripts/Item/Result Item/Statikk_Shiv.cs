using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statikk_Shiv : ItemInfo
{
    // 3번째 공격마다 4명의 적에게 튕기는 번개공격을 가해 70의 마법피해를 입힌 후 대상의 마법저항력 5초동안 50% 감소   
    int attack_Count = 0; // 공격 카운트

    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        attack_Count++;

        if (attack_Count == 3) // 3번 기본공격을 했다면
        {
            List<GameObject> other_TargetList = Util.Instance.FindNearestObjectsByTag(champ.cur_Target, "Enemy");

            int listCount = 0;
            foreach (GameObject obj in other_TargetList)
            {
                obj.GetComponent<ChampionData>().Damaged(70f, false); // 마법 데미지를 입음.
                Debug.Log("스태틱으로 데미지 입은애 : " + obj.name);
                listCount++;

                if (listCount >= 4) // 근처 4명까지 데미지를 입음
                    break;
            }
            attack_Count = 0;
        }
    }

}
