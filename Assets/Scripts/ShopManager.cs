using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  è�Ǿ� �ڵ� ����
   
1 : ���� 2 : ����Ʋ�� 3 : �׷��̺��� 4 : �����

*/

public class ShopManager : MonoBehaviour
{
    [Header("Card List")]
    [SerializeField]
    private ShopCardInfo[] cost1card_Arr; // 1�ڽ�Ʈ ī�� ����Ʈ

    [Header("Button List")]
    [SerializeField]
    private Button[] shop_Buttons; // 5���� ��ư 
    [SerializeField]
    private ShopCardInfo[] cur_ShopChamp_Arr; // ���� ������ è�Ǿ�ī����� �����س��� �迭

    [Header("Tile Manage")]
    [SerializeField]
    private Tile[] ready_Tile; // ��⼮

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

    public void ReRoll() // ���� �ʱ�ȭ
    {
        for (int i = 0; i < 5; i++)
        {
            shop_Buttons[i].gameObject.SetActive(true);

            int randomCost = 1; // ������ �°� �ڽ�Ʈ�� �������� ���� ��
            int randomIndex; // �� �ڽ�Ʈ�� è�Ǿ�� �� �������� ����

            randomIndex = Random.Range(0, card_Dictionary[1].Length);

            ShopCardInfo card = card_Dictionary[randomCost][randomIndex];

            cur_ShopChamp_Arr[i] = card; // è�Ǿ� �����͸� �Ѱ���.
            shop_Buttons[i].image.sprite = card.card_Sprite;
        }
    }

    public void Buy_Champion(int index) // è�Ǿ� ���� �Լ�
    {
        ShopCardInfo card = cur_ShopChamp_Arr[index];

        int tileIndex = 0; // ����ִ� Ÿ�� �ε���
        foreach (Tile tile in ready_Tile) // ����ִ� ��⼮�� �ִ��� �˻� ��
        {
            if (tile.tile_Champion == null)
                break;

            tileIndex++;
        }


        if (tileIndex >= 9) // ����ִ� ��⼮�� ���ٸ�
            return;

        if (GameManager.Instance.player.haveMoney >= card.card_Gold) // ������ �� �ִ� ��尡 �ִٸ�
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
        ChampionData[] tempChamp_Arr = new ChampionData[3]; // ���� è�Ǿ��� ����� �迭
        foreach (ChampionData champ in cur_haveChamp_List)
        {
            if (check_Champ.Champion_Code == champ.Champion_Code && check_Champ.Champion_Level == champ.Champion_Level) // è�Ǿ��� ����
                                                                                                                        // ����(��) ���� ���ٸ�
            {
                tempChamp_Arr[count++] = champ;
            }
        }

        if (count == 3)
        {
            foreach (ChampionData data in tempChamp_Arr)
            {
                cur_haveChamp_List.Remove(data); // ���� ������ è�� ����Ʈ���� ����
                GameManager.Resource.Destroy(data.gameObject);
            }

            ChampionData upChamp = GameManager.Resource.Instantiate("Characters/" + tempChamp_Arr[0].name)
                .GetComponent<ChampionData>(); // è�Ǿ� �Ѹ� 0���� �ε��� ��ġ�� 2������ ����

            tempChamp_Arr[0].cur_Tile.tile_Champion = upChamp; // ������ è�Ǿ��� �ִ� Ÿ���� è�Ǿ��� ����.
            upChamp.cur_Tile = tempChamp_Arr[0].cur_Tile;

            upChamp.transform.position = tempChamp_Arr[0].transform.position;
            upChamp.Champion_Level = tempChamp_Arr[0].Champion_Level + 1; // ������ 1�ܰ� �÷���.

            upChamp.Champion_Info_Init();

            cur_haveChamp_List.Add(upChamp); // ������ ���� è�Ǿ� ���� �������� è�� ����Ʈ�� �ٽ� �߰�����.

            Champion_Triple_Check(upChamp); // ���� ���� è�Ǿ��� �ٽ� �˻����༭ 2�� è�Ǿ��� 3���� ������ üũ.
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            ReRoll();
    }
}
