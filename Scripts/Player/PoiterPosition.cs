using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiterPosition : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private RaycastHit _point;
    private Vector3 _vectorMove;
    private Vector3 _vectorStart;

    private void Start()
    {
        _vectorStart = transform.localPosition;
    }
    private void LateUpdate()
    {
        RayCastCheck(transform.up);
        RayCastCheck(-transform.up);
        RayCastCheck(transform.right);
        RayCastCheck(-transform.right);
        RayCastCheck(transform.forward);
        RayCastCheck(-transform.forward);
    }
    private void RayCastCheck(Vector3 vector)
    {
        if (Physics.Raycast(transform.position, vector , out point, 0.2f))
        {
            if(!_point.collider.CompareTag("Thing"))
            {
                _vectorMove = transform.position + (transform.position - _point.point);
                transform.position = Vector3.MoveTowards(transform.position, _vectorMove, _speed);
            }
            else
            {
                transform.localPosition = _vectorStart;
            }
        }

    }
}
