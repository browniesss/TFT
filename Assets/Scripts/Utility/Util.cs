using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Util : Singleton<Util>
{
    public GameObject FindNearestObjectByTag(string tag)
    {
        // Ž���� ������Ʈ ����� List �� �����մϴ�.
        var objects = GameObject.FindGameObjectsWithTag(tag).ToList();

        // LINQ �޼ҵ带 �̿��� ���� ����� ���� ã���ϴ�.
        var neareastObject = objects
            .OrderBy(obj =>
            {
                return Vector3.Distance(transform.position, obj.transform.position);
            })
        .FirstOrDefault();

        return neareastObject;
    }

    public GameObject FindNearestObjectByTag(GameObject champ, string tag)
    {
        // Ž���� ������Ʈ ����� List �� �����մϴ�.
        var objects = GameObject.FindGameObjectsWithTag(tag).ToList();

        objects.Remove(champ);

        // LINQ �޼ҵ带 �̿��� ���� ����� ���� ã���ϴ�.
        var neareastObject = objects
            .OrderBy(obj =>
            {
                return Vector3.Distance(champ.transform.position, obj.transform.position);
            })
        .FirstOrDefault();

        return neareastObject;
    }

    public List<GameObject> FindNearestObjectsByTag(GameObject champ, string tag)
    {
        // Ž���� ������Ʈ ����� List �� �����մϴ�.
        var objects = GameObject.FindGameObjectsWithTag(tag).ToList();

        // LINQ �޼ҵ带 �̿��� ���� ����� ���� ã���ϴ�.
        var neareastObjects = objects
            .OrderBy(obj =>
            {
                return Vector3.Distance(champ.transform.position, obj.transform.position);
            }).ToList<GameObject>();

        return neareastObjects;
    }
}
