using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Nodes CameFrom;
    public List<Nodes> Connections;

    public float GScore;
    public float HScore;
    public float FScore()
    {
        return GScore + HScore;
    }

    private RaycastHit2D _hit;

    private void Awake()
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
        if (_hit != _hit.collider.GetComponent<Nodes>()) return;

        Connections.Add(_hit.collider.GetComponent<Nodes>());
        _hit.collider.GetComponent<AStars>();
    }
}
