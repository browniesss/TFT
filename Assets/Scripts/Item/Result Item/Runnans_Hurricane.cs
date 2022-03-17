using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runnans_Hurricane : ItemInfo
{
    // �糭�� �㸮���� : �⺻ ���ݽ� �ֺ��� �� �Ѹ��� �߰��� 70% �� �������� ����.

    public override void Item_Attack_Act(ChampionData champ, bool attack_Type)
    {
        // ���� Ÿ�ٿ��� ���� ����� ���� ã�ƿ�.
        GameObject other_Target = Util.Instance.FindNearestObjectByTag(champ.cur_Target, "Enemy");

        if (other_Target != null) // �ٸ� Ÿ���� �ִٸ�
        {
            GameObject bullet = GameManager.Resource.Instantiate("Bullets/Runnan_Bullet", champ.transform);

            bullet.GetComponent<Bullet>().Bullet_Init(false, false, other_Target, champ.Damage + champ.item_Add_Damage);
            bullet.transform.position = champ.transform.position;
        }
    }
}
