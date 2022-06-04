using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bramble_Vest : ItemInfo
{
    bool isCooldown = false;  // ���ظ� ������ ��Ÿ��
                              // ���� ����  : ġ��Ÿ ���ظ� �Ծ��� ��� ġ��Ÿ ���ظ� ����, �⺻���ݿ� ���� ��� �ֺ� ���鿡�� ���ظ� ����(3ȸ �ǰݸ��� �ѹ�)
    int attacked_Count = 0;

    public override void Item_Init(ChampionData champ)
    {
        isCooldown = false;
        attacked_Count = 0;
    }


    public override void Item_Damaged_Act(ChampionData champ)
    {
        Debug.Log("��������" + "������� :" + isCooldown);

        if (!isCooldown) // ��Ÿ������ �ƴ϶��
        {
            Debug.Log("��ٿ� �ƴ�");
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
