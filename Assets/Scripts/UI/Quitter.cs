using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitter : MonoBehaviour
{
	public void QuitGame() {
		Debug.Log("I quit!");
		Application.Quit();
	}
}
