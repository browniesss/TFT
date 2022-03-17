using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garen : ChampionData
{
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        Champ_Synergy_Init();

        animator = GetComponent<Animator>();

        animator.SetFloat("Attack_Speed", Attack_Delay);
    }

    void Update()
    {
        Target_Find();

        //Target_Check();

        Move();

        Item_UI_Position_Set();

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            foreach (ItemInfo item in itemList)
                item.Item_Battle_Init(this);
        }    
    }

    public override void Attack()
    {
        if (!target_Set) // Ÿ���� ������ ���°� �ƴ϶�� ����
            return;

        var result = cur_Target.GetComponent<ChampionData>().Damaged(Damage, true);

        if (result.type) // type �� true�� ��� = ��������
            get_Pysical_Attack = result.damage;
        else // type �� false �� ��� = ���� ����
            get_Magic_Attack = result.damage;
        Debug.Log(get_Magic_Attack + " ���� ���� < " + get_Pysical_Attack + "���� ���� < ");
        MP += 10; // ���������� ���� 10ȸ��

        foreach (ItemInfo item in itemList)
        {
            item.Item_Attack_Act(this, true);
        }

        Active_Skill();
    }

    protected override void Active_Skill() // ��ų �ߵ�
    {
        if (MP >= MaxMP) // ������ ���� ����
        {
            MP = 0;

            isStun = false;

            //cur_Target.GetComponent<ChampionData>().Damaged(Damage * 2);
            foreach (ItemInfo item in itemList)
            {
                item.Item_Skill_Act(this, true);
            }

            animator.SetBool("isSkill", true);
        }
    }

    Academy academy;
    Protector protector;
    public override void Champ_Synergy_Init()
    {
        academy = new Academy();
        academy.Synergy_Init();

        protector = new Protector();
        protector.Synergy_Init();

        Synergys.Add(academy);
        Synergys.Add(protector);
    }
}
