using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{

    
    void Start()
    {

        InvokeRepeating("Active", 0, 0.1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tail"))
        {
            TomatoMovement();
        }
    }
    void Active()
    {
        if (gameObject.activeSelf == false)
        {
            TomatoMovement();
            gameObject.SetActive(true);
        }
      
    }
    void TomatoMovement()
    {
        gameObject.transform.position = new Vector3(Random.Range(-11.99f, 13.99f), transform.position.y, Random.Range(-1.99f, 11.99f));
    }
  
}
