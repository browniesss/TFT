using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poppy : ChampionData
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

        Target_Check();

        Move();

        if (Input.GetKeyDown(KeyCode.F8))
            Damaged(5);
    }

    public override void Damaged(float damage)
    {
        Debug.Log(this.name + damage);

        MP += 5; // �ǰ� �� ���� 5ȹ��

        Active_Skill();
    }

    public override void Attack()
    {
        if (!target_Set) // Ÿ���� ������ ���°� �ƴ϶�� ����
            return;

        cur_Target.GetComponent<ChampionData>().Damaged(Damage);

        MP += 10; // ���������� ���� 10ȸ��

        Active_Skill();
    }


    void Active_Skill() // ��ų �ߵ�
    {
        if (MP >= MaxMP) // ������ ���� ����
        {
            MP = 0;

            isStun = false;

            //cur_Target.GetComponent<ChampionData>().Damaged(Damage * 2);

            animator.SetBool("isSkill", true);
        }
    }




    public override void Champ_Synergy_Init()
    {

    }
}