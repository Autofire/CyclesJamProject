using UnityEngine;
using UnityEditor;

namespace ReachBeyond.VariableObjects.Editor {

	[CustomPropertyDrawer(typeof(RaceModeReference))]
	public class RaceModeRefEditor : Base.Editor.RefEditor { }

	[CustomPropertyDrawer(typeof(RaceModeConstReference))]
	public class RaceModeConstRefEditor : Base.Editor.ConstRefEditor { }
}



/* DO NOT REMOVE -- START VARIABLE OBJECT INFO -- DO NOT REMOVE **
{
    "name": "RaceMode",
    "type": "RaceController.RaceMode",
    "referability": "Struct"
}
** DO NOT REMOVE --  END VARIABLE OBJECT INFO  -- DO NOT REMOVE */
