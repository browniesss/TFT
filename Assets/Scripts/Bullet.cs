using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private ChampionData parentChampion;
    [SerializeField]
    private bool isCollision = false;

    private bool direct_Attack; // 총알이 데미지를 주는지 안주는지 판별할 변수  true = 직접
    void Start()
    {
    }

    public void Bullet_Init(bool truth)
    {
        direct_Attack = truth;
        isCollision = false;
        parentChampion = transform.parent.GetComponent<ChampionData>();
    }

    Vector3 bullet_Target; // 총알의 직접 타겟
    public void Bullet_Init(bool truth, Vector3 targetPos)
    {
        bullet_Target = targetPos;
        direct_Attack = truth;
        isCollision = false;
        parentChampion = transform.parent.GetComponent<ChampionData>();

        StartCoroutine(Destroy_Coroutine());
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
                   900f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == parentChampion.cur_Target)
        {
            isCollision = true;

            other.gameObject.GetComponent<ChampionData>().Damaged(parentChampion.Damage);

            GameManager.Resource.Destroy(this.gameObject);
        }
    }
}
