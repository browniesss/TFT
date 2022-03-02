using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  챔피언 코드 정리
   
1 : 가렌 2 : 케이틀린 3 : 그레이브즈 4 : 이즈리얼

*/

public class ShopManager : MonoBehaviour
{
    [Header("Card List")]
    [SerializeField]
    private ShopCardInfo[] cost1card_Arr; // 1코스트 카드 리스트

    [Header("Button List")]
    [SerializeField]
    private Button[] shop_Buttons; // 5개의 버튼 
    [SerializeField]
    private ShopCardInfo[] cur_ShopChamp_Arr; // 현재 상점의 챔피언카드들을 저장해놓은 배열

    [Header("Tile Manage")]
    [SerializeField]
    private Tile[] ready_Tile; // 대기석

    private Dictionary<int, ShopCardInfo[]> card_Dictionary;
    public List<ChampionData> cur_haveChamp_List;

    void Start()
    {
        Initialize();

        ReRoll();
    }

    void Initialize()
    {
        card_Dictionary = new Dictionary<int, ShopCardInfo[]>();
        cur_haveChamp_List = new List<ChampionData>();

        card_Dictionary.Add(1, cost1card_Arr);
    }

    public void ReRoll() // 상점 초기화
    {
        for (int i = 0; i < 5; i++)
        {
            shop_Buttons[i].gameObject.SetActive(true);

            int randomCost = 1; // 레벨에 맞게 코스트를 랜덤으로 뽑은 후
            int randomIndex; // 그 코스트의 챔피언들 중 랜덤으로 뽑음

            randomIndex = Random.Range(0, card_Dictionary[1].Length);

            ShopCardInfo card = card_Dictionary[randomCost][randomIndex];

            cur_ShopChamp_Arr[i] = card; // 챔피언 데이터를 넘겨줌.
            shop_Buttons[i].image.sprite = card.card_Sprite;
        }
    }

    public void Buy_Champion(int index) // 챔피언 구매 함수
    {
        ShopCardInfo card = cur_ShopChamp_Arr[index];

        int tileIndex = 0; // 비어있는 타일 인덱스
        foreach (Tile tile in ready_Tile) // 비어있는 대기석이 있는지 검사 후
        {
            if (tile.tile_Champion == null)
                break;

            tileIndex++;
        }


        if (tileIndex >= 9) // 비어있는 대기석이 없다면
            return;

        if (GameManager.Instance.player.haveMoney >= card.card_Gold) // 구매할 수 있는 골드가 있다면
        {
            GameManager.Instance.player.haveMoney -= card.card_Gold;

            GameObject champion = GameManager.Resource.Instantiate("Characters/" + card.card_Data.name);

            ready_Tile[tileIndex].Tile_Set(champion.GetComponent<ChampionData>());

            shop_Buttons[index].gameObject.SetActive(false);

            cur_haveChamp_List.Add(champion.GetComponent<ChampionData>());

            Champion_Triple_Check(champion.GetComponent<ChampionData>());
        }
    }

    void Champion_Triple_Check(ChampionData check_Champ)
    {
        int count = 0;
        ChampionData[] tempChamp_Arr = new ChampionData[3]; // 같은 챔피언을 담아줄 배열
        foreach (ChampionData champ in cur_haveChamp_List)
        {
            if (check_Champ.Champion_Code == champ.Champion_Code && check_Champ.Champion_Level == champ.Champion_Level) // 챔피언이 같고
                                                                                                                        // 레벨(성) 까지 같다면
            {
                tempChamp_Arr[count++] = champ;
            }
        }

        if (count == 3)
        {
            foreach (ChampionData data in tempChamp_Arr)
            {
                cur_haveChamp_List.Remove(data); // 현재 보유중 챔프 리스트에서 삭제
                GameManager.Resource.Destroy(data.gameObject);
            }

            ChampionData upChamp = GameManager.Resource.Instantiate("Characters/" + tempChamp_Arr[0].name)
                .GetComponent<ChampionData>(); // 챔피언 한명 0번쨰 인덱스 위치에 2성으로 생성

            tempChamp_Arr[0].cur_Tile.tile_Champion = upChamp; // 없어질 챔피언이 있던 타일의 챔피언을 재등록.
            upChamp.cur_Tile = tempChamp_Arr[0].cur_Tile;

            upChamp.transform.position = tempChamp_Arr[0].transform.position;
            upChamp.Champion_Level = tempChamp_Arr[0].Champion_Level + 1; // 레벨을 1단계 올려줌.

            upChamp.Champion_Info_Init();

            cur_haveChamp_List.Add(upChamp); // 레벨이 오른 챔피언도 현재 보유중인 챔프 리스트에 다시 추가해줌.

            Champion_Triple_Check(upChamp); // 레벨 오른 챔피언을 다시 검사해줘서 2성 챔피언이 3마리 됐음을 체크.
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            ReRoll();
    }
}
