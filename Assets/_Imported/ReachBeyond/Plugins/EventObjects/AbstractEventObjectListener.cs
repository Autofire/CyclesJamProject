//
//  EventObjectListener.cs
//
//  Author:
//       Autofire <http://www.reach-beyond.pro/>
//
//  Copyright (c) 2018 ReachBeyond
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.


using UnityEngine;

namespace ReachBeyond.EventObjects {

	abstract public class AbstractEventObjectListener : MonoBehaviour, IEventObjectListener {

		[SerializeField] private EventObject _triggerEvent;

		/// <summary>
		/// Gets/sets the triggerEvent object. Note that changing this
		/// value will cause the listener to automatically re-register.
		///
		/// Making this null effectively disables the event.
		/// </summary>
		public EventObject TriggerEvent {
			set {
				if (_triggerEvent != value) {
					TryUnregister();
					_triggerEvent = value;
					TryRegister();
				}
			}
			get { return _triggerEvent; }
		}

		abstract public void OnRaiseEvent();

		#region Registration helpers
		/// <summary>
		/// Attempts to register to triggerEvent.
		/// </summary>
		private void TryRegister() {
			if (TriggerEvent != null) {
				TriggerEvent.RegisterListener(this);
			}
		}

		/// <summary>
		/// Attempts to unregister from triggerEvent.
		/// </summary>
		private void TryUnregister() {
			if (TriggerEvent != null) {
				TriggerEvent.UnregisterListener(this);
			}
		}

		#endregion


		#region Unity events

		protected virtual void OnEnable() {
			TryRegister();
		}

		protected virtual void OnDisable() {
			TryUnregister();
		}

		#endregion


	} // End class

} // End namespace
