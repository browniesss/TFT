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
        if (!target_Set) // 타겟이 지정된 상태가 아니라면 리턴
            return;

        var result = cur_Target.GetComponent<ChampionData>().Damaged(Damage, true);

        if (result.type) // type 이 true인 경우 = 물리피해
            get_Pysical_Attack = result.damage;
        else // type 이 false 인 경우 = 마법 피해
            get_Magic_Attack = result.damage;
        Debug.Log(get_Magic_Attack + " 마법 피해 < " + get_Pysical_Attack + "물리 피해 < ");
        MP += 10; // 때릴때마다 마나 10회복

        foreach (ItemInfo item in itemList)
        {
            item.Item_Attack_Act(this, true);
        }

        Active_Skill();
    }

    protected override void Active_Skill() // 스킬 발동
    {
        if (MP >= MaxMP) // 마나가 전부 차면
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
