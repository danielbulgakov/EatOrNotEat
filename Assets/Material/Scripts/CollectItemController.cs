using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemController : MonoBehaviour
{
    public GameObject Item;
    public Rigidbody RB;
    
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void NewBall()
    {
        if (Random.Range(1,3) == 1)
        {
            Item.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            Item.GetComponent<Renderer>().material.color = Color.red;
        }

        Vector3 RandomNextPos = new Vector3(Random.Range(-14.0f, 14.0f), 0.5f, Random.Range(-14.0f, 14.0f));
        this.transform.position = RandomNextPos;

    }
}
