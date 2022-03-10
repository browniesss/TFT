using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 아이템 코드 정리
 
1 bf대검 2 곡궁 3 쇠사슬 조끼 4 음전자 망토 5 쓸큰지 6 여눈 7 벨트 8 장갑 9 뒤집개
10 죽음의 검 11 거인 학살자 12 수호천사 13 피바라기

*/

public class ItemManager : Singleton<ItemManager>
{
    public ItemInfo[] result_Item_Save;
    public ItemInfo[,] result_Item_Arr;

    void Initialize()
    {
        result_Item_Arr = new ItemInfo[9, 9];

        result_Item_Arr[0, 0] = result_Item_Save[0];
        result_Item_Arr[0, 1] = result_Item_Save[1];
        result_Item_Arr[0, 2] = result_Item_Save[2];
        result_Item_Arr[0, 3] = result_Item_Save[3];

        result_Item_Arr[1, 0] = result_Item_Save[1];
        result_Item_Arr[2, 0] = result_Item_Save[2];
        result_Item_Arr[3, 0] = result_Item_Save[3];
    }

    private void Start()
    {
        Initialize();
    }

    public ItemInfo Item_Combination(ItemInfo item_1, ItemInfo item_2) // 아이템 조합 함수
    // 조합에 맞는 아이템을 return 해줌.
    {
        if (result_Item_Arr[item_1.item_Code - 1, item_2.item_Code - 1] != null)
            return result_Item_Arr[item_1.item_Code - 1, item_2.item_Code - 1];

        return null;
    }
}
