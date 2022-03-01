using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public ChampionData tile_Champion; // 해당 타일에 올라와있는 챔피언

    public void Tile_Change(ChampionData data) // 이미 챔피언이 있던 경우 타일을 서로 바꿔주는 함수
    {
        ChampionData tempData = tile_Champion;
        Tile tempTile = data.cur_Tile;

        if (data.cur_Tile.tag == "MyTile" && tempData.cur_Tile.tag == "ReadyTile") // 전투석 챔피언이 대기열 챔피언과 바뀔 때
        {
            SynergyManager.Instance.Synergy_Find(data, false);
            SynergyManager.Instance.Synergy_Find(tempData, true);
        }
        else if (data.cur_Tile.tag == "ReadyTile" && tempData.cur_Tile.tag == "MyTile") // 반대
        {
            SynergyManager.Instance.Synergy_Find(data, true);
            SynergyManager.Instance.Synergy_Find(tempData, false);
        }

        tile_Champion = data;
        tile_Champion.cur_Tile = this;
        tile_Champion.gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        tempData.cur_Tile = tempTile;
        tempData.cur_Tile.tile_Champion = tempData;
        tempData.gameObject.transform.position = new Vector3(tempData.cur_Tile.transform.position.x,
            0, tempData.cur_Tile.transform.position.z);
    }

    public void Tile_Set(ChampionData data) // 타일을 지정해주는 함수
    {
        if (data.cur_Tile != null) // 이미 타일이 있었고
            if (data.cur_Tile.tag == "ReadyTile" &&  // 만약 대기석에서 최대 기물 개수 이상을 넘기려면 리턴
                (GameManager.Instance.player.tileCount >= GameManager.Instance.player.level))
            {
                data.transform.position = data.originalPos;
                return;
            }


        if (data.cur_Tile != null) // 타일이 이미 있던 경우
        {
            if (data.cur_Tile.tag != "MyTile") // 전투석이 아니었다면
            {
                if (this.tag == "MyTile") // 도착한 타일이 전투석이라면
                {
                    SynergyManager.Instance.Synergy_Find(data, true);
                    GameManager.Instance.player.tileCount++;
                }
            }
            else // 타일이 이미 있었는데 전투석에서 대기석으로 왔을 경우
            {
                if (this.tag == "ReadyTile")
                {
                    GameManager.Instance.player.tileCount--;
                    SynergyManager.Instance.Synergy_Find(data, false);
                }
            }

            data.cur_Tile.tile_Champion = null;

            Debug.Log("이미있어" + GameManager.Instance.player.tileCount);
        }
        else // 타일이 없던 경우
        {
            if (this.tag == "MyTile")
            {

                GameManager.Instance.player.tileCount++;
            }

            Debug.Log("없었어" + GameManager.Instance.player.tileCount);
        }

        tile_Champion = data;
        tile_Champion.cur_Tile = this;
        tile_Champion.gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void Tile_Check(ChampionData data)
    {
        if (tile_Champion == null)
        {
            Tile_Set(data);
        }
        else
        {
            Tile_Change(data);
        }
    }
}
