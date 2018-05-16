using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {

	private Vector3 offset;
	Vector2 currentPos;
	private float myY;
	private bool canbeDragDropped = true;

	private bool hasHitElement = false;


	void Start() {
		currentPos = gameObject.transform.position;
		print(currentPos);
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
		if (gameObject.transform.position.y > 2.5f) { 
			transform.position = new Vector3 (currentPos.x, currentPos.y, -0.5f); 
			print("currentPos is " + currentPos);
		} else {
			ChooseRow();
			print("has called ChooseRow");
			gameObject.GetComponent<MyMovement>().enabled = true;
			canbeDragDropped = false;
		}
	}

	void SnapTo (float row) {
		transform.position = new Vector3 (transform.position.x, row, -0.5f); 
	}

	void ChooseRow() {
		myY = transform.position.y;
		if (myY < 2.5f && myY > 0.5f) {
			SnapTo(1.35f);
		} else if (myY < 0.5f && myY > -2) {
			SnapTo(-0.62f);
		} else if (myY < -2 && myY > -4.5f) {
			SnapTo(-2.34f);
		} else if (myY < -4.5f) {
			SnapTo(-4);
		}
	}
}
