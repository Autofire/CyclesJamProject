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


﻿using UnityEngine;
using UnityEngine.Events;

namespace ReachBeyond.EventObjects {

	public class EventObjectListener : AbstractEventObjectListener {

		[SerializeField] UnityEvent _response;

		/// <summary>
		/// Gets/sets the response. Making this null effectively disables
		/// the event.
		/// </summary>
		public UnityEvent Response {
			set { _response = value; }
			get { return _response; }
		}

		/// <summary>
		/// Invoke the selected response. If response is set to
		/// null, then nothing happens.
		/// </summary>
		override public void OnRaiseEvent() {
			if(Response != null) {
				Response.Invoke();
			}
		}

	} // End class

} // End namespace
