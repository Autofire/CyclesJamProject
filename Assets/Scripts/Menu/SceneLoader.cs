using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private string targetScene;
	public void loadScene() {
		// TODO Make this load async first
		SceneManager.LoadScene(targetScene);
	}
}
