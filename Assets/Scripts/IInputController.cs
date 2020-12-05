using System;
using UnityEngine;

public interface IInputController
{
	event Action<Vector3> PlayerClicked;
}