using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListNode : MonoBehaviour
{
    public static ListNode Instance;
    [field: SerializeField] public List<Node> Nodes { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void Activate(Vector2 target)
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
            Nodes[i].Calculate(target);
        }
    }
}