using UnityEngine;
using System.Collections;

public enum Direction{
	Up,
	Left,
	Right,
	}

public class Knight : MonoBehaviour {
	public float moveDistance;
	private int currentLane;
	private int currentColumn;

	// Use this for initialization
	void Start () {
		currentColumn = 1;
		currentLane = 2;
	}
	
	// Update is called once per frame
	void Update () {
		//Up
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			Move(Direction.Up);
		}

		//Left
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			Move(Direction.Left);
		}

		//Right
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			Move(Direction.Right);
		}
	}

	void Move(Direction direction){
		//Temp
		Vector3 newPosition = transform.position;

		//Up
		if(direction == Direction.Up){
			currentColumn++;
			newPosition.x -= moveDistance;
		}


		//Left
		if(direction == Direction.Left){
			if((currentLane - 1) > 0){
				currentLane--;
				newPosition.z -= moveDistance;
			}
		}

		//Right
		if(direction == Direction.Right){
			if((currentLane + 1) < 4){
				currentLane++;
				newPosition.z += moveDistance;
			}
		}

		//Move
		transform.position =  newPosition;
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log(transform.name + " collision with " + collision.transform.name);     
    }

    void OnTriggerEnter(Collider other){
		Debug.Log(transform.name + " triggered " + other.transform.name);     
    }
}
