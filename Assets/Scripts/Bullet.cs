using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private ChampionData parentChampion;
    [SerializeField]
    private bool isCollision = false;
    [SerializeField]
    private bool isSkill = false;

    private bool direct_Attack; // 총알이 데미지를 주는지 안주는지 판별할 변수  true = 직접
    void Start()
    {
    }

    public void Bullet_Init(bool truth, bool skill_truth)
    {
        direct_Attack = truth;
        isCollision = false;
        isSkill = skill_truth;
        parentChampion = transform.parent.GetComponent<ChampionData>();
    }

    Vector3 bullet_Target; // 총알의 직접 타겟 좌표
    public void Bullet_Init(bool truth, bool skill_truth, Vector3 targetPos)
    {
        bullet_Target = targetPos;
        direct_Attack = truth;
        isCollision = false;
        isSkill = skill_truth;
        parentChampion = transform.parent.GetComponent<ChampionData>();

        StartCoroutine(Destroy_Coroutine());
    }

    GameObject bullet_Target_Obj; // 총알의 직접 타겟 오브젝트
    float bullet_Direct_Damage; // 총알 직접 타겟시 데미지
    public void Bullet_Init(bool truth, bool skill_truth, GameObject direct_Target, float damage)
    {
        bullet_Target_Obj = direct_Target;
        bullet_Target = bullet_Target_Obj.transform.position;
        direct_Attack = truth;
        isCollision = false;
        isSkill = skill_truth;
        bullet_Direct_Damage = damage;
        parentChampion = transform.parent.GetComponent<ChampionData>();
    }

    IEnumerator Destroy_Coroutine()
    {
        yield return new WaitForSeconds(0.25f);

        GameManager.Resource.Destroy(this.gameObject);
    }

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (isCollision)
            return;

        if (direct_Attack) // 직접 타겟에 공격
        {
            transform.position = Vector3.MoveTowards
                (transform.position, parentChampion.cur_Target.transform.position,
                  900f * Time.deltaTime);

            transform.rotation = Quaternion.LookRotation
                (parentChampion.cur_Target.transform.position - this.transform.position);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation
             (bullet_Target - transform.position);

            transform.position = Vector3.MoveTowards(transform.position, bullet_Target,
                   1500f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == parentChampion.cur_Target && direct_Attack)
        {
            //Debug.Log("직접 충돌");
            isCollision = true;

            if (!isSkill)
                other.gameObject.GetComponent<ChampionData>().Damaged(parentChampion.Damage, true);
            else
                other.gameObject.GetComponent<ChampionData>().Damaged(parentChampion.
                    Skill_Damage[parentChampion.Champion_Level], false);

            GameManager.Resource.Destroy(this.gameObject);
        }
        else if (other.gameObject == bullet_Target_Obj) // 직접 타겟하는 총알의 타겟이라면
        {
            isCollision = true;

            other.gameObject.GetComponent<ChampionData>().Damaged(bullet_Direct_Damage, true);

            GameManager.Resource.Destroy(this.gameObject);
        }
    }
}
