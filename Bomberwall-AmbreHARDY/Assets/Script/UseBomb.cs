using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UseBomb : MonoBehaviour
{
    private int _canBomb = 0;
    [SerializeField] private Image _image;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_canBomb <= 0) return;

        if (context.performed)
        {
            GameObject bomb = BombPool.Instance.GetPooledObject();

            if (bomb != null)
            {
                bomb.transform.position = transform.position;
                bomb.SetActive(true);
                _canBomb -= 1;
                _image.fillAmount -= 0.1666f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ObjectBomb")
        {
            _canBomb += 1;
            _image.fillAmount += 0.1666f;
            collision.gameObject.SetActive(false);
        }
    }
}
