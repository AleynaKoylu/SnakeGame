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
    TextMeshProUGUI ScoreTxt;
    int score = 0;

    void Start()
    {

        for (int i = 0; i < 5 ; i++)
        {
            GameObject newTail = Instantiate(Tail, transform.position, Quaternion.identity);
            Tails.Add(newTail);
        }
        InvokeRepeating("Movement", 0, 0.1f);
    }


   
    void Movement()
    {
        oldTransform = transform.position;
        transform.Translate(0, 0, speed * Time.deltaTime);
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
            score += 10;
            ScoreTxt.text = "Score: " + score;
        }
    }
}
