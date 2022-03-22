using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twistedfate : ChampionData
{
    [SerializeField]
    private Transform bullet_Pos;
    [SerializeField]
    private Transform[] bullet_Dir_Pos;
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

        transform.rotation = Quaternion.LookRotation(cur_Target.transform.position - this.transform.position);

        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = GameManager.Resource.Instantiate("Bullets/Graves_Bullet", this.transform);

            bullet.GetComponent<Bullet>().Bullet_Init(false, false, bullet_Dir_Pos[i].position);
            bullet.transform.position = bullet_Pos.position;
        }

        MP += 10; // ���������� ���� 10ȸ��

        if (!twin_Shot_Check)
            SynergyManager.Instance.Attack_Act();
        else
            twin_Shot_Check = false;

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
        }
    }

    Academy academy;
    Twinshot twinShot;
    public override void Champ_Synergy_Init()
    {
        academy = new Academy();
        academy.Synergy_Init();

        twinShot = new Twinshot();
        twinShot.Synergy_Init();

        Synergys.Add(academy);
        Synergys.Add(twinShot);
    }
}
