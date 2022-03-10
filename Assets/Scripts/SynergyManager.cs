using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 시너지 코드 정리

1 : 아카데미 2 : 봉쇄자 3 : 저격수 4 : 집행자 5 : 쌍발총 6 : 도전자

*/

public class SynergyManager : Singleton<SynergyManager>
{
    public Academy academy; // 아카데미
    public Protector protector;  // 봉쇄자
    public Sniper sniper; // 저격수
    public Enforcer enforcer; // 집행자
    public Twinshot twinShot; // 쌍발총
    public Challenger challenger;  //도전자

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
                    return;
                }
                else // 필드에서 대기석으로
                {
                    for (int k = champ_Index + 1; k < champ_List.Count; k++)
                    {
                        if (champ_List[k].Champion_Code == data.Champion_Code) // 같은 챔피언이 하나 더 있다면
                        {
                            champ_List.Remove(data); // 데이터만 삭제
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
        }
        else // 필드에서 대기석으로
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

    public void Battle_Init() // 전투 시작 시 호출되는 함수
    {
        foreach (Synergy synergy in synergy_List) // 활성화 된 시너지들 중 
        {
            foreach (ChampionData champ in champ_List) // 필드 위 챔피언들이
            {
                #region 3중포문안쓰기
                //Synergy syn;

                //syn = champ.Synergys.Find(x => x.synergy_Code == synergy.synergy_Code);

                //if (syn.synergy_Code != 0)
                //{
                //    synergy.Synergy_Battle_Init(champ); // 전투 시작 시너지 발동
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

    public void Skill_Act() // 스킬 사용 시 호출되는 함수
    {
        foreach (Synergy synergy in synergy_List) // 활성화 된 시너지들 중 
        {
            foreach (ChampionData champ in champ_List) // 필드 위 챔피언들이
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

    public void Attack_Act() // 평타 시 호출되는 함수
    {
        foreach (Synergy synergy in synergy_List) // 활성화 된 시너지들 중 
        {
            foreach (ChampionData champ in champ_List) // 필드 위 챔피언들이
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

    public void Battle_End() // 전투 종료 시 호출되는 함수
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
