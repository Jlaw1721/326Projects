using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Mario Basic"){
            other.gameObject.transform.position = new Vector3(10.78f, 1.6f, 0f);
            GameObject.Find("GameManager").GetComponent<GameManager>().hitWater();
        }
    }
}
