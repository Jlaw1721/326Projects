using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Mario Basic"){
            GameObject.Find("GameManager").GetComponent<GameManager>().hitCoin();
            Destroy(gameObject);
        }
    }
}
