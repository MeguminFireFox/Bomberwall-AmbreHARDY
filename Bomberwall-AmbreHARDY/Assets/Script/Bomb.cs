using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _bombrange;
    void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        _bombrange.SetActive(true);
        yield return new WaitForSeconds(1);
        GameObject objectbomb = ObjectBombPool.Instance.GetPooledObject();

        if (objectbomb != null)
        {
            objectbomb.transform.position = transform.position;
            objectbomb.SetActive(true);
            _bombrange.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
