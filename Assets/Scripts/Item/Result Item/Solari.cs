using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solari : ItemInfo
{
    public override void Item_Battle_Init(ChampionData champ)
    {
        int cur_Tile_Number = champ.cur_Tile.tile_Number; // ���� è�Ǿ��� Ÿ�� ��ȣ

        if (cur_Tile_Number % 7 == 0) // �� ���� ù��° Ÿ���� ���
        {
            Debug.Log("ù��");
            ChampionData right_Champ1 = TileManager.Instance.tile_Arr[cur_Tile_Number + 1].tile_Champion;
            ChampionData right_Champ2 = TileManager.Instance.tile_Arr[cur_Tile_Number + 2].tile_Champion;

            // ���ΰ� ������ �� è�Ǿ��� ���� �ӵ��� ���� ��Ŵ
            champ.Shield += 300 + (champ.Champion_Level - 1) * 50;

            if (right_Champ1 != null)
            {
                right_Champ1.Shield += 300 + (champ.Champion_Level - 1) * 50;
            }
            if (right_Champ2 != null)
            {
                right_Champ2.Shield += 300 + (champ.Champion_Level - 1) * 50;
            }
        }
        else if (cur_Tile_Number % 7 == 6) // �� ���� ������ Ÿ���� ���
        {
            Debug.Log("����");
            ChampionData left_Champ1 = TileManager.Instance.tile_Arr[cur_Tile_Number - 1].tile_Champion;
            ChampionData left_Champ2 = TileManager.Instance.tile_Arr[cur_Tile_Number - 2].tile_Champion;

            // ���ΰ� ���� �� è�Ǿ��� ���� �ӵ��� ���� ��Ŵ
            champ.Shield += 300 + (champ.Champion_Level - 1) * 50;

            if (left_Champ1 != null)
            {
                left_Champ1.Shield += 300 + (champ.Champion_Level - 1) * 50;
            }
            if (left_Champ2 != null)
            {
                left_Champ2.Shield += 300 + (champ.Champion_Level - 1) * 50;
            }
        }
        else // ������ �����
        {
            Debug.Log("�߰���");
            ChampionData left_Champ1 = TileManager.Instance.tile_Arr[cur_Tile_Number - 1].tile_Champion;
            ChampionData left_Champ2 = TileManager.Instance.tile_Arr[cur_Tile_Number - 2].tile_Champion;
            ChampionData right_Champ1 = TileManager.Instance.tile_Arr[cur_Tile_Number + 1].tile_Champion;
            ChampionData right_Champ2 = TileManager.Instance.tile_Arr[cur_Tile_Number + 2].tile_Champion;

            // ���ΰ� ���� ������ è�Ǿ��� ���� �ӵ��� ���� ��Ŵ
            champ.Shield += 300 + (champ.Champion_Level - 1) * 50;

            if (right_Champ1 != null)
            {
                right_Champ1.Shield += 300 + (champ.Champion_Level - 1) * 50;
            }
            if (right_Champ2 != null)
            {
                right_Champ2.Shield += 300 + (champ.Champion_Level - 1) * 50;
            }
            if (left_Champ1 != null)
            {
                left_Champ1.Shield += 300 + (champ.Champion_Level - 1) * 50;
            }
            if (left_Champ2 != null)
            {
                left_Champ2.Shield += 300 + (champ.Champion_Level - 1) * 50;
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
