using UnityEngine;
using System.Collections;

public class TargetFollow : MonoBehaviour {
	public Transform targetToFollow;
	public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

	public void FixedUpdate () {
		Vector3 destination = targetToFollow.position;
		destination.y = transform.position.y;
		destination.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}
