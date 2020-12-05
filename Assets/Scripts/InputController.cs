using System;
using UnityEngine;

public class InputController : MonoBehaviour, IInputController
{
	[SerializeField] private Camera _camera;

	public event Action<Vector3> PlayerClicked;
	
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Click();
		}
	}

	private void Click()
	{
		var clickPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
		clickPosition.z = 0;

		PlayerClicked?.Invoke(clickPosition);
	}
}