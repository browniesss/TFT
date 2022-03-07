using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public ItemInfo box_Item; // �ش� �ڽ��� ������

    #region ���콺 �巡��
    private Vector3 m_Offset;
    private float m_ZCoord;
    public Vector3 originalPos;
    void OnMouseDown()
    {
        originalPos = transform.position;

        m_ZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        m_Offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 tempVec = GetMouseWorldPosition() + m_Offset;

        transform.position = new Vector3(tempVec.x, 0, tempVec.z);
    }

    void OnMouseUp()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000, LayerMask.GetMask("Champion")))
        {
            ChampionData hit_Champ = hit.transform.GetComponent<ChampionData>();

            if(hit_Champ.have_Item_Count < 3) // ������ �������� 3�� �̸��� ���
            {

            }
        }
        else
        {
            transform.position = originalPos;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = m_ZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
