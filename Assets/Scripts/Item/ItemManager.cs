using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 아이템 코드 정리
 
1 bf대검 2 곡궁 3 쇠사슬 조끼 4 음전자 망토 5 쓸큰지 6 여눈 7 벨트 8 장갑 9 뒤집개
10 죽음의 검 

*/

public class ItemManager : Singleton<ItemManager>
{
    public ItemInfo[] result_Item_Arr; 
 
    public ItemInfo Item_Combination(ItemInfo item_1, ItemInfo item_2) // 아이템 조합 함수
    // 조합에 맞는 아이템을 return 해줌.
    {
        switch (item_1.item_Code)
        {
            case 1:
                {
                    switch (item_2.item_Code)
                    {
                        case 1:
                            return result_Item_Arr[0]; // 죽음의 검 반환
                    }
                }
                break;
            default:
                return null;
        }


        return null;
    }
}
