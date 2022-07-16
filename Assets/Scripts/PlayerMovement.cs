using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float fastSpeed;
    [SerializeField] float slowSpeed;
    
    Rigidbody2D _playerRigidbody;
    CapsuleCollider2D _playerCollider;
    void Awake()
    {
        TryGetComponent(out _playerRigidbody);
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer() 
    {
        if (Touchscreen.current.primaryTouch.press.IsPressed())
        {
            _playerRigidbody.velocity = new Vector2(0f, -fastSpeed);
        }
        else 
        {
            _playerRigidbody.velocity = new Vector2(0f, -slowSpeed);
        }
    }
}
