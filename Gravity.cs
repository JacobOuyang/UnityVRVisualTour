using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
    public Collider coll;
    void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.useGravity = false;

    }
}