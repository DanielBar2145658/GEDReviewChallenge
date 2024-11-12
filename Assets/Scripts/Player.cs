using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    InputSystem_Actions inputActions;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed;
    private Vector2 inputRaw;

    private float jumpForce = 10f;

    void Awake()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Enable();

        inputActions.Player.Jump.performed += Jump_performed;

        

        
    }

 
    private void Jump_performed(InputAction.CallbackContext callbackContext)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


 
    private void FixedUpdate()
    {
        Vector2 inputMovement = inputActions.Player.Move.ReadValue<Vector2>();
        rb.linearVelocityX = inputMovement.x * speed ;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish")) 
        {
            GameManager.Instance.playerData.AddScore(500);
            GameManager.Instance.UpdateText();
        }
    }
}
