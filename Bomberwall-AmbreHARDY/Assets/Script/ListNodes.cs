using System.Collections.Generic;
using UnityEngine;

public class ListNodes : MonoBehaviour
{
    public static ListNodes Instance;

    [field : SerializeField] public List<Nodes> ListNode {  get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
