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
    [SerializeField]
    protected Material item_Material; // ������ ���׸���
    [SerializeField]
    protected Sprite item_Sprite; // ������ ��������Ʈ

    public bool is_Raw_Item; // ��� ���������� �Ǻ� false = �ϼ� , true = ���
    #endregion 

    public void Add_Status(ChampionData champ) // ĳ������ ������ �ɷ�ġ�� �÷��ִ� �Լ�
    {
        champ.item_Add_Hp += item_HP;
        champ.MP += item_MP;
        champ.item_Add_Ap += item_AP;
        champ.item_Add_Damage += item_Damage;
        champ.item_Add_Attack_Delay += item_Attack_Delay;
        champ.item_Add_Armor += item_Armor;
        champ.item_Add_Magic_Resistance += item_Magic_Resistance;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
