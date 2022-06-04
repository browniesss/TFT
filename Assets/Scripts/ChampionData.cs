using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class ChampionData : MonoBehaviour
{
    [Header("Charatcer Status")]
    public float Origin_MaxHP; // ���� ���� �� ������ �ִ�ü��

    public float Shield; // ��ȣ��

    public float MaxHP; // ü��
    [SerializeField]
    protected float HP; // ü��
    [SerializeField]
    protected int MaxMP; // ����
    public int MP; // ����
    public float Origin_Damage; // ���� ���� �� ������ ���ݷ�
    public float Damage; // ������ �̿��� ���ݷ�

    public float Origin_Ability_Power; // ���� ���� �� ������ �ֹ���
    public float Ability_Power; // �ֹ���
    public float Origin_Attack_Delay; // ���� ���� �� ������ ���ݼӵ�
    public float Attack_Delay; // ���ݼӵ�
    public float Critical_Chance; // ġ��Ÿ Ȯ��
    public float Critical_Damage; // ġ��Ÿ ������

    [SerializeField]
    protected int Armor; // ����
    [SerializeField]
    protected int Magic_Resistance; // ���� ���׷�
    [SerializeField]
    protected int Speed; // �̵� �ӵ�
    [SerializeField]
    public int Attack_Range; // �����Ÿ�

    public int[] Skill_Damage; // ��ų ������

    public int Champion_Level; // è�Ǿ� ����(��)
    public int Champion_Code; // è�Ǿ� �ڵ�

    #region ������ ���� ������
    public List<ItemInfo> itemList = new List<ItemInfo>(); // ���� ������ 3������ ����
    public int have_Item_Count; // ������ ������ ��

    public float item_Add_Hp; // ���������� �߰��� ü��
    public float item_Add_Ap; // ���������� �߰��� �ֹ���
    public float item_Add_Damage; // ���������� �߰��� ���ݷ�
    public float item_Add_Attack_Delay; // ���������� �߰��� ���ݼӵ�
    public int item_Add_Armor; // ���������� �߰��� ����
    public int item_Add_Magic_Resistance; // ���������� �߰��� ���� ���׷�
    public float item_Add_Critical_Chance; // ���������� �߰��� ġ��Ÿ Ȯ��
    public float item_Add_Critical_Damage; // ���������� �߰��� ġ��Ÿ ���ط�
    #endregion

    public float get_Pysical_Attack; // ���� �ֱ� ���� ���� ���� ���ط� ����
    public float get_Magic_Attack; // ���� �ֱ� ���� ���� ���� ���ط� ����

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
    [Header("Character Targeted Count")]
    public int targeted_Count;
    [Header("Current Tile")]
    public Tile cur_Tile; // ���� Ÿ��

    [Header("Synergy Using")]
    public bool twin_Shot_Check; // �ֹ��� ���� ������ �ߴ��� üũ

    public virtual (bool type, float damage) Damaged(float damage, bool attack_Type) // attack_Type = ����, ������������ �Ǻ� true = ����, false = ����
    {
        float result_Damage = 0;

        if (attack_Type) // ���� �����ϰ�� 
            result_Damage = (100.0f / (100 + Armor)) * damage;
        else // ���� ������ ���
            result_Damage = (100.0f / (100 + Magic_Resistance)) * damage;

        //Debug.Log(result_Damage + "����� ������");

        //Debug.Log(this.name + " " + damage);

        MP += 5; // �ǰ� �� ���� 5ȹ��

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

    public virtual void Item_Equip(ItemInfo item)
    {
        Debug.Log("������ ����");
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

        // ����� �Դٸ� ���� foreach ������ return�� �ȵƴٴ� �ǹ� - ���� �������� �ȵ�� �־���
        itemList.Add(item);

        Item_Effect_Renew();
    }

    void Item_Effect_Renew() // ������ ȿ�� ���� ( ���� ���� �ÿ��� ȣ��ó�� �س��ƾ� �� ) 
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
    protected virtual void Item_UI_Position_Set() // ������ UI ��ġ �缳��
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
    void Item_Show_Renew() // ������ UI ����
    {
        int item_Count = 0;

        foreach (GameObject item_Image in item_UI_List)
        {
            item_Image.GetComponent<SpriteRenderer>().sprite = null;

            GameManager.Resource.Destroy(item_Image);
        }

        item_UI_List.Clear(); // ����Ʈ �ʱ�ȭ

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
    public virtual void Target_Check() // Ÿ���� üũ ���ִ� �Լ�.
    {
        if (cur_Target != null)
        {
            float distance = Vector3.Distance(cur_Target.transform.position, transform.position);

            if (Mathf.Abs(distance) <= Attack_Range && !target_Set) // �����Ÿ� �� �����ߴٸ�
            {
                target_Set = true; // Ÿ�� ����
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

    public virtual void Champion_Info_Init() // ������ �� ���� �ʱ�ȭ
    {
        Origin_MaxHP = Origin_MaxHP * Mathf.Pow(1.8f, Champion_Level);
        MaxHP = Origin_MaxHP + item_Add_Hp;
        HP = MaxHP;
        Origin_Damage = Origin_Damage * Mathf.Pow(1.8f, Champion_Level);
        Damage = Origin_Damage + item_Add_Damage;
        Origin_Ability_Power = 100f;
        Ability_Power = Origin_Ability_Power + item_Add_Ap;
    }

    public virtual void Champion_Info_Reset() // ���� ����� ���� �ʱ�ȭ
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

    public virtual void Champion_Restore_HP(float heal_Amount) // ü�� ȸ�� �Լ�
    {
        if (HP + heal_Amount <= MaxHP)
            HP += heal_Amount;
        else
            HP = MaxHP;
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
