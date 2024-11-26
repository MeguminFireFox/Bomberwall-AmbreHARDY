using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private int _hP = 10;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _text;

    void Update()
    {
        _text.text = $"{_hP}";

        if (_hP <= 0)
        {
            Time.timeScale = 0f;
            _panel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Explosion")
        {
            _hP -= 1;
        }
    }
}
