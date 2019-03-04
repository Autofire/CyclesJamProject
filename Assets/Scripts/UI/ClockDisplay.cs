using UnityEngine;
using UnityEngine.Assertions;
using ReachBeyond.VariableObjects;

public class ClockDisplay : MonoBehaviour
{
	[SerializeField] private TMPro.TextMeshProUGUI textObj;
	[SerializeField] private FloatConstReference startTime;
	[SerializeField] private FloatConstReference endTime;
	[Tooltip("If true, the time between start and end time is shown, and " +
		"no further updates are made")]
	[SerializeField] private bool oneShot = false;

	private void Awake() {
		Assert.IsNotNull(textObj);
	}

	private void OnEnable() {
		if(oneShot) {
			ShowEndTime();
			enabled = false;
		}
	}


	private void OnGUI() {
		textObj.SetText(TimeToStr(Time.time - startTime.ConstValue));
	}


	public void ShowEndTime() {
		textObj.SetText(TimeToStr(endTime.ConstValue - startTime.ConstValue));
	}

	private string TimeToStr(float timeInSeconds) {

		int minutes = ((int)timeInSeconds) / 60;
		int seconds = ((int)timeInSeconds) % 60;
		float secondFraction = timeInSeconds % 1f;
		int milliseconds = Mathf.RoundToInt(secondFraction * 1000f);

		string[] timerValues = new string[] {
			minutes.ToString("D2"), seconds.ToString("D2"), milliseconds.ToString("D3")
		};

		return string.Join(":", timerValues);
	}
}
