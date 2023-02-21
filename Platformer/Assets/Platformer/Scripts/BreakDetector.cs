using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakDetector : MonoBehaviour
{
    public new Camera camera;
    public TextMeshProUGUI coinText;
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("?"))
                {
                    coins++;
                    if (coins < 10)
                    {
                        coinText.text = $"C x 0{coins}";
                    }
                    else
                    {
                        coinText.text = $"C x {coins}";
                    }
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.gameObject.CompareTag("Brick"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }

        }
    }
}
