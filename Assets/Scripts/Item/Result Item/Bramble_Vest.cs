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

            GameObject shock_Wave = GameManager.Resource.Instantiate("Item/Shock_Wave", champ.transform);

            StartCoroutine(shockWave_Destroy_Coroutine(shock_Wave));
        }
    }

    IEnumerator coolDown_Coroutine()
    {
        yield return new WaitForSeconds(2.5f);

        isCooldown = false;
    }

    IEnumerator shockWave_Destroy_Coroutine(GameObject go)
    {
        yield return new WaitForSeconds(0.25f);

        GameManager.Resource.Destroy(go);
    }
}
