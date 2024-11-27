using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNGMovement : MonoBehaviour
{
    public Nodes currentNodes;
    [SerializeField] private Nodes _nodePlaceBomb;
    public List<Nodes> ListChemin = new List<Nodes>();
    private int _canBomb = 0;
    private bool _blocked = false;
    private int _numberBomb;
    private bool _fonctionne = true;
    [SerializeField] private Image _image;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;
    private bool _canDust = true;

    private void Awake()
    {
        _numberBomb = Random.Range(1, 6);
    }
    void Update()
    {
        if (_blocked)
        {
            Nodes nodes = currentNodes.Connections[Random.Range(0, currentNodes.Connections.Count)];
            ListChemin = AStarManager.Instance.GeneratePath(currentNodes, nodes.Connections[Random.Range(0, currentNodes.Connections.Count)]);
        }

        Chemin();
    }

    public void Chemin()
    {
        if (ListChemin.Count > 0)
        {
            int x = 0;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(ListChemin[x].transform.position.x, ListChemin[x].transform.position.y, -2), _speed * Time.deltaTime);
            
            if (_canDust) StartCoroutine(Dust());

            if (Vector2.Distance(transform.position, ListChemin[x].transform.position) < 0.1f)
            {
                currentNodes = ListChemin[x];
                ListChemin.RemoveAt(x);
            }
            
            if (Vector2.Distance(transform.position, _nodePlaceBomb.transform.position) < 0.1f && _canBomb >= 1)
            {
                GameObject bomb = BombPool.Instance.GetPooledObject();

                if (bomb != null)
                {
                    bomb.transform.position = transform.position;
                    bomb.SetActive(true);
                    _image.fillAmount -= 0.1666f;
                    _canBomb -= 1;
                }
            }
        }

        else if (_canBomb >= _numberBomb || FindAnyObjectByType<ObjectBomb>() == null && _fonctionne)
        {
            ListChemin = AStarManager.Instance.GeneratePath(currentNodes, _nodePlaceBomb);
            _fonctionne = false;
        }

        else if (FindAnyObjectByType<ObjectBomb>() != null)
        {
            ObjectBomb[] objectbombs = FindObjectsOfType<ObjectBomb>();
            ObjectBomb targetBomb = null;
            float shortestDistance = float.MaxValue;

            foreach (ObjectBomb bomb in objectbombs)
            {
                float distance = Vector3.Distance(transform.position, bomb.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    targetBomb = bomb;
                }
            }

            while (ListChemin == null || ListChemin.Count == 0)
            {
                if (targetBomb != null)
                {
                    ListChemin = AStarManager.Instance.GeneratePath(currentNodes, targetBomb.Nodes);
                }
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

    IEnumerator Dust()
    {
        GameObject dust = DustPool.Instance.GetPooledObject();

        if (dust != null)
        {
            dust.transform.position = transform.position;
            dust.SetActive(true);
            _canDust = false;
            _audioSource.Play();
        }
        yield return new WaitForSeconds(0.5f);
        dust.SetActive(false);
        _canDust = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ObjectBomb")
        {
            _canBomb += 1;
            _image.fillAmount += 0.1666f;
            _fonctionne = true;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bot")
        {
            _blocked = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bot")
        {
            _blocked = false;
        }
    }
}
