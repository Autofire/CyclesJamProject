using UnityEngine;
using UnityEngine.Assertions;
using ReachBeyond.VariableObjects;

public class ClockDisplay : MonoBehaviour
{
	[SerializeField] private TMPro.TextMeshProUGUI textObj;
	[SerializeField] private FloatConstReference startTime;

	private void Awake() {
		Assert.IsNotNull(textObj);
	}


	private void OnGUI() {
		float currentTime = Time.time - startTime.ConstValue;

		int minutes = ((int)currentTime) / 60;
		int seconds = ((int)currentTime) % 60;
		float secondFraction = currentTime % 1f;
		int milliseconds = Mathf.RoundToInt(secondFraction * 1000f);

		string[] timerValues = new string[] { 
			minutes.ToString("D2"), seconds.ToString("D2"), milliseconds.ToString("D3")
		};

		textObj.SetText(string.Join( ":", timerValues ));
	}

}
