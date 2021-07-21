using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficControl : MonoBehaviour
{
    public  GameObject[] StopSigns = new GameObject[4];
    public  bool[] isStopped = new bool[4];

    void Start()
    {
        isStopped[0] = false;
        isStopped[1] = false;
        isStopped[2] = false;
        isStopped[3] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == StopSigns[0].name)
                {
                    if (isStopped[0] == true)//&& entering == true
                    {
                        isStopped[0] = false;
                        Debug.Log("Stopped changed to false isStopped[0]");
                    }
                    else if (isStopped[0] == false)//&& entering == true
                    {
                        isStopped[0] = true;
                        Debug.Log("Stopped changed to true isStopped[0]");
                    }
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == StopSigns[1].name)
                {
                    if (isStopped[1] == true)//&& entering == true
                    {
                        isStopped[1] = false;
                        Debug.Log("Stopped changed to false isStopped[1]");
                    }
                    else if (isStopped[1] == false)//&& entering == true
                    {
                        isStopped[1] = true;
                        Debug.Log("Stopped changed to true isStopped[1]");
                    }
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == StopSigns[2].name)
                {
                    if (isStopped[2] == true)//&& entering == true
                    {
                        isStopped[2] = false;
                        Debug.Log("Stopped changed to false isStopped[2]");
                    }
                    else if (isStopped[2] == false)//&& entering == true
                    {
                        isStopped[2] = true;
                        Debug.Log("Stopped changed to true isStopped[2]");
                    }
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == StopSigns[3].name)
                {
                    if (isStopped[3] == true)//&& entering == true
                    {
                        isStopped[3] = false;
                        Debug.Log("Stopped changed to false isStopped[0]");
                    }
                    else if (isStopped[3] == false)//&& entering == true
                    {
                        isStopped[3] = true;
                        Debug.Log("Stopped changed to true isStopped[0]");
                    }
                }
            }
        }





    }
}
