using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour {
    [SerializeField]
    private float m_Speed=1;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up,m_Speed,Space.Self);
    }
}
