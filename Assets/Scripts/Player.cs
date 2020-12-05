using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _moveSpeed;
	[SerializeField] private float _stopDistance;

	private IPath _path;
	private PathPoint _targetPathPoint;

	public void Init(IPath path)
	{
		_path = path;
		_path.PositionAdded += OnNewPositionCreated;

		
	}

	private void Update()
	{
		if(_targetPathPoint == null) return;

		MoveToTarget();

		if (Vector3.Distance(transform.position, _targetPathPoint.Position) < _stopDistance)
		{
			Stop();
		}
	}

	private void MoveToTarget()
	{
		var dir = (_targetPathPoint.Position - transform.position).normalized;
		transform.position += dir * (_moveSpeed * Time.deltaTime);
	}

	private void Stop()
	{
		transform.position = _targetPathPoint.Position;
		_path.RemoveFirstPathPoint();
		
		_targetPathPoint = _path.GetNextPathPoint();
	}

	public void OnNewPositionCreated(PathPoint pathPoint)
	{
		if (_targetPathPoint == null) _targetPathPoint = pathPoint;
	}
}