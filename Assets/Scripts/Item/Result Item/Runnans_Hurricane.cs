using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runnans_Hurricane : ItemInfo
{
    // 루난의 허리케인 : 기본 공격시 주변의 적 한명에게 추가로 70% 의 데미지를 입힘.

    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        // 현재 타겟에서 가장 가까운 적을 찾아옴.
        GameObject other_Target = Util.Instance.FindNearestObjectByTag(champ.cur_Target, "Enemy");

        if (other_Target != null) // 다른 타겟이 있다면
        {
            GameObject bullet = GameManager.Resource.Instantiate("Bullets/Runnan_Bullet", champ.transform);

            bullet.GetComponent<Bullet>().Bullet_Init(false, false, other_Target, champ.Damage + champ.item_Add_Damage);
            bullet.transform.position = champ.transform.position;
        }
    }
}
