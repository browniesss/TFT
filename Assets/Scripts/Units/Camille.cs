using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camille : ChampionData
{

    public GameObject Skill_;
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
    }

    public override void Attack()
    {
        if (!target_Set) // Ÿ���� ������ ���°� �ƴ϶�� ����
            return;

        cur_Target.GetComponent<ChampionData>().Damaged(Damage, true);

        MP += 10; // ���������� ���� 10ȸ��

        Active_Skill();
    }

    protected override void Active_Skill() // ��ų �ߵ�
    {
        if (MP >= MaxMP) // ������ ���� ����
        {
            MP = 0;

            isStun = false;

            //cur_Target.GetComponent<ChampionData>().Damaged(Damage * 2);

            animator.SetBool("isSkill", true);

            Skill_.SetActive(true);

            Debug.Log("ī�н�ų��");
        }
    }

    public override void Skill_AnimationOff()
    {
        Debug.Log("ī�н�ų����");
        animator.SetBool("isSkill", false);
        Skill_.SetActive(false);

    }

    public override void Champ_Synergy_Init()
    {

    }
}
