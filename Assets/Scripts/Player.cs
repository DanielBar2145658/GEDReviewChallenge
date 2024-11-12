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

    void Awake()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Enable();

        inputActions.Player.Jump.performed += Jump_performed;

        

        
    }

    private void Move_performed()
    {
        Vector2 inputMovement = inputActions.Player.Move.ReadValue<Vector2>();
        inputRaw = new Vector2(inputMovement.x, 0);
    }

    private void Jump_performed(InputAction.CallbackContext callbackContext)
    {
        rb.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        Move_performed();
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
