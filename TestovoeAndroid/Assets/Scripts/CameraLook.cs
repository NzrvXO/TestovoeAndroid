using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 100f;
    [SerializeField] private float _minVerticalAngle = -80f; 
    [SerializeField] private float _maxVerticalAngle = 80f; 

    private Vector2 _lastTouchPosition;
    private bool _isDragging;
    private float _xRotation = 0f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _lastTouchPosition = touch.position;
                _isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && _isDragging)
            {
                Vector2 delta = touch.position - _lastTouchPosition;

                transform.Rotate(0, delta.x * _sensitivity * Time.deltaTime, 0);

                _xRotation -= delta.y * _sensitivity * Time.deltaTime;
                _xRotation = Mathf.Clamp(_xRotation, _minVerticalAngle, _maxVerticalAngle);
                Camera.main.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

                _lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _isDragging = false;
            }
        }

        //void HandleMouse()
        //{
        //    if (Input.GetMouseButtonDown(0)) // Нажатие ЛКМ
        //    {
        //        _lastTouchPosition = Input.mousePosition;
        //        isDragging = true;
        //    }
        //    else if (Input.GetMouseButton(0) && isDragging) // Перемещение с зажатой ЛКМ
        //    {
        //        Vector2 delta = (Vector2)Input.mousePosition - _lastTouchPosition;
        //        float mouseX = delta.x * _sensitivity * Time.deltaTime;
        //        float mouseY = delta.y * _sensitivity * Time.deltaTime;

        //        // Горизонтальный поворот (лево-вправо)
        //        transform.Rotate(Vector3.up * mouseX);

        //        // Вертикальный поворот (вверх-вниз) с ограничением угла
        //        _xRotation -= mouseY;
        //        _xRotation = Mathf.Clamp(_xRotation, _minVerticalAngle, _maxVerticalAngle);
        //        transform.localRotation = Quaternion.Euler(_xRotation, transform.localEulerAngles.y, 0f);

        //        _lastTouchPosition = Input.mousePosition;
        //    }
        //    else if (Input.GetMouseButtonUp(0)) // Отпустили ЛКМ
        //    {
        //        isDragging = false;
        //    }
        //}        //void HandleMouse()
        //{
        //    if (Input.GetMouseButtonDown(0)) // Нажатие ЛКМ
        //    {
        //        _lastTouchPosition = Input.mousePosition;
        //        isDragging = true;
        //    }
        //    else if (Input.GetMouseButton(0) && isDragging) // Перемещение с зажатой ЛКМ
        //    {
        //        Vector2 delta = (Vector2)Input.mousePosition - _lastTouchPosition;
        //        float mouseX = delta.x * _sensitivity * Time.deltaTime;
        //        float mouseY = delta.y * _sensitivity * Time.deltaTime;

        //        // Горизонтальный поворот (лево-вправо)
        //        transform.Rotate(Vector3.up * mouseX);

        //        // Вертикальный поворот (вверх-вниз) с ограничением угла
        //        _xRotation -= mouseY;
        //        _xRotation = Mathf.Clamp(_xRotation, _minVerticalAngle, _maxVerticalAngle);
        //        transform.localRotation = Quaternion.Euler(_xRotation, transform.localEulerAngles.y, 0f);

        //        _lastTouchPosition = Input.mousePosition;
        //    }
        //    else if (Input.GetMouseButtonUp(0)) // Отпустили ЛКМ
        //    {
        //        isDragging = false;
        //    }
        //}        //void HandleMouse()
        //{
        //    if (Input.GetMouseButtonDown(0)) // Нажатие ЛКМ
        //    {
        //        _lastTouchPosition = Input.mousePosition;
        //        isDragging = true;
        //    }
        //    else if (Input.GetMouseButton(0) && isDragging) // Перемещение с зажатой ЛКМ
        //    {
        //        Vector2 delta = (Vector2)Input.mousePosition - _lastTouchPosition;
        //        float mouseX = delta.x * _sensitivity * Time.deltaTime;
        //        float mouseY = delta.y * _sensitivity * Time.deltaTime;

        //        // Горизонтальный поворот (лево-вправо)
        //        transform.Rotate(Vector3.up * mouseX);

        //        // Вертикальный поворот (вверх-вниз) с ограничением угла
        //        _xRotation -= mouseY;
        //        _xRotation = Mathf.Clamp(_xRotation, _minVerticalAngle, _maxVerticalAngle);
        //        transform.localRotation = Quaternion.Euler(_xRotation, transform.localEulerAngles.y, 0f);

        //        _lastTouchPosition = Input.mousePosition;
        //    }
        //    else if (Input.GetMouseButtonUp(0)) // Отпустили ЛКМ
        //    {
        //        isDragging = false;
        //    }
        //}
    }
}
