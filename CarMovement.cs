using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
     quueue up
       Add Colission for cars
     fix direction they leave
         */
public class CarMovement : MonoBehaviour

{
    public bool inCircle = false;
    public bool exiting = false;
    public bool stopped = false;//make this affect the whole road including new spawned
    public bool entering = true;

    private Vector3 center = new Vector3(0, .2f, 0);
    private Vector3 carAngle; //Y component

    private float speed = 2.0f;
    private float radius = 4.0f;//not used
    private float distanceToCenter;

    public int spawnRoad = 0;
    public int exitRoad = 1;
    public string exitTrigger;
    private TrafficControl tc;

    //if stopped and close to entrance then stop
    //if on entry and within dist of car in front
    private void Awake()
    {
        GameObject gameManager = GameObject.FindWithTag("GameController");
        tc = gameManager.GetComponent<TrafficControl>();
    }

    void Start()
    {
        stopped = tc.isStopped[spawnRoad];
    }

    void Update()
    {
        stopped = tc.isStopped[spawnRoad];
        distanceToCenter = Vector3.Distance(transform.position, center);

        if (distanceToCenter < radius)
        {
            inCircle = true;
            stopped = false;
            entering = false;
        }

        if(distanceToCenter > 30f)
        {
            Destroy(gameObject);
        }

        //stops the car 
        if (stopped == true && distanceToCenter > radius && distanceToCenter <= radius + 3f)//&& exiting == false
        {
            transform.position = transform.position;
        }

        //Goes around if in cricle
        if (inCircle == true && exiting == false)
        {
            GoAround();
        }

        if (exiting == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, center, -1 * speed * Time.deltaTime);
        }

        if (entering == true && stopped == false)//&& stopped == false || distanceToCenter >= radius+2.5f
        {
            transform.position = Vector3.MoveTowards(transform.position, center, speed * Time.deltaTime);
            transform.LookAt(center);
        }//clean this up to include else stop

       
        if (Input.GetKeyDown("e") && inCircle == true)
        {
            Exit();
        }
    }

    void GoAround()
    {
        transform.RotateAround(center, new Vector3(0,-1,0), speed/2 );
        transform.LookAt(center);//faces hood toward center
        carAngle = new Vector3(0, 90, 0);//rotates to perpendicular
        transform.Rotate(carAngle);

    }
    void Exit()
    {
        exiting = true;
        inCircle = false;
        stopped = false;
        transform.position = Vector3.MoveTowards(transform.position, center, -1 * speed * Time.deltaTime);
        carAngle = new Vector3(0, 90, 0);//rotates to perpendicular
        transform.Rotate(carAngle);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == exitTrigger)
        {
            Exit();
            Debug.Log("Exiting via exitRoad" + exitTrigger);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("FENDER BENDER");
        }
    }


}
