using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] public float Position { get; private set; }

    [field: SerializeField] public List<Node> Voisin { get; set; }

    private RaycastHit2D _hit;

    [field: SerializeField] public Node Parent { get; set; }

    private void Start()
    {
        _hit = Physics2D.Raycast(transform.position, Vector2.up, 0.75f);
        AddList();
        _hit = Physics2D.Raycast(transform.position, Vector2.left, 0.75f);
        AddList();
        _hit = Physics2D.Raycast(transform.position, Vector2.right, 0.75f);
        AddList();
        _hit = Physics2D.Raycast(transform.position, Vector2.down, 0.75f);
        AddList();
    }

    public void AddList()
    {
        if (_hit != _hit.collider.GetComponent<Node>()) return;

        Voisin.Add(_hit.collider.GetComponent<Node>());
        _hit.collider.GetComponent<AStars>();
    }

    private void OnMouseDown()
    {
        AStars.Instance.PathFinding(gameObject);
        ListNode.Instance.Activate(transform.position);
    }

    public void Calculate(Vector2 target)
    {
        Position = Vector2.Distance(transform.position, target);
        Debug.Log(Position);
    }
}