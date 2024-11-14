using UnityEngine;

public class ObjectBomb : MonoBehaviour
{
    void OnEnable()
    {
        int index = Random.Range(0, ListNodes.Instance.ListNode.Count);
        transform.position = ListNodes.Instance.ListNode[index].transform.position;
    }
}
