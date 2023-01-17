using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, MinValue(0)]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _moveInput;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition((Vector2)transform.position + (_moveInput.normalized * _speed));
    }

    public void Move(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }
}
