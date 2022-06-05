using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frozen_Heart : ItemInfo
{
    public override void Item_Constant_Act(ChampionData champ)
    {
        List<GameObject> other_TargetList;
        if (champ.CompareTag("MyTeam"))
            other_TargetList = Util.Instance.FindNearestObjectsByTag(champ.cur_Target, "Enemy");
        else
            other_TargetList = Util.Instance.FindNearestObjectsByTag(champ.cur_Target, "MyTeam");

        foreach (var obj in other_TargetList)
        {
            float distance = Vector3.Distance(obj.transform.position, champ.transform.position);

            ChampionData champion_Data = obj.GetComponent<ChampionData>();
            if (Mathf.Abs(distance) <= 390.0f)
            {


                champion_Data.Attack_Delay -= (champion_Data.Attack_Delay * 0.35f);
            }
            else
            {
                champion_Data.Attack_Delay = champion_Data.Origin_Attack_Delay * (1f + champion_Data.item_Add_Attack_Delay * 0.01f);
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
