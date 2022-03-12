using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zekes_Herald : ItemInfo
{
    public override void Item_Battle_Init(ChampionData champ)
    {
        int cur_Tile_Number = champ.cur_Tile.tile_Number; // ���� è�Ǿ��� Ÿ�� ��ȣ

        if (cur_Tile_Number % 7 == 0) // �� ���� ù��° Ÿ���� ���
        {
            Debug.Log("ù��");
            ChampionData right_Champ = TileManager.Instance.tile_Arr[cur_Tile_Number + 1].tile_Champion;

            // ���ΰ� ������ �� è�Ǿ��� ���� �ӵ��� ���� ��Ŵ
            champ.item_Add_Attack_Delay += 30f;
            champ.Attack_Delay = champ.Origin_Attack_Delay * (1f + ((champ.item_Add_Attack_Delay) * 0.01f));
            champ.animator.SetFloat("Attack_Speed", champ.Attack_Delay);

            if (right_Champ != null)
            {
                right_Champ.item_Add_Attack_Delay += 30f;
                right_Champ.Attack_Delay = right_Champ.Origin_Attack_Delay *
                    (1f + ((right_Champ.item_Add_Attack_Delay) * 0.01f));
                right_Champ.animator.SetFloat("Attack_Speed", right_Champ.Attack_Delay);
            }
        }
        else if (cur_Tile_Number % 7 == 6) // �� ���� ������ Ÿ���� ���
        {
            Debug.Log("����");
            ChampionData left_Champ = TileManager.Instance.tile_Arr[cur_Tile_Number - 1].tile_Champion;

            // ���ΰ� ���� �� è�Ǿ��� ���� �ӵ��� ���� ��Ŵ
            champ.item_Add_Attack_Delay += 30f;
            champ.Attack_Delay = champ.Origin_Attack_Delay * (1f + ((champ.item_Add_Attack_Delay) * 0.01f));
            champ.animator.SetFloat("Attack_Speed", champ.Attack_Delay);

            if (left_Champ != null)
            {
                left_Champ.item_Add_Attack_Delay += 30f;
                left_Champ.Attack_Delay = left_Champ.Origin_Attack_Delay *
                    (1f + ((left_Champ.item_Add_Attack_Delay) * 0.01f));
                left_Champ.animator.SetFloat("Attack_Speed", left_Champ.Attack_Delay);
            }

        }
        else // ������ �����
        {
            Debug.Log("�߰���");
            ChampionData left_Champ = TileManager.Instance.tile_Arr[cur_Tile_Number - 1].tile_Champion;
            ChampionData right_Champ = TileManager.Instance.tile_Arr[cur_Tile_Number + 1].tile_Champion;

            // ���ΰ� ���� ������ è�Ǿ��� ���� �ӵ��� ���� ��Ŵ
            champ.item_Add_Attack_Delay += 30f;
            champ.Attack_Delay = champ.Origin_Attack_Delay * (1f + ((champ.item_Add_Attack_Delay) * 0.01f));
            champ.animator.SetFloat("Attack_Speed", champ.Attack_Delay);

            if (left_Champ != null)
            {
                left_Champ.item_Add_Attack_Delay += 30f;
                left_Champ.Attack_Delay = left_Champ.Origin_Attack_Delay *
                    (1f + ((left_Champ.item_Add_Attack_Delay) * 0.01f));
                left_Champ.animator.SetFloat("Attack_Speed", left_Champ.Attack_Delay);
            }
            if (right_Champ != null)
            {
                right_Champ.item_Add_Attack_Delay += 30f;
                right_Champ.Attack_Delay = right_Champ.Origin_Attack_Delay *
                    (1f + ((right_Champ.item_Add_Attack_Delay) * 0.01f));
                right_Champ.animator.SetFloat("Attack_Speed", right_Champ.Attack_Delay);
            }
        }
    }
}
