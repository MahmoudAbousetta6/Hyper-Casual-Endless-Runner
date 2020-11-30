using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {
	public Transform spike;
	public string playerTag = "Player";
	public float activeDuration = 2f;
	public float inactiveDuration = 2f;
	public bool startActive = true;
	public bool randomize = false;
	private bool isActive;

	void Start () {
		if(startActive){
			SetActive();
		}
		else{
			SetInactive();
		}
	}

	void SetActive(){
		float duration = activeDuration;
		isActive = true;
		spike.gameObject.SetActive(true);
		if(randomize){
			duration = Random.Range(activeDuration * .25f, activeDuration * 1.25f);
		}
		Invoke("SetInactive",duration);
	}

	void SetInactive(){
		float duration = activeDuration;
		isActive = false;
		spike.gameObject.SetActive(false);
		if(randomize){
			duration = Random.Range(inactiveDuration * .25f, inactiveDuration * 1.25f);
		}
		Invoke("SetActive",duration);
	}

	public bool GetStatus(){
		return isActive;
	}
}
