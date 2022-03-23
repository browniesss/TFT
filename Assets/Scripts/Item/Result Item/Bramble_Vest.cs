using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bramble_Vest : ItemInfo
{
    bool isCooldown = false;  // ���ظ� ������ ��Ÿ��
                              // ���� ����  : ġ��Ÿ ���ظ� �Ծ��� ��� ġ��Ÿ ���ظ� ����, �⺻���ݿ� ���� ��� �ֺ� ���鿡�� ���ظ� ����(2.5�ʸ��� �ѹ�)
    public override void Item_Damaged_Act(ChampionData champ)
    {
        if(!isCooldown) // ��Ÿ������ �ƴ϶��
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
