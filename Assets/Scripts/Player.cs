using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

/*
    [DllImport("DllHeight.dll")]
    public static extern void initHeight(int DLLHeight);
    //public static extern int setHeight(int a);

    [DllImport("DllHeight.dll")]
    public static extern int getHeight();
*/
    [SerializeField]
    int DLLHeight;

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

    private void Start()
    {
       
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
}

[System.Serializable]
class Height
{
    
    public int heightincrease;
}