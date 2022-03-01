using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInfo
{
    public int level = 2; // ���� ����
    public int needExp; // ���� ���� �ʿ��� ����ġ
    public int curExp; // ���� ����ġ
    public int haveMoney; // ���� ���� ���

    public int tileCount = 0; // ���� ���� ���� �ö��ִ� è�Ǿ� ��
}

public class GameManager : MonoBehaviour
{
    #region �Ŵ���, �̱���
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