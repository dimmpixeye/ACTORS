//  Project : ecs
// Contacts : Pix - ask@pixeye.games

using UnityEngine;

namespace Pixeye.Framework
{
	public static class Obj
	{

		public static Transform Spawn(string prefabID, Transform parent, Vector3 startPosition = default, Quaternion startRotation = default)
		{
			var prefab = Box.Get<GameObject>(prefabID);
			var go = Object.Instantiate(prefab, parent).transform;
			go.position = startPosition;
			go.localRotation = startRotation;
			go.localScale = Vector3.one;
			return go;
		}

		public static Transform Spawn(GameObject prefab, Transform parent, Vector3 startPosition = default, Quaternion startRotation = default)
		{
			var go = Object.Instantiate(prefab, parent).transform;
			go.position = startPosition;
			go.localRotation = startRotation;
			go.localScale = Vector3.one;
			return go;
		}
		
		public static T Spawn<T>(GameObject prefab, Transform parent, Vector3 startPosition = default, Quaternion startRotation = default)
		{
			var go = Object.Instantiate(prefab, parent).transform;
			go.position = startPosition;
			go.localRotation = startRotation;
			go.localScale = Vector3.one;
			return go.GetComponent<T>();
		}

	}
}