using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ������ �ڵ� ����
 
1 bf��� 2 ��� 3 ��罽 ���� 4 ������ ���� 5 ��ū�� 6 ���� 7 ��Ʈ 8 �尩 9 ������
10 ������ �� 11 ���� �л��� 12 ��ȣõ�� 13 �ǹٶ�� 14 �������� �Ѱ� 15 ������ â 16 ��ũ�� ���� 17 ������ ��� 18 ���� ��¡
19 ��� ������ 20 ������ ���� 21 �糭�� �㸮���� 22 ���μ��� �ݳ�� 23 ����ƽ�� �ܰ� 24 ��� ������ 25 ������ �ӻ��� 26 ������ ��¡
27 ���ð��� 28 ������ ������ 29 �ֶ� 30 ��� 31 �ºҸ�

*/

public class ItemManager : Singleton<ItemManager>
{
    public ItemInfo[] result_Item_Save;
    public ItemInfo[,] result_Item_Arr;

    void Initialize()
    {
        result_Item_Arr = new ItemInfo[9, 9];

        #region ������
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

        #region �������
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

    public ItemInfo Item_Combination(ItemInfo item_1, ItemInfo item_2) // ������ ���� �Լ�
    // ���տ� �´� �������� return ����.
    {
        if (result_Item_Arr[item_1.item_Code - 1, item_2.item_Code - 1] != null)
            return result_Item_Arr[item_1.item_Code - 1, item_2.item_Code - 1];

        return null;
    }
}
