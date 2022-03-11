using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ezreal : ChampionData
{
    [SerializeField]
    private Transform bullet_Pos;
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

        transform.rotation = Quaternion.LookRotation(cur_Target.transform.position - this.transform.position);

        GameObject bullet = GameManager.Resource.Instantiate("Bullets/Ezreal_Bullet", this.transform);

        bullet.GetComponent<Bullet>().Bullet_Init(true, false) ;
        bullet.transform.position = bullet_Pos.position;

        MP += 10;

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

    public void Skill_Bullet_Shoot()
    {
        GameObject bullet = GameManager.Resource.Instantiate("Bullets/Ezreal_Bullet", this.transform);

        bullet.GetComponent<Bullet>().Bullet_Init(true, true);
        bullet.transform.position = bullet_Pos.position;
    }

    public override void Champ_Synergy_Init()
    {
        
    }
}
