using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpSpeed = 3f;
    [SerializeField] private float _gravity = -9.8f;

    private Vector3 _velocity;
    private Vector3 _move;

    private bool _isDashing = false;
    private float _elapsedTime = 0f;
    public float dashTime = 1f;
    public float dashSpeed = 60f;
    

    private CharacterController _character = null;

    void Start()
    {
        _character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_character.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        _move = transform.right * X + transform.forward * Z;

        if (!isDashing)
        {
            _character.Move(_speed * Time.deltaTime * _move);

            _velocity.y += _gravity * Time.deltaTime;
            _character.Move(_velocity * Time.deltaTime);


            if (Input.GetKey("c"))
            {
                _character.height = 1f;
            }
            else
            {
                _character.height = 2f;
            }
            if (Input.GetButtonDown("Jump") && _character.isGrounded)
            {
                _velocity.y += Mathf.Sqrt(_jumpSpeed * -2f * _gravity);
            }
            if (Input.GetKey("left shift") && X == 0 && Z > 0 && _character.isGrounded)
            {
                _speed = 20f;
            }
            else
            {
                _speed = 10f;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            _isDashing = true;
            
        }

        if(_elapsedTime < dashTime && _isDashing)
        {
            _elapsedTime += Time.deltaTime;
            if (X > 0 || X < 0)
                Dash(transform.forward * X);
            else return;

            if (Z > 0 || Z < 0)
            {
                Dash(transform.right * Z);
            }
            else
            {
                _isDashing = false;
            }
        }
        else
        {
            _elapsedTime = 0f;
        } 
    }

    private void Dash(Vector3 vectorMove)
    {
        _isDashing = true;
        _speed = 50f;
        transform.position = Vector3.MoveTowards(transform.position, vectorMove, _speed * Time.deltaTime);
    }
}


