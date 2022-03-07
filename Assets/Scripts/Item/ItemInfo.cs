using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    protected string item_Name; // 아이템 이름
    [SerializeField]
    protected int item_Code; // 아이템 코드
    [SerializeField]
    protected int item_Damage; // 아이템 추가 데미지 
    [SerializeField]
    protected int item_AP; // 아이템 추가 주문력
    [SerializeField]
    protected Material item_Material; // 아이템 매테리얼

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
