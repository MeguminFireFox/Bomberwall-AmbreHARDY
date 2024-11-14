using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStars : MonoBehaviour
{
    public static AStars Instance;

    private List<GameObject> _scenario;
    [SerializeField] private Dictionary<Node, float> _scenarioActif;
    [SerializeField] private Dictionary<Node, float> _verified;

    [field: SerializeField] public Node Node { get; set; }

    void Awake()
    {
        Instance = this;
    }

    public void PathFinding(GameObject target)
    {
        Debug.Log(target);
        bool find = true;

        while (find)
        {
            for (int i = 0; i < Node.Voisin.Count; i++)
            {
                _verified.Add(Node.Voisin[i], Node.Voisin[i].Position);
            }
            var minElement = _verified.Aggregate((l, r) => l.Value < r.Value ? l : r);
            _scenarioActif.Add(minElement.Key, minElement.Value);

            Node = minElement.Key;

            if (Node.transform.position == target.transform.position) find = false;
        }

        for (int i = 0; i < _scenarioActif.Count; i++)
        {
            var minElement = _scenarioActif.Aggregate((l, r) => l.Value < r.Value ? l : r);
            _scenario.Add(minElement.Key.gameObject);
        }

        Move.Instance.Find(_scenario);
    }
}