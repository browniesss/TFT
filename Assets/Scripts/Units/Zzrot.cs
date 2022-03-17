using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zzrot : ChampionData
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

        Item_UI_Position_Set();
    }

    public override void Attack()
    {
        if (!target_Set) // 타겟이 지정된 상태가 아니라면 리턴
            return;

        var result = cur_Target.GetComponent<ChampionData>().Damaged(Damage, true);
    }

    protected override void Active_Skill() // 스킬 발동
    {
    }

    public override void Champ_Synergy_Init()
    {

    }
}
