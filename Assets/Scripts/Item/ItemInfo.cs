using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    protected string item_Name; // ������ �̸�
    [SerializeField]
    protected int item_Code; // ������ �ڵ�
    [SerializeField]
    protected int item_Damage; // ������ �߰� ������ 
    [SerializeField]
    protected int item_AP; // ������ �߰� �ֹ���
    [SerializeField]
    protected Material item_Material; // ������ ���׸���

    public bool is_Raw_Item; // ��� ���������� �Ǻ� false = �ϼ� , true = ���

    public void Add_Status() // ĳ������ ������ �ɷ�ġ�� �÷��ִ� �Լ�
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
