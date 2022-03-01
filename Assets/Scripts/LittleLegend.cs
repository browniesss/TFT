using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleLegend : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드
    public Vector3 movePoint; // 이동 위치 저장
    public Camera mainCamera; // 메인 카메라

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
        // 카메라에서 레이저를 쏜다.
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // 레이저가 뭔가에 맞았다면
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
