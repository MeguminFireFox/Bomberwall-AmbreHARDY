using UnityEngine;

public class ObjectBomb : MonoBehaviour
{
    [SerializeField] public Nodes Nodes {  get; private set; }

    void OnEnable()
    {
        int index = Random.Range(0, ListNodes.Instance.ListNode.Count);
        Nodes = ListNodes.Instance.ListNode[index];
        transform.position = ListNodes.Instance.ListNode[index].transform.position;
    }
}
