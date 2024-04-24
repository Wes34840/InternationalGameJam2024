using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _movementSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 playerInput = GetPlayerInput();
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
