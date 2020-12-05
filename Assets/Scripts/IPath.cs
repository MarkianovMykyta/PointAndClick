using System;

public interface IPath
{
	event Action<PathPoint> PositionAdded;
	event Action<PathPoint> PositionRemoved;
	
	PathPoint GetNextPathPoint();
	void RemoveFirstPathPoint();
}