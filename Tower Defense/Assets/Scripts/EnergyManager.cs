using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {

	

	public int energy;

	public Text energyText;

	void Start() {
		//energy = 0;
		StartCoroutine(IncreaseEnergy());
	}

	

	IEnumerator IncreaseEnergy () {
		while (energy < 10) {
			energy += 1;
			print("energy is " + energy);
			energyText.text = "Energy Points: " + energy;
			yield return new WaitForSeconds(1.5f);
		}
	}

}
