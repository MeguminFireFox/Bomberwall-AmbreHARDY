using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _movement;

    public void OnMovement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        transform.Translate(_speed * _movement * Time.deltaTime);
    }
}
