using System;
using System.Collections.Generic;
using UnityEngine;

public class Path : IPath
{
	public event Action<PathPoint> PositionAdded;
	public event Action<PathPoint> PositionRemoved;
	
	private readonly Queue<PathPoint> _positionsQueue = new Queue<PathPoint>();

	public Path(IInputController inputController)
	{
		inputController.PlayerClicked += AddPosition;
	}
	
	public void AddPosition(Vector3 position)
	{
		var pathPoint = new PathPoint {Position = position};
		_positionsQueue.Enqueue(pathPoint);
		
		PositionAdded?.Invoke(pathPoint);
	}

	public void RemoveFirstPathPoint()
	{
		var point = _positionsQueue.Dequeue();
		
		PositionRemoved?.Invoke(point);
	}

	public PathPoint GetNextPathPoint()
	{
		if (_positionsQueue.Count > 0)
		{
			return _positionsQueue.Peek();
		}

		return null;
	}

	public PathPoint[] GetPoints()
	{
		return _positionsQueue.ToArray();
	}
}