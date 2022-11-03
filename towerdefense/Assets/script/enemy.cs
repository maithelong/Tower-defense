using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour

{
    public float speed = 10f;
    public Transform target;
    public int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoint.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir=target.position-transform.position;
        //dir.normalize làm cho vector giữ nguyên 1 hướng đi 
        //space.world là tham số để enemy thực hiện di chuyển trong không gian world ><space.self
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position,target.position)<=0.2f)
        {
            getNextWayPoint();
        }    
    }
    void getNextWayPoint()
    {
        if(wayPointIndex>=waypoint.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }  
        wayPointIndex++;
        target=waypoint.points[wayPointIndex];
    }    
}
