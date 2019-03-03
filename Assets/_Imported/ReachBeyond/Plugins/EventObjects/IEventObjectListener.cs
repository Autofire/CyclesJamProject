using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReachBeyond.EventObjects {
	/// <summary>
	/// Implementers can be treated as if they are listeners by
	/// EventObjects. Note that the implementor is reponsible for registering
	/// itself.
	/// </summary>
	public interface IEventObjectListener {
		void OnRaiseEvent();
	}
}
