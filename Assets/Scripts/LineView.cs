using System;
using UnityEngine;

public class LineView : MonoBehaviour
{
	[SerializeField] private LineRenderer _lineRenderer;
	[SerializeField] private Transform _player;

	private Path _path;

	public void Init(Path path)
	{
		path.PositionAdded += OnPointAdded;
		path.PositionRemoved += OnPointRemoved;

		_path = path;
	}
		
	private void OnPointAdded(PathPoint point)
	{
		UpdateLinePositions();
	}

	private void OnPointRemoved(PathPoint point)
	{
		UpdateLinePositions();
	}

	private void UpdateLinePositions()
	{
		var points = _path.GetPoints();
		var positions = new Vector3[points.Length + 1];
		for (var i = 0; i < points.Length; i++)
		{
			positions[i + 1] = points[i].Position;
		}

		positions[0] = _player.transform.position;

		_lineRenderer.positionCount = positions.Length;
		_lineRenderer.SetPositions(positions);
	}

	private void Update()
	{
		if(_player == null) return;

		_lineRenderer.SetPosition(0, _player.transform.position);
	}
}