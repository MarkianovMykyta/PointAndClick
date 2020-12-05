using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PathView : MonoBehaviour
{
	[SerializeField] private GameObject _pathPointPrefab;
	
	[SerializeField] private Transform _pathPointsRoot;

	private readonly Stack<GameObject> _pathPointObjectsPool = new Stack<GameObject>();
	private readonly Dictionary<PathPoint, GameObject> _activePathPointsDictionary = new Dictionary<PathPoint, GameObject>();

	private IPath _path;

	public void Init(IPath path)
	{
		_path = path;
		_path.PositionAdded += CreatePathPoint;
		_path.PositionRemoved += RemovePathPoint;
	}

	private void CreatePathPoint(PathPoint pathPoint)
	{
		var obj = GetPathPointObject();
		obj.SetActive(true);
		obj.transform.DOKill();
		obj.transform.DOScale(new Vector3(0.5f, 0.5f), 0.5f).From(Vector2.zero).SetEase(Ease.OutBounce);
		obj.transform.position = pathPoint.Position;
		_activePathPointsDictionary.Add(pathPoint, obj);
	}

	private void RemovePathPoint(PathPoint pathPoint)
	{
		if (!_activePathPointsDictionary.ContainsKey(pathPoint)) return;

		var obj = _activePathPointsDictionary[pathPoint];
		obj.SetActive(false);
		_pathPointObjectsPool.Push(obj);

		_activePathPointsDictionary.Remove(pathPoint);
	}

	private GameObject GetPathPointObject()
	{
		if (_pathPointObjectsPool.Count > 0)
		{
			return _pathPointObjectsPool.Pop();
		}

		return Instantiate(_pathPointPrefab, _pathPointsRoot, true);
	}

	private LineRenderer GetLine()
	{
		return null;
	}
}