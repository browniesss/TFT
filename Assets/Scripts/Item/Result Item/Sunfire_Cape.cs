using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunfire_Cape : ItemInfo
{
    [SerializeField]
    bool isCooldown = false;  // ���ظ� ������ ��Ÿ��
                              // �¾�Ҳɸ��� 
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
        if (!isCooldown) // ��Ÿ������ �ƴ϶��
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
                    Debug.Log("�ºҸ��ߵ���");
                    if (!save_Target.Contains(obj))
                    {
                        Debug.Log("�ºҸ��ߵ�");
                        champion_Data.isHealReduce = true;

                        GameObject prefab_flame = Resources.Load("Prefabs/Bullets/Flame_Particle") as GameObject;
                        Debug.Log("�ºҸ������շε�");
                        GameObject flame = GameObject.Instantiate(prefab_flame, obj.transform);
                        Debug.Log("�ºҸ������ջ���" + flame.transform.position + "<��ǥ");
                        flame.GetComponent<Flame_Particle>().target_Champ = obj.gameObject;
                        Debug.Log("�ºҸ�Ÿ�ټ���");

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
