using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Risar_Muve : MonoBehaviour
{
    private Rigidbody rb; // ������ �� Rigidbody ���������
    public float Speed = 3f;
    public Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // �������� ������
        Cursor.visible = false;

        // ��������, ��� � ��� ���� ������ �� ������� ������ � �����
        if (Camera.main != null)
        {
            mainCamera = Camera.main;
        }

    }

    void Update()
    {
        // ���������, ���� �� ���������������� ���������� mainCamera
        if (mainCamera != null)
        {
            // �������� ���� �� ����������
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // �������� ����������� ������� ������
            Vector3 cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0f; // �������� ���������� y, ����� �������� ������� ����� ��� ����

            // �������� ������ �������� �� ������ WASD
            Vector3 moveDirection = (cameraForward * v + mainCamera.transform.right * h).normalized;

            // ����������� ��������
            rb.MovePosition(rb.position + moveDirection * Speed * Time.deltaTime);
        }
        else
        {
            Debug.LogError("������� ������ �� ���� ����������������!");
        }
    }
}
