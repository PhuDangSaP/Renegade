using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("isSitting", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("isSitting", false);
        }
    }
}
