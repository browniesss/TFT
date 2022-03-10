using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* �ó��� �ڵ� ����

1 : ��ī���� 2 : ������ 3 : ���ݼ� 4 : ������ 5 : �ֹ��� 6 : ������

*/

public class SynergyManager : Singleton<SynergyManager>
{
    public Academy academy; // ��ī����
    public Protector protector;  // ������
    public Sniper sniper; // ���ݼ�
    public Enforcer enforcer; // ������
    public Twinshot twinShot; // �ֹ���
    public Challenger challenger;  //������

    List<Synergy> synergy_List; // Ȱ��ȭ �� �ó��� ����Ʈ
    List<ChampionData> champ_List; // ���� �ʵ��� è�Ǿ� ����Ʈ

    [SerializeField]
    private Text[] synergy_Text;

    void Start()
    {
        Synergy_List_Init();
    }

    void Synergy_List_Init()
    {
        synergy_List = new List<Synergy>();
        champ_List = new List<ChampionData>();

        academy = new Academy();
        academy.Synergy_Init();

        protector = new Protector();
        protector.Synergy_Init();

        sniper = new Sniper();
        sniper.Synergy_Init();

        enforcer = new Enforcer();
        enforcer.Synergy_Init();

        twinShot = new Twinshot();
        twinShot.Synergy_Init();

        challenger = new Challenger();
        challenger.Synergy_Init();

        synergy_List.Add(academy);
        synergy_List.Add(protector);
        synergy_List.Add(sniper);
        synergy_List.Add(enforcer);
        synergy_List.Add(twinShot);
        synergy_List.Add(challenger);
    }

    public void Synergy_Find(ChampionData data, bool truth)
    {
        recent_AddChamp_Index = -1;
        foreach (Synergy synergy in synergy_List)
        {
            foreach (Synergy sng in data.Synergys)
            {
                if (sng.synergy_Code == synergy.synergy_Code)
                {
                    Champ_Find(data, synergy, truth);
                }
            }
        }

        Synergy_Set();
    }

    int recent_AddChamp_Index; // ���� �ֱٿ� �߰� �� è�Ǿ��� �ε���
    void Champ_Find(ChampionData data, Synergy synergy, bool truth) // �ʵ����� ���� è�Ǿ��� �־����� �˻� �Լ�
    {
        int champ_Index = 0;
        for (int i = 0; i < champ_List.Count; i++)
        {
            if (champ_List[i].Champion_Code == data.Champion_Code && recent_AddChamp_Index == i)
            {
                if (truth) // �ʵ� ����
                {
                    synergy.curChamp_Count++;
                    return;
                }
                else // �ʵ忡�� ��⼮����
                {
                    synergy.curChamp_Count--;
                    return;
                }
            }

            if (champ_List[i].Champion_Code == data.Champion_Code) // ���� è�Ǿ��� �ʵ����� �ִٸ�
            {
                champ_Index = i;
                if (truth) // �ʵ� ����
                {
                    champ_List.Add(data);
                    return;
                }
                else // �ʵ忡�� ��⼮����
                {
                    for (int k = champ_Index + 1; k < champ_List.Count; k++)
                    {
                        if (champ_List[k].Champion_Code == data.Champion_Code) // ���� è�Ǿ��� �ϳ� �� �ִٸ�
                        {
                            champ_List.Remove(data); // �����͸� ����
                            return;
                        }
                    }
                }
            }
        }

        // ���� �� foreach ���� è�Ǿ��� ��ã�Ҵٸ� ( ���� è�Ǿ��� �����ٸ� )
        if (truth) // �ʵ� ����
        {
            champ_List.Add(data);
            synergy.curChamp_Count++;
        }
        else // �ʵ忡�� ��⼮����
        {
            champ_List.Remove(data);
            synergy.curChamp_Count--;
        }

        int ind = 0;
        foreach (ChampionData dat in champ_List)
        {
            if (dat.Champion_Code == data.Champion_Code)
            {
                recent_AddChamp_Index = ind;
            }
            ind++;
        }

        Debug.Log(champ_List.Count);
    }

    void Synergy_Set()
    {
        foreach (Text text in synergy_Text)
            text.gameObject.SetActive(false);

        int text_Index = 0;
        foreach (Synergy synergy in synergy_List)
        {
            if (synergy.curChamp_Count >= 1)
            {
                synergy_Text[text_Index].gameObject.SetActive(true);

                if (synergy.curChamp_Count == synergy.needChamp_Count[synergy.synergy_Level + 1])
                {
                    if (synergy.synergy_Level != synergy.synergy_MaxLevel)
                        synergy.synergy_Level++;
                }
                else if (synergy.curChamp_Count < synergy.needChamp_Count[synergy.synergy_Level])
                {
                    synergy.synergy_Level--;
                }

                synergy_Text[text_Index].text = string.Format("{0} Lv.{1} {2} / {3}", synergy.synergy_Name
                    , synergy.synergy_Level, synergy.curChamp_Count, synergy.needChamp_Count[synergy.synergy_Level + 1]);

                text_Index++;
            }
        }
    }

    public void Battle_Init() // ���� ���� �� ȣ��Ǵ� �Լ�
    {
        foreach (Synergy synergy in synergy_List) // Ȱ��ȭ �� �ó����� �� 
        {
            foreach (ChampionData champ in champ_List) // �ʵ� �� è�Ǿ����
            {
                #region 3�������Ⱦ���
                //Synergy syn;

                //syn = champ.Synergys.Find(x => x.synergy_Code == synergy.synergy_Code);

                //if (syn.synergy_Code != 0)
                //{
                //    synergy.Synergy_Battle_Init(champ); // ���� ���� �ó��� �ߵ�
                //}
                #endregion

                foreach (Synergy champion_synergy in champ.Synergys)
                {
                    if(synergy.synergy_Code == champion_synergy.synergy_Code)
                    {
                        synergy.Synergy_Battle_Init(champ);
                    }
                }
            }
        }
    }

    public void Skill_Act() // ��ų ��� �� ȣ��Ǵ� �Լ�
    {
        foreach (Synergy synergy in synergy_List) // Ȱ��ȭ �� �ó����� �� 
        {
            foreach (ChampionData champ in champ_List) // �ʵ� �� è�Ǿ����
            {
                foreach (Synergy champion_synergy in champ.Synergys)
                {
                    if (synergy.synergy_Code == champion_synergy.synergy_Code)
                    {
                        synergy.Synergy_Skill_Act(champ);
                    }
                }
            }
        }
    }

    public void Attack_Act() // ��Ÿ �� ȣ��Ǵ� �Լ�
    {
        foreach (Synergy synergy in synergy_List) // Ȱ��ȭ �� �ó����� �� 
        {
            foreach (ChampionData champ in champ_List) // �ʵ� �� è�Ǿ����
            {
                foreach (Synergy champion_synergy in champ.Synergys)
                {
                    if (synergy.synergy_Code == champion_synergy.synergy_Code)
                    {
                        synergy.Synergy_Attack_Act(champ);
                    }
                }
            }
        }
    }

    public void Battle_End() // ���� ���� �� ȣ��Ǵ� �Լ�
    {
        foreach (ChampionData champ in champ_List)
        {
            champ.Champion_Info_Reset();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
            Battle_Init();

        if (Input.GetKeyDown(KeyCode.F6))
            Battle_End();

        if (Input.GetKeyDown(KeyCode.F5))
            Skill_Act();
    }
}
