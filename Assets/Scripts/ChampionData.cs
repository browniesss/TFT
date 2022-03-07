using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ChampionData : MonoBehaviour
{
    [Header("Charatcer Status")]
    public float Origin_MaxHP; // ���� ���� �� ������ �ִ�ü��

    public float Shield; // ��ȣ��
    [SerializeField]
    protected float MaxHP; // ü��
    [SerializeField]
    protected float HP; // ü��
    [SerializeField]
    protected int MaxMP; // ����
    [SerializeField]
    protected int MP; // ����
    public float Origin_Damage; // ���� ���� �� ������ ���ݷ�
    public float Damage; // ������ �̿��� ���ݷ�
    public float Ability_Power; // �ֹ���
    [SerializeField]
    protected float Attack_Delay; // ���ݼӵ�
    [SerializeField]
    protected int Armor; // ����
    [SerializeField]
    protected int Magic_Resistance; // ���� ���׷�
    [SerializeField]
    protected int Speed; // �̵� �ӵ�
    [SerializeField]
    protected int Attack_Range; // �����Ÿ�

    public int[] Skill_Damage; // ��ų ������

    public int Champion_Level; // è�Ǿ� ����(��)
    public int Champion_Code; // è�Ǿ� �ڵ�

    public ItemInfo[] itemArr = new ItemInfo[3]; // ���� ������ 3������ ����
    public int have_Item_Count; // ������ ������ ��

    public float item_Add_Hp; // ���������� �߰��� ü��
    public float item_Add_Ap; // ���������� �߰��� �ֹ���
    public float item_Add_Damage; // ���������� �߰��� ���ݷ�
    public float item_Add_Attack_Delay; // ���������� �߰��� ���ݼӵ�
    public int item_Add_Armor; // ���������� �߰��� ����
    public int item_Add_Magic_Resistance; // ���������� �߰��� ���� ���׷�

    // �ó���
    public List<Synergy> Synergys = new List<Synergy>();

    [Header("Character State")]
    [SerializeField]
    protected bool target_Set; // true ��� Ÿ�ٿ� �پ ���� ��
    [SerializeField]
    protected bool isAttack; // ���� ������ ����
    public bool isStun; // CC�⿡ �����ִ��� ���� 

    [Header("Character Target")]
    public GameObject cur_Target; // ���� Ÿ��
    [Header("Current Tile")]
    public Tile cur_Tile; // ���� Ÿ��

    [Header("Synergy Using")]
    public bool twin_Shot_Check; // �ֹ��� ���� ������ �ߴ��� üũ

    public abstract void Damaged(float damage);

    public abstract void Champ_Synergy_Init();

    public abstract void Attack();

    public virtual void Skill()
    {

    }

    public virtual void Move()
    {
        if (cur_Target == null || target_Set) // Ÿ���� ���ų� Ÿ���� ������ �������ϰ��
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
    public virtual void Target_Check() // Ÿ���� üũ ���ִ� �Լ�.
    {
        float distance = Vector3.Distance(cur_Target.transform.position, transform.position);

        if (Mathf.Abs(distance) <= Attack_Range && !target_Set) // �����Ÿ� �� �����ߴٸ�
        {
            target_Set = true; // Ÿ�� ����
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

    public virtual void Champion_Info_Init() // ������ �� ���� �ʱ�ȭ
    {
        Origin_MaxHP = Origin_MaxHP * Mathf.Pow(1.8f, Champion_Level);
        MaxHP = Origin_MaxHP;
        HP = Origin_MaxHP;
        Origin_Damage = Origin_Damage * Mathf.Pow(1.8f, Champion_Level);
        Damage = Origin_Damage;
    }

    public virtual void Champion_Info_Reset() // ���� ����� ���� �ʱ�ȭ
    {
        MaxHP = Origin_MaxHP;
        HP = Origin_MaxHP;
        Damage = Origin_Damage;
        Ability_Power = 100f;
    }

    #region ���콺 �巡��
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
