using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Transform[] waypoints;
    public float speed = 1.0f;
    public int currentWaypoint = 0;
    public bool isDead = false;

    void Update () {
        if(isDead){
            return;
        }
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length) {
                currentWaypoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
    }
}