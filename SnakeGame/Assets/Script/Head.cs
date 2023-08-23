using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Head : MonoBehaviour
{
    [SerializeField]
    GameObject Tail;
    List<GameObject> Tails = new List<GameObject>();

    Vector3 oldTransform;
    GameObject oldTail;

    public float speed;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    GameObject GameOverPanel;

   

    void Start()
    {

        for (int i = 0; i < 2 ; i++)
        {
            NewTail();
        }
        InvokeRepeating("Movement", 0, 0.1f);
    }


   void NewTail()
    {
        GameObject newTail = Instantiate(Tail, transform.position, Quaternion.identity);
        Tails.Add(newTail);
      
    }
    void Movement()
    {
        oldTransform = transform.position;
        transform.Translate(0, 0, gameManager.speedS * Time.deltaTime);
        
        FollowHead();
        
    }
    void FollowHead()
    {
        Tails[0].transform.position = oldTransform;
        oldTail = Tails[0];
        Tails.RemoveAt(0);
        Tails.Add(oldTail);
    }
    public void RotateSnake(int angel)
    {
        transform.Rotate(0, angel, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tomato"))
        {
            other.gameObject.SetActive(false);
            gameManager.Score();
            NewTail();
        }
        if (other.gameObject.CompareTag("Tail")||other.gameObject.CompareTag("Wall"))
        {
            gameManager.TimeStats(0);
            GameOverPanel.SetActive(true);
        }
    }
}
