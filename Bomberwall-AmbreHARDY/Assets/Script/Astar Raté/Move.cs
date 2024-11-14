using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move Instance;

    private Vector3 _mousePos;
    [SerializeField] private Vector2 _mosePos;
    [SerializeField] public bool Trigger;
    [SerializeField] private List<GameObject> _chemin;
    private bool _active = false;

    private void Awake()
    {
        Instance = this;
    }

    public void Find(List<GameObject> chemin)
    {
        _chemin = chemin;
        _active = true;
    }

    void Update()
    {
        if (!_active) return;

        if (_mousePos == transform.position)
        {
            _chemin[0].transform.position = _mousePos;
            _chemin.Remove(_chemin[0]);
        }

        Vector2 direction = _mousePos - transform.position;
        //direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(transform.position, _mousePos, 1 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        if (_chemin.Count == 0) _active = false;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Trigger) return;

        if (collision.tag == "Node")
        {
            AStars.Instance.Node = collision.GetComponent<Node>();
        }
    }*/
}