using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : AbstractApplier
{
	[SerializeField] private string targetScene;

	[Space(10)]
	[SerializeField] private float loadDelay;

	public void LoadSceneNow() {
		SceneManager.LoadScene(targetScene);
	}

	override public void Apply() {
		BeginAsyncLoad();
	}

	public void BeginAsyncLoad() {
		StartCoroutine(AsyncLoad());
	}

	// This loads asyncronously, and opens new scene once the delay has passed
	// and the scene has been loaded.
	IEnumerator AsyncLoad() {

		// Apply our initial delay
		yield return new WaitForSeconds(loadDelay);

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);

		// Wait until the asynchronous scene fully loads
		while (!asyncLoad.isDone) {
			yield return null;
		}
	}
}
