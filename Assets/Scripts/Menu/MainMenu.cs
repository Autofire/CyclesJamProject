using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private string targetScene;

	public void LoadGame() {
		SceneManager.LoadScene(targetScene);
	}

	public void QuitGame() {
		Debug.Log("Quit");
		Application.Quit();
	}
}
