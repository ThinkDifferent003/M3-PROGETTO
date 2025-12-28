using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.SetParent(other.transform);
            transform.localPosition = Vector3.zero;
            Rigidbody2D _rb = GetComponent<Rigidbody2D>();
            if (_rb != null )
            {
                _rb.simulated = false;
            }
            Gun _gun = GetComponent<Gun>();
            if (_gun != null )
            {
                _gun.enabled = true;
            }
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
