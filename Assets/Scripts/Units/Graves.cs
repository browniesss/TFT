using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graves : ChampionData
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

        if (Input.GetKeyDown(KeyCode.F8))
            Attack();
    }

    public override void Damaged(float damage)
    {
        Debug.Log(this.name + damage);

        MP += 5; // 피격 시 마나 5획득

        Active_Skill();
    }

    public override void Attack()
    {
        if (!target_Set) // 타겟이 지정된 상태가 아니라면 리턴
            return;

        cur_Target.GetComponent<ChampionData>().Damaged(Damage);

        transform.rotation = Quaternion.LookRotation(cur_Target.transform.position - this.transform.position);

        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = GameManager.Resource.Instantiate("Bullets/Graves_Bullet", this.transform);

            bullet.GetComponent<Bullet>().Bullet_Init(false, bullet_Dir_Pos[i].position);
            bullet.transform.position = bullet_Pos.position;
        }

        MP += 10; // 때릴때마다 마나 10회복

        if (!twin_Shot_Check)
            SynergyManager.Instance.Attack_Act();
        else
            twin_Shot_Check = false;

        Active_Skill();
    }

    void Active_Skill() // 스킬 발동
    {
        if (MP >= MaxMP) // 마나가 전부 차면
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
