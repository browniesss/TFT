using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class ChampionData : MonoBehaviour
{
    [Header("Charatcer Status")]
    public float Origin_MaxHP; // 전투 시작 시 저장할 최대체력

    public float Shield; // 보호막

    public float MaxHP; // 체력
    [SerializeField]
    protected float HP; // 체력
    [SerializeField]
    protected int MaxMP; // 마나
    public int MP; // 마나
    public float Origin_Damage; // 전투 시작 시 저장할 공격력
    public float Damage; // 전투에 이용할 공격력

    public float Origin_Ability_Power; // 전투 시작 시 저장할 주문력
    public float Ability_Power; // 주문력
    public float Origin_Attack_Delay; // 전투 시작 시 저장할 공격속도
    public float Attack_Delay; // 공격속도
    public float Critical_Chance; // 치명타 확률
    public float Critical_Damage; // 치명타 데미지

    [SerializeField]
    protected int Armor; // 방어력
    [SerializeField]
    protected int Magic_Resistance; // 마법 저항력
    [SerializeField]
    protected int Speed; // 이동 속도
    [SerializeField]
    public int Attack_Range; // 사정거리

    public int[] Skill_Damage; // 스킬 데미지

    public int Champion_Level; // 챔피언 레벨(성)
    public int Champion_Code; // 챔피언 코드

    #region 아이템 관련 변수들
    public List<ItemInfo> itemList = new List<ItemInfo>(); // 보유 아이템 3개까지 가능
    public int have_Item_Count; // 보유한 아이템 수

    public float item_Add_Hp; // 아이템으로 추가된 체력
    public float item_Add_Ap; // 아이템으로 추가된 주문력
    public float item_Add_Damage; // 아이템으로 추가된 공격력
    public float item_Add_Attack_Delay; // 아이템으로 추가된 공격속도
    public int item_Add_Armor; // 아이템으로 추가된 방어력
    public int item_Add_Magic_Resistance; // 아이템으로 추가된 마법 저항력
    public float item_Add_Critical_Chance; // 아이템으로 추가된 치명타 확률
    public float item_Add_Critical_Damage; // 아이템으로 추가된 치명타 피해량
    #endregion

    public float get_Pysical_Attack; // 가장 최근 물리 공격 입힌 피해량 저장
    public float get_Magic_Attack; // 가장 최근 마법 공격 입힌 피해량 저장

    // 시너지
    public List<Synergy> Synergys = new List<Synergy>();

    [Header("Character State")]
    [SerializeField]
    protected bool target_Set; // true 라면 타겟에 붙어서 공격 중
    [SerializeField]
    protected bool isAttack; // 공격 중인지 여부
    public bool isStun; // CC기에 당해있는지 여부 

    [Header("Character Target")]
    public GameObject cur_Target; // 현재 타겟
    [Header("Character Targeted Count")]
    public int targeted_Count;
    [Header("Current Tile")]
    public Tile cur_Tile; // 현재 타일

    [Header("Synergy Using")]
    public bool twin_Shot_Check; // 쌍발총 연속 공격을 했는지 체크

    public virtual (bool type, float damage) Damaged(float damage, bool attack_Type) // attack_Type = 물리, 마법피해인지 판별 true = 물리, false = 마법
    {
        float result_Damage = 0;

        if (attack_Type) // 물리 피해일경우 
            result_Damage = (100.0f / (100 + Armor)) * damage;
        else // 마법 피해일 경우
            result_Damage = (100.0f / (100 + Magic_Resistance)) * damage;

        //Debug.Log(result_Damage + "계산후 데미지");

        //Debug.Log(this.name + " " + damage);

        MP += 5; // 피격 시 마나 5획득

        Active_Skill();

        foreach (ItemInfo item in itemList)
        {
            item.Item_Damaged_Act(this);
        }

        return (attack_Type, result_Damage);
    }

    protected virtual void Active_Skill() { }

    public abstract void Champ_Synergy_Init();

    public abstract void Attack();

    public virtual void Skill()
    {

    }

    public virtual void Move()
    {
        if (cur_Target == null || target_Set) // 타겟이 없거나 타겟이 지정돼 공격중일경우
        {
            animator.SetBool("isMove", false);
            return;
        }

        animator.SetBool("isMove", true);

        transform.position = Vector3.MoveTowards(transform.position, cur_Target.transform.position,
            Speed * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(cur_Target.transform.position - this.transform.position);
    }

    public virtual void Item_Equip(ItemInfo item)
    {
        Debug.Log("아이템 장착");
        foreach (ItemInfo temp_item in itemList)
        {
            if (temp_item.is_Raw_Item == true)
            {
                ItemInfo result_Item = ItemManager.Instance.Item_Combination(temp_item, item);

                itemList.Remove(temp_item);

                itemList.Add(result_Item);

                have_Item_Count--;

                Item_Effect_Renew();
                return;
            }
        }

        // 여기로 왔다면 위의 foreach 문에서 return이 안됐다는 의미 - 조합 아이템을 안들고 있었음
        itemList.Add(item);

        Item_Effect_Renew();
    }

    void Item_Effect_Renew() // 아이템 효과 갱신 ( 전투 종료 시에도 호출처리 해놓아야 함 ) 
    {
        item_Add_Hp = 0f;
        item_Add_Ap = 0f;
        item_Add_Damage = 0f;
        item_Add_Attack_Delay = 0f;
        item_Add_Armor = 0;
        item_Add_Magic_Resistance = 0;
        item_Add_Critical_Chance = 0f;
        item_Add_Critical_Damage = 0f;

        foreach (ItemInfo item in itemList)
        {
            //item.Initialize();
            item.Add_Status(this);
            item.Item_Init(this);
        }

        Item_Show_Renew();
    }

    public Vector3 offset = Vector3.zero;
    protected virtual void Item_UI_Position_Set() // 아이템 UI 위치 재설정
    {
        int item_Count = 0;

        foreach (GameObject item_Image in item_UI_List)
        {
            item_Image.transform.position = new Vector3(
          transform.position.x - 150f + item_Count * 45f,
          transform.position.y + 200f,
          transform.position.z);

            item_Count++;
        }
    }

    protected List<GameObject> item_UI_List = new List<GameObject>();
    void Item_Show_Renew() // 아이템 UI 갱신
    {
        int item_Count = 0;

        foreach (GameObject item_Image in item_UI_List)
        {
            item_Image.GetComponent<SpriteRenderer>().sprite = null;

            GameManager.Resource.Destroy(item_Image);
        }

        item_UI_List.Clear(); // 리스트 초기화

        foreach (ItemInfo item in itemList)
        {
            GameObject item_Image = GameManager.Resource.Instantiate("Item/Item_UI_Image");

            item_UI_List.Add(item_Image);

            item_Image.transform.position = new Vector3(
           transform.position.x - 150f + item_Count * 45f,
           transform.position.y + 300f,
           transform.position.z);

            item_Image.GetComponent<SpriteRenderer>().sprite = item.item_Sprite;
            item_Count++;
        }
    }

    public Animator animator;
    public virtual void Target_Check() // 타겟을 체크 해주는 함수.
    {
        if (cur_Target != null)
        {
            float distance = Vector3.Distance(cur_Target.transform.position, transform.position);

            if (Mathf.Abs(distance) <= Attack_Range && !target_Set) // 사정거리 내 진입했다면
            {
                target_Set = true; // 타겟 지정
                cur_Target.GetComponent<ChampionData>().targeted_Count++;
                animator.SetBool("isAttack", true);

            }
            else if (Mathf.Abs(distance) > Attack_Range)
            {
                animator.SetBool("isAttack", false);
                cur_Target.GetComponent<ChampionData>().targeted_Count--;
                target_Set = false;
            }
        }
    }

    public virtual void Target_Find()
    {
        if (target_Set)
            return;

        if (this.gameObject.CompareTag("MyTeam"))
            cur_Target = Util.Instance.FindNearestObjectByTag("Enemy");
        else
            cur_Target = Util.Instance.FindNearestObjectByTag("MyTeam");
    }

    public virtual void Champion_Info_Init() // 레벨업 시 정보 초기화
    {
        Origin_MaxHP = Origin_MaxHP * Mathf.Pow(1.8f, Champion_Level);
        MaxHP = Origin_MaxHP + item_Add_Hp;
        HP = MaxHP;
        Origin_Damage = Origin_Damage * Mathf.Pow(1.8f, Champion_Level);
        Damage = Origin_Damage + item_Add_Damage;
        Origin_Ability_Power = 100f;
        Ability_Power = Origin_Ability_Power + item_Add_Ap;
    }

    public virtual void Champion_Info_Reset() // 전투 종료시 정보 초기화
    {
        MaxHP = Origin_MaxHP + item_Add_Hp;
        HP = MaxHP;
        Damage = Origin_Damage + item_Add_Damage;
        Ability_Power = Origin_Ability_Power + item_Add_Ap;
        Attack_Delay = Origin_Attack_Delay * (1f + item_Add_Attack_Delay * 0.01f);
        Critical_Damage = 130f + item_Add_Critical_Damage;
        Critical_Chance = 25f + item_Add_Critical_Chance;
        animator.SetFloat("Attack_Speed", Attack_Delay);
    }

    public virtual void Champion_Restore_HP(float heal_Amount) // 체력 회복 함수
    {
        if (HP + heal_Amount <= MaxHP)
            HP += heal_Amount;
        else
            HP = MaxHP;
    }

    #region 마우스 드래그
    private Vector3 m_Offset;
    private float m_ZCoord;
    public Vector3 originalPos;
    void OnMouseDown()
    {
        originalPos = transform.position;

        m_ZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        m_Offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 tempVec = GetMouseWorldPosition() + m_Offset;

        transform.position = new Vector3(tempVec.x, 0, tempVec.z);
    }

    void OnMouseUp()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000, LayerMask.GetMask("Tile")))
        {
            hit.transform.GetComponent<Tile>().Tile_Check(this);
        }
        else
        {
            transform.position = originalPos;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = m_ZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    #endregion

    public virtual void Skill_AnimationOff()
    {
        animator.SetBool("isSkill", false);
    }
}
