using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinshot : Synergy
{
    private int[] init_Power; // ó�� �߰��Ǵ� �ɷ�ġ
    private int[] act_chance; // ������ ���� Ȯ��

    void Start()
    {
        Synergy_Init();
    }

    public override void Synergy_Init()
    {
        synergy_Name = "�ֹ���";
        synergy_Level = 0;
        synergy_MaxLevel = 3;
        synergy_Code = 5;
        needChamp_Count = new int[4];
        init_Power = new int[4];
        act_chance = new int[4];

        needChamp_Count[1] = 2;
        needChamp_Count[2] = 4;
        needChamp_Count[3] = 6;

        init_Power[0] = 0;
        init_Power[1] = 5;
        init_Power[2] = 40;
        init_Power[3] = 80;

        act_chance[1] = 0;
        act_chance[0] = 40;
        act_chance[2] = 70;
        act_chance[3] = 100;
    }

    public override void Synergy_Battle_Init(ChampionData champ) // ���� ���� �� ��ī���� ȿ��
    {
        Debug.Log("�ֹ��� Init �Լ�");
        champ.Damage += init_Power[synergy_Level];
        champ.Ability_Power += init_Power[synergy_Level];
    }

    public override void Synergy_Attack_Act(ChampionData champ)
    {
        int randVal = Random.Range(1, 101); // 1 ���� 100���� �������� ���� ����

        Debug.Log("�ֹ��� ���ݷ��� " + randVal);
        if (randVal < act_chance[synergy_Level]) // ���� �ó��� ������ Ȯ������ ���ٸ� �ߵ�
        {
            Debug.Log("�ֹ��� ���ݹߵ� ");
            champ.GetComponent<Animator>().Play("Attack", -1, 0f);
            champ.twin_Shot_Check = true;
        }
    }

    void Update()
    {

    }
}
