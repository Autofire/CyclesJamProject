using UnityEngine;

namespace ReachBeyond.VariableObjects {

	[CreateAssetMenu(menuName="Variable/RaceMode")]
	public class RaceModeVariable : Base.StructVariable<RaceController.RaceMode> { }

	[System.Serializable]
	public class RaceModeReference : Base.Reference<RaceController.RaceMode, RaceModeVariable> {}

	[System.Serializable]
	public class RaceModeConstReference : Base.ConstReference<RaceController.RaceMode, RaceModeVariable> {}

}



/* DO NOT REMOVE -- START VARIABLE OBJECT INFO -- DO NOT REMOVE **
{
    "name": "RaceMode",
    "type": "RaceController.RaceMode",
    "referability": "Struct"
}
** DO NOT REMOVE --  END VARIABLE OBJECT INFO  -- DO NOT REMOVE */