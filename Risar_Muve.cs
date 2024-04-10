using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Risar_Muve : MonoBehaviour
{
    private Rigidbody rb; // Ссылка на Rigidbody персонажа
    public float Speed = 3f;
    public Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Скрываем курсор
        Cursor.visible = false;

        // Убедимся, что у нас есть ссылка на главную камеру в сцене
        if (Camera.main != null)
        {
            mainCamera = Camera.main;
        }

    }

    void Update()
    {
        // Проверяем, была ли инициализирована переменная mainCamera
        if (mainCamera != null)
        {
            // Получаем ввод от клавиатуры
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // Получаем направление взгляда камеры
            Vector3 cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0f; // Обнуляем компоненту y, чтобы избежать наклона вверх или вниз

            // Получаем вектор движения от клавиш WASD
            Vector3 moveDirection = (cameraForward * v + mainCamera.transform.right * h).normalized;

            // Передвигаем персонаж
            rb.MovePosition(rb.position + moveDirection * Speed * Time.deltaTime);
        }
        else
        {
            Debug.LogError("Главная камера не была инициализирована!");
        }
    }
}
