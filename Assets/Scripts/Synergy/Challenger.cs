using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenger : Synergy
{

    void Start()
    {
        Synergy_Init();
    }

    public override void Synergy_Init()
    {
        synergy_Level = 0; // �ó��� ���� 
        synergy_MaxLevel = 8; // �ó��� �ִ뷹��
        needChamp_Count = new int[5]; // ���� �������� �ʿ��� è�Ǿ� �� 
        curChamp_Count = 0; // ���� è�Ǿ� �� 
        synergy_Name = "������"; // �ó��� �̸�
        synergy_Code =6; // �ó��� �ڵ�

        needChamp_Count[1] = 2;
        needChamp_Count[2] = 4;
        needChamp_Count[3] = 6;
        needChamp_Count[4] = 8;



    }





}
