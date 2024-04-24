using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator anim;
    bool isMoving;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 playerInput = GetPlayerInput();

        if (playerInput != Vector3.zero && !isMoving)
        {
            isMoving = true;
            anim.SetBool("IsWalking", true);
        }
        else if (playerInput == Vector3.zero)
        {
            isMoving = false;
            anim.SetBool("IsWalking", false);
        }

        float currGrav = GetGravity();

        ApplyControlMotion(playerInput);
        ApplyGravity(currGrav);
    }

    private Vector3 GetPlayerInput()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    private void ApplyControlMotion(Vector3 inputDirection)
    {
        _rb.velocity = ((transform.forward * inputDirection.z) + (transform.right * inputDirection.x)) * _movementSpeed;
    }

    private float GetGravity()
    {
        return _rb.velocity.y;
    }

    private void ApplyGravity(float grav)
    {
        _rb.velocity = new Vector3(_rb.velocity.x, grav, _rb.velocity.z);
    }


}
