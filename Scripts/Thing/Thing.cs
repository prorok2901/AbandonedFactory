using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    private Collider _obj;
    private void Start()
    {
        _obj = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        _obj.attachedRigidbody.AddForce(Vector3.up * 20f);
    }
}
