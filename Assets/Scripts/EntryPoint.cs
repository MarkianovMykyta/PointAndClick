using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private PathView _pathView;
	[SerializeField] private InputController _inputController;
	[SerializeField] private LineView _lineView;

	private Path _path;
	
	private void Start()
	{
		_path = new Path(_inputController);
		
		_pathView.Init(_path);
		_lineView.Init(_path);
		_player.Init(_path);
	}
}