using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ������ �ڵ� ����
 
1 bf��� 2 ��� 3 ��罽 ���� 4 ������ ���� 5 ��ū�� 6 ���� 7 ��Ʈ 8 �尩 9 ������
10 ������ �� 

*/

public class ItemManager : Singleton<ItemManager>
{
    public ItemInfo[] result_Item_Arr; 
 
    public ItemInfo Item_Combination(ItemInfo item_1, ItemInfo item_2) // ������ ���� �Լ�
    // ���տ� �´� �������� return ����.
    {
        switch (item_1.item_Code)
        {
            case 1:
                {
                    switch (item_2.item_Code)
                    {
                        case 1:
                            return result_Item_Arr[0]; // ������ �� ��ȯ
                    }
                }
                break;
            default:
                return null;
        }


        return null;
    }
}
