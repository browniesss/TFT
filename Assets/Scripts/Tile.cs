using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public ChampionData tile_Champion; // �ش� Ÿ�Ͽ� �ö���ִ� è�Ǿ�

    public void Tile_Change(ChampionData data) // �̹� è�Ǿ��� �ִ� ��� Ÿ���� ���� �ٲ��ִ� �Լ�
    {
        ChampionData tempData = tile_Champion;
        Tile tempTile = data.cur_Tile;

        if (data.cur_Tile.tag == "MyTile" && tempData.cur_Tile.tag == "ReadyTile") // ������ è�Ǿ��� ��⿭ è�Ǿ�� �ٲ� ��
        {
            SynergyManager.Instance.Synergy_Find(data, false);
            SynergyManager.Instance.Synergy_Find(tempData, true);
        }
        else if (data.cur_Tile.tag == "ReadyTile" && tempData.cur_Tile.tag == "MyTile") // �ݴ�
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

    public void Tile_Set(ChampionData data) // Ÿ���� �������ִ� �Լ�
    {
        if (data.cur_Tile != null) // �̹� Ÿ���� �־���
            if (data.cur_Tile.tag == "ReadyTile" &&  // ���� ��⼮���� �ִ� �⹰ ���� �̻��� �ѱ���� ����
                (GameManager.Instance.player.tileCount >= GameManager.Instance.player.level))
            {
                data.transform.position = data.originalPos;
                return;
            }


        if (data.cur_Tile != null) // Ÿ���� �̹� �ִ� ���
        {
            if (data.cur_Tile.tag != "MyTile") // �������� �ƴϾ��ٸ�
            {
                if (this.tag == "MyTile") // ������ Ÿ���� �������̶��
                {
                    SynergyManager.Instance.Synergy_Find(data, true);
                    GameManager.Instance.player.tileCount++;
                }
            }
            else // Ÿ���� �̹� �־��µ� ���������� ��⼮���� ���� ���
            {
                if (this.tag == "ReadyTile")
                {
                    GameManager.Instance.player.tileCount--;
                    SynergyManager.Instance.Synergy_Find(data, false);
                }
            }

            data.cur_Tile.tile_Champion = null;

            Debug.Log("�̹��־�" + GameManager.Instance.player.tileCount);
        }
        else // Ÿ���� ���� ���
        {
            if (this.tag == "MyTile")
            {

                GameManager.Instance.player.tileCount++;
            }

            Debug.Log("������" + GameManager.Instance.player.tileCount);
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
