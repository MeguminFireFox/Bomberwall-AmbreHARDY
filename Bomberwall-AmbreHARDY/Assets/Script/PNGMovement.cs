using System.Collections.Generic;
using UnityEngine;

public class PNGMovement : MonoBehaviour
{
    public Nodes currentNodes;
    public List<Nodes> ListChemin = new List<Nodes>();

    [SerializeField] private float _speed;

    void Update()
    {
        Chemin();
    }

    public void Chemin()
    {
        if (ListChemin.Count > 0)
        {
            int x = 0;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(ListChemin[x].transform.position.x, ListChemin[x].transform.position.y, -2), _speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, ListChemin[x].transform.position) < 0.1f)
            {
                currentNodes = ListChemin[x];
                ListChemin.RemoveAt(x);
            }
        }
        else
        {
            Nodes[] nodes = FindObjectsOfType<Nodes>();
            while (ListChemin == null || ListChemin.Count == 0)
            {
                ListChemin = AStarManager.Instance.GeneratePath(currentNodes, nodes[Random.Range(0, nodes.Length)]);
            }
        }
    }
}
