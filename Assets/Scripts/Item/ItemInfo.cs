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

    public bool is_Raw_Item; // 재료 아이템인지 판별 false = 완성 , true = 재료

    public void Add_Status() // 캐릭터의 아이템 능력치를 올려주는 함수
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
