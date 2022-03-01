using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleLegend : MonoBehaviour
{
    public float speed;      // ĳ���� ������ ���ǵ�
    public Vector3 movePoint; // �̵� ��ġ ����
    public Camera mainCamera; // ���� ī�޶�

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TargetPos_Check();
        }

        Move();
    }

    void TargetPos_Check()
    {
        // ī�޶󿡼� �������� ���.
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // �������� ������ �¾Ҵٸ�
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            movePoint = raycastHit.point;
        }
    }

    void Move()
    {
        if (transform.position == movePoint)
        {
            animator.SetBool("isMove", false);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoint.x, 2, movePoint.z)
            , Time.deltaTime * speed);

        transform.rotation = Quaternion.LookRotation(movePoint - this.transform.position);

        animator.SetBool("isMove", true);
    }
}
