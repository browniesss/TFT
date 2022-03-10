using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ������ �ڵ� ����
 
1 bf��� 2 ��� 3 ��罽 ���� 4 ������ ���� 5 ��ū�� 6 ���� 7 ��Ʈ 8 �尩 9 ������
10 ������ �� 11 ���� �л��� 12 ��ȣõ�� 13 �ǹٶ��

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

    public ItemInfo Item_Combination(ItemInfo item_1, ItemInfo item_2) // ������ ���� �Լ�
    // ���տ� �´� �������� return ����.
    {
        if (result_Item_Arr[item_1.item_Code - 1, item_2.item_Code - 1] != null)
            return result_Item_Arr[item_1.item_Code - 1, item_2.item_Code - 1];

        return null;
    }
}
