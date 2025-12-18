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
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
