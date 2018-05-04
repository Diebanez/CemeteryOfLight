using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolable
{
	public int PoolCapacity = 10;
	Queue<T> ObjectNotActive = new Queue<T> ();
	List<T> ActiveItems = new List<T> ();

	public ObjectPool (int Capacity)
	{
		if (Capacity > 0) {
			PoolCapacity = Capacity;
		}
	}

	public T Pull ()
	{
		if (ObjectNotActive.Count > 0) {
			T ItemToActive = ObjectNotActive.Dequeue ();
			((IPoolable)ItemToActive).Deactivate += Fetch;
			ActiveItems.Add (ItemToActive);
            ItemToActive.SetActivation(true);
			return ItemToActive;
		} else {
			return default(T);
		}
	}

	public void Fetch (object item)
	{
		try {
			T FetchItem = (T)item;
			int MyIndex = -1;
			MyIndex = ActiveItems.IndexOf (FetchItem);
			if (MyIndex > 0) {
				ActiveItems.RemoveAt (MyIndex);
			}
			if (ObjectNotActive.Count < PoolCapacity) {
                FetchItem.SetActivation(false);
                ObjectNotActive.Enqueue (FetchItem);
			}
		} catch {
			
		}
	}
}
