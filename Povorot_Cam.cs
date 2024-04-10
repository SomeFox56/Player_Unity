using UnityEngine;

public class Povorot_Cam : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 2f;
    public float maxLookUpAngle = 80f; // ������������ ���� ������� �����
    public float maxLookDownAngle = 80f; // ������������ ���� ������� ����

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

        // ������� ������ ������ ����� ��� Y
        transform.Rotate(Vector3.right * mouseY);

        // ������������ ���� ������� ������� ����� � ����
        float currentRotationX = transform.localEulerAngles.x;
        currentRotationX = (currentRotationX > 180f) ? currentRotationX - 360f : currentRotationX;

        float clampedRotationX = Mathf.Clamp(currentRotationX, -maxLookUpAngle, maxLookDownAngle);

        // ��������� ����������� ���� �������
        transform.localEulerAngles = new Vector3(clampedRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
