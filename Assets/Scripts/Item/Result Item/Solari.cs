using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solari : ItemInfo
{
    public override void Item_Battle_Init(ChampionData champ)
    {
        int cur_Tile_Number = champ.cur_Tile.tile_Number; // 현재 챔피언의 타일 번호

        if (cur_Tile_Number % 7 == 0) // 각 행의 첫번째 타일인 경우
        {
            Debug.Log("첫열");
            ChampionData right_Champ1 = TileManager.Instance.tile_Arr[cur_Tile_Number + 1].tile_Champion;
            ChampionData right_Champ2 = TileManager.Instance.tile_Arr[cur_Tile_Number + 2].tile_Champion;

            // 본인과 오른쪽 한 챔피언의 공격 속도를 증가 시킴
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
        else if (cur_Tile_Number % 7 == 6) // 각 행의 마지막 타일인 경우
        {
            Debug.Log("막열");
            ChampionData left_Champ1 = TileManager.Instance.tile_Arr[cur_Tile_Number - 1].tile_Champion;
            ChampionData left_Champ2 = TileManager.Instance.tile_Arr[cur_Tile_Number - 2].tile_Champion;

            // 본인과 왼쪽 한 챔피언의 공격 속도를 증가 시킴
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
        else // 나머지 경우라면
        {
            Debug.Log("중간열");
            ChampionData left_Champ1 = TileManager.Instance.tile_Arr[cur_Tile_Number - 1].tile_Champion;
            ChampionData left_Champ2 = TileManager.Instance.tile_Arr[cur_Tile_Number - 2].tile_Champion;
            ChampionData right_Champ1 = TileManager.Instance.tile_Arr[cur_Tile_Number + 1].tile_Champion;
            ChampionData right_Champ2 = TileManager.Instance.tile_Arr[cur_Tile_Number + 2].tile_Champion;

            // 본인과 왼쪽 오른쪽 챔피언의 공격 속도를 증가 시킴
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
