using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnim : MonoBehaviour {

    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;

    // Use this for initialization
    void Start () {
        lastWaypointSwitchTime = Time.time;

    }
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 startPostion = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        float pathDistansce = Vector3.Distance(startPostion, endPosition);
        float totTimeForonPath = pathDistansce / speed;
        float currentForOnPath = Time.time - lastWaypointSwitchTime;
        transform.position = Vector3.Lerp(startPostion, endPosition, currentForOnPath / totTimeForonPath);

        if (transform.position.x==endPosition.x||transform.position.y==endPosition.y)
        {
            //print(currentWaypoint);
            if (currentWaypoint < waypoints.Length - 2)
            {

                currentWaypoint++;

                lastWaypointSwitchTime = Time.time;
                RotateIntoMoveDirection();
                //print(currentWaypoint);
            }
            else
            {
                Destroy(gameObject);
            }

        }
	}

    private void RotateIntoMoveDirection()
    {
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;

        Vector3 newDistance = newEndPosition - newStartPosition;

        float x = newDistance.x;
        float y = newDistance.y;

        float anglyRot = Mathf.Atan2(x, -y) * 180 / Mathf.PI;

        transform.rotation = Quaternion.AngleAxis(anglyRot,Vector3.forward);


    }
}
