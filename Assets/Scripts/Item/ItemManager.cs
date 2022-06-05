using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 아이템 코드 정리
 
1 bf대검 2 곡궁 3 쇠사슬 조끼 4 음전자 망토 5 쓸큰지 6 여눈 7 벨트 8 장갑 9 뒤집개
10 죽음의 검 11 거인 학살자 12 수호천사 13 피바라기 14 마법공학 총검 15 쇼진의 창 16 지크의 전령 17 무한의 대검 18 제국 상징
19 고속 연사포 20 거인의 결의 21 루난의 허리케인 22 구인수의 격노검 23 스태틱의 단검 24 즈롯 차원문 25 최후의 속삭임 26 도전자 상징
27 가시갑옷 28 가고일 돌갑옷 29 솔라리 30 얼심 31 태불망

*/

public class ItemManager : Singleton<ItemManager>
{
    public ItemInfo[] result_Item_Save;
    public ItemInfo[,] result_Item_Arr;

    void Initialize()
    {
        result_Item_Arr = new ItemInfo[9, 9];

        #region 검조합
        result_Item_Arr[0, 0] = result_Item_Save[0];
        result_Item_Arr[0, 1] = result_Item_Save[1];
        result_Item_Arr[0, 2] = result_Item_Save[2];
        result_Item_Arr[0, 3] = result_Item_Save[3];
        result_Item_Arr[0, 4] = result_Item_Save[4];
        result_Item_Arr[0, 5] = result_Item_Save[5];
        result_Item_Arr[0, 6] = result_Item_Save[6];
        result_Item_Arr[0, 7] = result_Item_Save[7];
        result_Item_Arr[0, 8] = result_Item_Save[8];

        result_Item_Arr[1, 0] = result_Item_Save[1];
        result_Item_Arr[2, 0] = result_Item_Save[2];
        result_Item_Arr[3, 0] = result_Item_Save[3];
        result_Item_Arr[4, 0] = result_Item_Save[4];
        result_Item_Arr[5, 0] = result_Item_Save[5];
        result_Item_Arr[6, 0] = result_Item_Save[6];
        result_Item_Arr[7, 0] = result_Item_Save[7];
        result_Item_Arr[8, 0] = result_Item_Save[8];
        #endregion

        #region 곡궁조합
        result_Item_Arr[1, 1] = result_Item_Save[9];
        result_Item_Arr[1, 2] = result_Item_Save[10];
        result_Item_Arr[1, 3] = result_Item_Save[11];
        result_Item_Arr[1, 4] = result_Item_Save[12];
        result_Item_Arr[1, 5] = result_Item_Save[13];
        result_Item_Arr[1, 6] = result_Item_Save[14];
        result_Item_Arr[1, 7] = result_Item_Save[15];
        result_Item_Arr[1, 8] = result_Item_Save[16];

        result_Item_Arr[2, 1] = result_Item_Save[10];
        result_Item_Arr[3, 1] = result_Item_Save[11];
        result_Item_Arr[4, 1] = result_Item_Save[12];
        result_Item_Arr[5, 1] = result_Item_Save[13];
        result_Item_Arr[6, 1] = result_Item_Save[14];
        result_Item_Arr[7, 1] = result_Item_Save[15];
        result_Item_Arr[8, 1] = result_Item_Save[16];
        #endregion

        result_Item_Arr[2, 2] = result_Item_Save[17];

        result_Item_Arr[2, 3] = result_Item_Save[18];
        result_Item_Arr[2, 4] = result_Item_Save[19];
        result_Item_Arr[2, 5] = result_Item_Save[20];
        result_Item_Arr[2, 6] = result_Item_Save[21];

        result_Item_Arr[3, 2] = result_Item_Save[18];
        result_Item_Arr[4, 2] = result_Item_Save[19];
        result_Item_Arr[5, 2] = result_Item_Save[20];
        result_Item_Arr[6, 2] = result_Item_Save[21];

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
