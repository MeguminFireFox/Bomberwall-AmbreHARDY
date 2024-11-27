using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _movement;
    private bool _canDust = true;
    [SerializeField] private AudioSource _audioSource;

    public void OnMovement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        transform.Translate(_speed * _movement * Time.deltaTime);
        if (_canDust) StartCoroutine(Dust());
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
}
