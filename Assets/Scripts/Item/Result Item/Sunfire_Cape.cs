using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunfire_Cape : ItemInfo
{
    [SerializeField]
    bool isCooldown = false;  // 피해를 입히는 쿨타임
                              // 태양불꽃망토 
    int attacked_Count = 0;

    [SerializeField]
    List<GameObject> save_Target = new List<GameObject>();

    public override void Item_Init(ChampionData champ)
    {
        isCooldown = false;
        attacked_Count = 0;
        save_Target.Clear();
    }

    public override void Item_Constant_Act(ChampionData champ)
    {
        if (!isCooldown) // 쿨타임중이 아니라면
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
                    Debug.Log("태불망발동전");
                    if (!save_Target.Contains(obj))
                    {
                        Debug.Log("태불망발동");
                        champion_Data.isHealReduce = true;

                        GameObject prefab_flame = Resources.Load("Prefabs/Bullets/Flame_Particle") as GameObject;
                        Debug.Log("태불망프리팹로드");
                        GameObject flame = GameObject.Instantiate(prefab_flame, obj.transform);
                        Debug.Log("태불망프리팹생성" + flame.transform.position + "<좌표");
                        flame.GetComponent<Flame_Particle>().target_Champ = obj.gameObject;
                        Debug.Log("태불망타겟설정");

                        save_Target.Add(obj);

                        isCooldown = true;
                    }
                }
            }
        }
        else
        {
            attacked_Count++;

            if (attacked_Count >= 3)
                isCooldown = false;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
