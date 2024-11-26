using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int _health = 3;
    [SerializeField] private Image _image;
    private bool _invicibility = false;
    [SerializeField] private GameObject _panel;

    void Update()
    {
        if (_health <= 0)
        {
            Time.timeScale = 0f;
            _panel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_invicibility) return;

        if (collision.tag == "Explosion")
        {
            _health -= 1;
            _image.fillAmount -= 0.333f;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        _invicibility = true;
        yield return new WaitForSeconds(3);
        _invicibility = false;
    }
}
