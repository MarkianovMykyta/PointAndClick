using System;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	private int[] _arr;
	
	public int this[int index]
	{
		get => _arr[index];
	}
	
	public Test()
	{
		Dictionary<int, string> dic = new Dictionary<int, string>();
		List<int> list;
		throw new OutOfMemoryException();
	}
}