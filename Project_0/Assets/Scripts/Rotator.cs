using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Transform t = GetComponent<Transform>();
        t.Rotate(new Vector3(0f, 1f, 0));
    }
}
