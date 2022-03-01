using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInfo
{
    public int level = 2; // 현재 레벨
    public int needExp; // 현재 레벨 필요한 경험치
    public int curExp; // 현재 경험치
    public int haveMoney; // 현재 보유 골드

    public int tileCount = 0; // 현재 전투 석에 올라가있는 챔피언 수
}

public class GameManager : MonoBehaviour
{
    #region 매니저, 싱글톤
    public static GameManager Instance;

    ObjectManager _objManager = new ObjectManager();
    ResourceManager _resourceManager = new ResourceManager();

    public static ObjectManager ObjManager { get { return Instance._objManager; } }
    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    #endregion

    public UserInfo player;

    static void Init()
    {
        Instance._objManager.Init();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = new UserInfo();

        player.haveMoney = 100;
    }
}