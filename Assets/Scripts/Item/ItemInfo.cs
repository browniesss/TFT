using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    #region ������ ����
    public int item_Code; // ������ �ڵ�
    [SerializeField]
    protected string item_Name; // ������ �̸�
    [SerializeField]
    protected float item_HP; // ������ �߰� ü��
    [SerializeField]
    protected int item_MP; // ������ �߰� ����
    [SerializeField]
    protected float item_Damage; // ������ �߰� ������ 
    [SerializeField]
    protected float item_AP; // ������ �߰� �ֹ���
    [SerializeField]
    protected float item_Attack_Delay; // ������ �߰� ���ݼӵ�
    [SerializeField]
    protected int item_Armor; // ������ �߰� ����
    [SerializeField]
    protected int item_Magic_Resistance; // ������ �߰� ���� ���׷�

    public Material item_Material; // ������ ���׸���

    public Sprite item_Sprite; // ������ ��������Ʈ

    public bool is_Raw_Item; // ��� ���������� �Ǻ� false = �ϼ� , true = ���
    #endregion 

    public virtual void Add_Status(ChampionData champ) // ĳ������ ������ �ɷ�ġ�� �÷��ִ� �Լ�
    {
        champ.item_Add_Hp += item_HP;
        champ.MP += item_MP;
        champ.item_Add_Ap += item_AP;
        champ.item_Add_Damage += item_Damage;
        champ.item_Add_Attack_Delay += item_Attack_Delay;
        champ.item_Add_Armor += item_Armor;
        champ.item_Add_Magic_Resistance += item_Magic_Resistance;
    }

    public virtual void Item_Init(ChampionData champ) { } // ���� �� �ߵ��Ǵ� ������ ȿ��

    public virtual void Item_Battle_Init(ChampionData champ) { } // ���� ���� �� �ߵ��Ǵ� ������ ȿ��

    public virtual void Item_Battle_End(ChampionData champ) { } // ���� ���� �� �ߵ��Ǵ� ������ ȿ��

    public virtual void Item_Skill_Act(ChampionData champ, bool attack_Type) { } // ��ų ��� �� �ߵ��Ǵ� ������ ȿ��

    public virtual void Item_Attack_Act(ChampionData champ, bool attack_Type) { } // ���� �� �ߵ��Ǵ� ������ ȿ��

    public virtual void Item_Damaged_Act(ChampionData champ) { } // �ǰ� �� �ߵ��Ǵ� ������ ȿ��

    public virtual void Item_Death_Act(ChampionData champ) { } // ��� �� �ߵ��Ǵ� ������ ȿ��

    void Start()
    {

    }

    void Update()
    {

    }
}
