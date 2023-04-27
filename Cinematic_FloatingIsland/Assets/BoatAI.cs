using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAI : MonoBehaviour
{
   [Header("Waypoints")]
   [Space]
    public List<GameObject> waypoints;
    public float speed;
    private int index = 0;
   
    [Space]
    [Header(" Roation")]
    public float turnSpeed;
    Quaternion rotGoal;
    Vector3 direction;
  //  public float lookSpeed;
  //  private Coroutine LookCouroutine;
   
    void Start()
    {
        
    }

  
    void Update()
    {
        //StartRotating();
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos=Vector3.MoveTowards(transform.position, waypoints[index].transform.position,speed*Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position,destination);
        if(distance <=0.05)
        {
            if(index < waypoints.Count-1)
            {
                index++;
            }
            
        }

        direction = (waypoints[index].transform.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direction);
       transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
      //  transform.LookAt(waypoints[index].transform.position);
       // Debug.Log("OFF");
       // StartRotating();
    }
    /*

    public void StartRotating()
    {
      if(LookCouroutine !=null)
        {
            //Debug.Log("OFF1");
            StopCoroutine(LookCouroutine);
        }
        //Debug.Log("ON");
        LookCouroutine = StartCoroutine(LookAt());
    }


    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(waypoints[index].transform.position - transform.position);

        float time = 0;

        while(time<1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * lookSpeed;
            Debug.Log(lookRotation);
            yield return null;
        }
    }

  */
}
