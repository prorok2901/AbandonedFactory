using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform _player;

    private float _mouseX;

    private float _mouseY;
    private float _xRotation;
    [SerializeField] private float _sensivityMouse;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensivityMouse * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensivityMouse * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(xRotation, -80f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        _player.Rotate(Vector3.up * _mouseX);
    }
}
