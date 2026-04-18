using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    bool isEditing = false;

    void Start()
    {
        LockCursor();
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {

        // Toggle mode
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isEditing = !isEditing;

            if (isEditing)
                UnlockCursor();
            else
                LockCursor();
        }

        // 🚫 Stop movement when editing
        if (isEditing)
            return;


        // MOUSE LOOK
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y + mouseX, 0f);

        // MOVEMENT
        float forward = Input.GetAxis("Vertical");   // W/S
        float side = Input.GetAxis("Horizontal");    // A/D

        Vector3 move = transform.forward * forward + transform.right * side;
        transform.position += move * speed * Time.deltaTime;
    }
}