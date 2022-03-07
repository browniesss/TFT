using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ChampionData : MonoBehaviour
{
    [Header("Charatcer Status")]
    public float Origin_MaxHP; // 전투 시작 시 저장할 최대체력

    public float Shield; // 보호막
    [SerializeField]
    protected float MaxHP; // 체력
    [SerializeField]
    protected float HP; // 체력
    [SerializeField]
    protected int MaxMP; // 마나
    [SerializeField]
    protected int MP; // 마나
    public float Origin_Damage; // 전투 시작 시 저장할 공격력
    public float Damage; // 전투에 이용할 공격력
    public float Ability_Power; // 주문력
    [SerializeField]
    protected float Attack_Delay; // 공격속도
    [SerializeField]
    protected int Armor; // 방어력
    [SerializeField]
    protected int Magic_Resistance; // 마법 저항력
    [SerializeField]
    protected int Speed; // 이동 속도
    [SerializeField]
    protected int Attack_Range; // 사정거리

    public int[] Skill_Damage; // 스킬 데미지

    public int Champion_Level; // 챔피언 레벨(성)
    public int Champion_Code; // 챔피언 코드

    public ItemInfo[] itemArr = new ItemInfo[3]; // 보유 아이템 3개까지 가능
    public int have_Item_Count; // 보유한 아이템 수

    public float item_Add_Hp; // 아이템으로 추가된 체력
    public float item_Add_Ap; // 아이템으로 추가된 주문력
    public float item_Add_Damage; // 아이템으로 추가된 공격력
    public float item_Add_Attack_Delay; // 아이템으로 추가된 공격속도
    public int item_Add_Armor; // 아이템으로 추가된 방어력
    public int item_Add_Magic_Resistance; // 아이템으로 추가된 마법 저항력

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
    [Header("Current Tile")]
    public Tile cur_Tile; // 현재 타일

    [Header("Synergy Using")]
    public bool twin_Shot_Check; // 쌍발총 연속 공격을 했는지 체크

    public abstract void Damaged(float damage);

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

    protected Animator animator;
    public virtual void Target_Check() // 타겟을 체크 해주는 함수.
    {
        float distance = Vector3.Distance(cur_Target.transform.position, transform.position);

        if (Mathf.Abs(distance) <= Attack_Range && !target_Set) // 사정거리 내 진입했다면
        {
            target_Set = true; // 타겟 지정
            animator.SetBool("isAttack", true);

        }
        else if (Mathf.Abs(distance) > Attack_Range)
        {
            animator.SetBool("isAttack", false);
            target_Set = false;
        }
    }

    public virtual void Target_Find()
    {
        if (target_Set)
            return;

        if (this.gameObject.tag == "MyTeam")
            cur_Target = Util.Instance.FindNearestObjectByTag("Enemy");
        else
            cur_Target = Util.Instance.FindNearestObjectByTag("MyTeam");
    }

    public virtual void Champion_Info_Init() // 레벨업 시 정보 초기화
    {
        Origin_MaxHP = Origin_MaxHP * Mathf.Pow(1.8f, Champion_Level);
        MaxHP = Origin_MaxHP;
        HP = Origin_MaxHP;
        Origin_Damage = Origin_Damage * Mathf.Pow(1.8f, Champion_Level);
        Damage = Origin_Damage;
    }

    public virtual void Champion_Info_Reset() // 전투 종료시 정보 초기화
    {
        MaxHP = Origin_MaxHP;
        HP = Origin_MaxHP;
        Damage = Origin_Damage;
        Ability_Power = 100f;
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
