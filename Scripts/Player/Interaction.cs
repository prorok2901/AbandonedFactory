using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    private AudioSource _audioLever;

    [SerializeField] private Transform _pointer;
    [SerializeField] private Text _textCenter;
    [SerializeField] private AudioClip _din;
    [SerializeField] private Camera _meinCamera;

    private RaycastHit _pointView;
    private Rigidbody _rigidbodyObl;

    void Start()
    {
        _textCenter.text = " ";
        _audioLever = GetComponent<AudioSource>();
    }
    private void LateUpdate()
    {
        if (Physics.Raycast(_meinCamera.ScreenPointToRay(Input.mousePosition), out _pointView))
        {
            LeverArm();
            brat();
        }
        else
        {
            _textCenter.text = " ";
        }
        if (_rigidbodyObl != null)
        {
            _rigidbodyObl.isKinematic = false;
        }

    }
    void LeverArm()
    {
        if (_pointView.collider.CompareTag("LeverArm") && _pointView.distance <= 5)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                _audioLever.PlayOneShot(_din);
                _textCenter.text = " ";
            }
            else
            {
                _textCenter.text = "Е - использовать";
            }
        }
    }

    void brat()
    {

        if (_pointView.collider.CompareTag("Thing") && _pointView.distance <= 5)
        {

            if (Input.GetKey(KeyCode.E))
            {
                _rigidbodyObl = _pointView.collider.GetComponent<Rigidbody>();
                _rigidbodyObl.isKinematic = true;
                _pointView.collider.transform.position = _pointer.position;
                _textCenter.text = " ";
            }
            else
            {
                _textCenter.text = "Е - взять";
            }
        }
        else
        {
            _textCenter.text = " ";
        }

    }
}
