using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioSequence : AbstractApplier
{
	public AudioSource source1;
	public AudioSource source2;


	override public void Apply() {
		source1.Play();
		source2.PlayDelayed(source1.clip.length);
	}

	public void Stop() {
		source1.Stop();
		source2.Stop();
	}

}
