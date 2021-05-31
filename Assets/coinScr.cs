using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScr : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other != null);
        if (other != null)
        {
            Destroy(gameObject);
        }
    }
}
