using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {

	

	public int energy;

	public Text energyText;

	void Start() {
		//energy = 0;
		StartCoroutine(IncreaseEnergy(energy));
	}

	

	IEnumerator IncreaseEnergy (int coEnergy) {
		while (coEnergy < 10) {
			coEnergy += 1;
			print("energy is " + energy);
			energyText.text = "Energy Points: " + coEnergy;
			energy = coEnergy;
			yield return new WaitForSeconds(1.5f);
		}
	}

}
