using UnityEngine;
using UnityEngine.InputSystem;

public class UseBomb : MonoBehaviour
{
    [SerializeField] public bool _canBomb;
    public void OnUseBomb(InputAction.CallbackContext context)
    {
        if (!_canBomb) return;

        if (context.performed)
        {

        }
    }
}
