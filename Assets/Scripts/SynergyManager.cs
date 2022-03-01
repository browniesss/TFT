using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 시너지 코드 정리

1 : 아카데미 2 : 봉쇄자 3 : 저격수 4 : 집행자

*/

public class SynergyManager : Singleton<SynergyManager>
{
    public Academy academy; // 아카데미
    public Protector protector;  // 봉쇄자
    public Sniper sniper; // 저격수
    public Enforcer enforcer; // 집행자

    List<Synergy> synergy_List; // 활성화 된 시너지 리스트
    List<ChampionData> champ_List; // 현재 필드위 챔피언 리스트

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

        synergy_List.Add(academy);
        synergy_List.Add(protector);
        synergy_List.Add(sniper);
        synergy_List.Add(enforcer);
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
                    Debug.Log("챔프파인드실행");
                    Champ_Find(data, synergy, truth);
                }
            }
        }

        Synergy_Set();
    }

    int recent_AddChamp_Index; // 가장 최근에 추가 된 챔피언의 인덱스
    void Champ_Find(ChampionData data, Synergy synergy, bool truth) // 필드위에 같은 챔피언이 있었는지 검사 함수
    {
        int champ_Index = 0;
        for (int i = 0; i < champ_List.Count; i++)
        {
            if (champ_List[i].Champion_Code == data.Champion_Code && recent_AddChamp_Index == i)
            {
                if (truth) // 필드 진입
                {
                    synergy.curChamp_Count++;
                    return;
                }
                else // 필드에서 대기석으로
                {
                    synergy.curChamp_Count--;
                    return;
                }
            }

            if (champ_List[i].Champion_Code == data.Champion_Code) // 같은 챔피언이 필드위에 있다면
            {
                champ_Index = i;
                if (truth) // 필드 진입
                {
                    champ_List.Add(data);
                    Debug.Log("포이치챔프추가");
                    return;
                }
                else // 필드에서 대기석으로
                {
                    for (int k = champ_Index + 1; k < champ_List.Count; k++)
                    {
                        if (champ_List[k].Champion_Code == data.Champion_Code) // 같은 챔피언이 하나 더 있다면
                        {
                            champ_List.Remove(data); // 데이터만 삭제
                            Debug.Log("포이치챔프삭제");
                            return;
                        }
                    }
                }
            }
        }

        // 만약 위 foreach 에서 챔피언을 못찾았다면 ( 같은 챔피언이 없었다면 )
        if (truth) // 필드 진입
        {
            champ_List.Add(data);
            synergy.curChamp_Count++;
            Debug.Log("챔프 추가" + synergy.curChamp_Count);
        }
        else // 필드에서 대기석으로
        {
            champ_List.Remove(data);
            synergy.curChamp_Count--;
            Debug.Log("챔프 삭제" + synergy.curChamp_Count);
        }

        int ind = 0;
        foreach (ChampionData dat in champ_List)
        {
            Debug.Log("체크체크" + ind);
            if (dat.Champion_Code == data.Champion_Code)
            {
                recent_AddChamp_Index = ind;
                Debug.Log("최근번호저장" + ind);
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
                else if(synergy.curChamp_Count < synergy.needChamp_Count[synergy.synergy_Level])
                {
                    synergy.synergy_Level--;
                }

                synergy_Text[text_Index].text = string.Format("{0} Lv.{1} {2} / {3}", synergy.synergy_Name
                    , synergy.synergy_Level, synergy.curChamp_Count, synergy.needChamp_Count[synergy.synergy_Level + 1]);

                text_Index++;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
            academy.Academy_Battle_Init(champ_List[0]);
    }
}
