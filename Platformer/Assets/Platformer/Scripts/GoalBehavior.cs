using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        GameObject.Find("GameManager").GetComponent<GameManager>().hitGoal();
        Destroy(gameObject);
    }
}
