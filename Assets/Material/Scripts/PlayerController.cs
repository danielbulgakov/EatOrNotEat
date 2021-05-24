using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hSpeed;
    private Rigidbody BallRB;
    //public GameObject Player;
    public GameObject CollObjs;
    private float BallTime = 5f;
    private float NextBallTime = 0.0f;
    private float ScaleSizeDecrease = 0.95f;
    private float EatGood = 1.2f;
    private float EatBad = 0.75f;

    private float MinSize = 0.6f;
    private float MaxSize = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        BallRB = GetComponent<Rigidbody>();
        hSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        Vector3 Move = new Vector3(xMove, 0.0f, yMove);

        if (Time.time > NextBallTime)
        {
            NextBallTime = Time.time + BallTime;
            CollObjs.transform.GetChild(0).SendMessage("NewBall", SendMessageOptions.DontRequireReceiver);
            CollObjs.transform.GetChild(1).SendMessage("NewBall", SendMessageOptions.DontRequireReceiver);
            CollObjs.transform.GetChild(2).SendMessage("NewBall", SendMessageOptions.DontRequireReceiver);
            if (BallRB.transform.localScale.x > MinSize)
                BallRB.transform.localScale *= ScaleSizeDecrease;
        }                
        BallRB.AddForce(Move * hSpeed);
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Collectable"))
        {            
            if (other.GetComponent<Renderer>().material.color == Color.green)
            {
                if (BallRB.transform.localScale.x < MaxSize)
                    BallRB.transform.localScale *= EatGood;
            }
            else 
            {
                if (BallRB.transform.localScale.x > MinSize)
                    BallRB.transform.localScale *= EatBad ;
            }
            NextBallTime = Time.time;
            CollObjs.transform.Find(other.gameObject.name).SendMessage("NewBall", SendMessageOptions.DontRequireReceiver);
            Debug.Log(other.gameObject.name);
        }        
    }

   
    
}
