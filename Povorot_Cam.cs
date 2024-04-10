using UnityEngine;

public class Povorot_Cam : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 2f;
    public float maxLookUpAngle = 80f; // Максимальный угол взгляда вверх
    public float maxLookDownAngle = 80f; // Максимальный угол взгляда вниз

    void Update()
    {
        RotatePlayerWithMouse();
        RotateCameraWithMouse();
    }

    void RotatePlayerWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        playerTransform.Rotate(Vector3.up * mouseX);
    }

    void RotateCameraWithMouse()
    {
        float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed;

        // Вращаем камеру вокруг своей оси Y
        transform.Rotate(Vector3.right * mouseY);

        // Ограничиваем угол наклона взгляда вверх и вниз
        float currentRotationX = transform.localEulerAngles.x;
        currentRotationX = (currentRotationX > 180f) ? currentRotationX - 360f : currentRotationX;

        float clampedRotationX = Mathf.Clamp(currentRotationX, -maxLookUpAngle, maxLookDownAngle);

        // Применяем ограничение угла наклона
        transform.localEulerAngles = new Vector3(clampedRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
