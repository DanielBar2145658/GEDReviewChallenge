using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // Import functions from DLL
    [DllImport("PLayerJumpHeightDLL.dll")]
    private static extern void SetJumpHeight(float newJumpHeight);

    [DllImport("PlayerJumpHeightDLL.dll")]
    private static extern float GetJumpHeight();



    [SerializeField]
    int DLLHeight;

    InputSystem_Actions inputActions;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed;
    private Vector2 inputRaw;

    [SerializeField] float jumpForce = 5f;

    void Awake()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Enable();

        inputActions.Player.Jump.performed += Jump_performed;

        Debug.Log("current jump force = " + jumpForce);
     
   
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) 
        {
            jumpForce = GetJumpHeight();

            ModifyJumpHeight(jumpForce);

            Debug.Log("new jump force =" + jumpForce);
        
        }

    }

    private void Jump_performed(InputAction.CallbackContext callbackContext)
    {
        rb.AddForce(Vector2.up * (jumpForce ), ForceMode2D.Impulse);
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
            //GameManager.Instance.UpdateText();
            SceneManager.LoadScene(0);
        }
    }

    public void ModifyJumpHeight(float newJumpHeight)
    {
        SetJumpHeight(newJumpHeight);
    }


}

