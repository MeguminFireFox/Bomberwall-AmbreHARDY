using UnityEngine;
using UnityEngine.InputSystem;

public class UseBomb : MonoBehaviour
{
    private bool _canBomb = false;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!_canBomb) return;

        if (context.performed)
        {
            GameObject bomb = BombPool.Instance.GetPooledObject();

            if (bomb != null)
            {
                bomb.transform.position = transform.position;
                bomb.SetActive(true);
                _canBomb = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_canBomb) return;

        if (collision.tag == "ObjectBomb")
        {
            _canBomb = true;
            collision.gameObject.SetActive(false);
        }
    }
}
