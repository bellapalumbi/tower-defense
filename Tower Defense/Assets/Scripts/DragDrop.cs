using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {

	private Vector3 offset;
	Vector2 currentPos;
	private float myY;
	private bool canbeDragDropped = true;

	public bool hasSnapped;

	public GameObject EnergyManager;

	EnergyManager EnergyScript;


	public int myCost;




	void Start() {
		currentPos = gameObject.transform.position;
		//print(currentPos);
		hasSnapped = false;
		myCost = 4;
		EnergyScript = EnergyManager.GetComponent<EnergyManager>();
	}
	void OnMouseDown () {
		if (canbeDragDropped) {
			//moves object in relation to the mouse drag by finding the 'offset' using camera.main.screentoworld point. The 10.0f is the distance from the cam to object
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
		}
	}
	
	void OnMouseDrag() {
		if (canbeDragDropped) {
			Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
			transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
		}
	}

	void OnMouseUp() {
		
		//stores current energy value in currentEnergy
		print("From DragDrop: energy is " + EnergyScript.energy);
		if (gameObject.transform.position.y < 2.5f && EnergyScript.energy >= myCost) { 
			//if it's been placed on the field and user has the EP to place it
			if (gameObject.tag == "Defender") {
				//if the defender is the kind that needs to move, and be dropped onto a "melee" row
				ChooseRow();
				gameObject.GetComponent<MyMovement>().enabled = true;
			} else if (gameObject.tag == "AoE") {
				//put code for calling RainDamange function or whatever here!!
			}
			canbeDragDropped = false;
			//makes it so that it can no longer be picked up
			EnergyScript.energy -= myCost;
			print("From DragDrop: energy is " + EnergyScript.energy);
		}
		else {
			transform.position = new Vector3 (currentPos.x, currentPos.y, -0.5f); 
			//moves back to original position in cards
		}
	}


	void SnapTo (float row) {
		transform.position = new Vector3 (transform.position.x, row, -0.5f); 
		hasSnapped = true;
	}

	void ChooseRow() {
		myY = transform.position.y;
		if (myY < 2.5f && myY > 0.5f) {
			SnapTo(1.35f);
		} else if (myY < 0.5f && myY > -2) {
			SnapTo(-0.62f);
		} else if (myY < -2 && myY > -4f) {
			SnapTo(-2.34f);
		} else if (myY < -4f) {
			SnapTo(-4);
		}
	}
}
