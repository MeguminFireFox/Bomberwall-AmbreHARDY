using System.Collections.Generic;
using UnityEngine;

public class ObjectBombPool : MonoBehaviour
{
    public static ObjectBombPool Instance;

    private List<GameObject> poolObjects = new List<GameObject>();
    [SerializeField] private int amountToPool;

    [SerializeField] private GameObject _prefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(_prefab);
            obj.SetActive(true);
            poolObjects.Add(obj);

        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
}