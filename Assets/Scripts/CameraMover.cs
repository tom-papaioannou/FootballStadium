using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMoverNewInput : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float boostMultiplier = 3f;

    void Update()
    {
        Vector2 moveInput = Vector2.zero;

        // Read arrow keys from the new Input System
        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed) moveInput.x -= 1f;
            if (Keyboard.current.rightArrowKey.isPressed) moveInput.x += 1f;
            if (Keyboard.current.upArrowKey.isPressed) moveInput.y += 1f;
            if (Keyboard.current.downArrowKey.isPressed) moveInput.y -= 1f;
        }

        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);

        // Move in camera's local space
        move = transform.TransformDirection(move);

        float speed = moveSpeed;

        // Hold Shift to move faster
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed)
            speed *= boostMultiplier;

        transform.position += move * speed * Time.deltaTime;
    }
}
