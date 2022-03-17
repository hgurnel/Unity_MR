using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes sure rotations around frozen axes are actually not possible
// Directly taken from: https://www.youtube.com/watch?v=maIAiSRBEdE

public class RotationFixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
    }
}
