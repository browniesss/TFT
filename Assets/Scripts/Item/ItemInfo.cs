using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    #region 아이템 정보
    public int item_Code; // 아이템 코드
    [SerializeField]
    protected string item_Name; // 아이템 이름
    [SerializeField]
    protected float item_HP; // 아이템 추가 체력
    [SerializeField]
    protected int item_MP; // 아이템 추가 마나
    [SerializeField]
    protected float item_Damage; // 아이템 추가 데미지 
    [SerializeField]
    protected float item_AP; // 아이템 추가 주문력
    [SerializeField]
    protected float item_Attack_Delay; // 아이템 추가 공격속도
    [SerializeField]
    protected int item_Armor; // 아이템 추가 방어력
    [SerializeField]
    protected int item_Magic_Resistance; // 아이템 추가 마법 저항력
    [SerializeField]
    protected Material item_Material; // 아이템 매테리얼
    [SerializeField]
    protected Sprite item_Sprite; // 아이템 스프라이트

    public bool is_Raw_Item; // 재료 아이템인지 판별 false = 완성 , true = 재료
    #endregion 

    public void Add_Status(ChampionData champ) // 캐릭터의 아이템 능력치를 올려주는 함수
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
