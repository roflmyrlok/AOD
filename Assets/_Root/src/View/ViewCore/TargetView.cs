using Model;
using UnityEngine;

namespace View
{
	public class TargetView : MonoBehaviour
	{
		public void DestroyGameObject()
		{
			Destroy(gameObject);
		}

		public void SetEnabled(bool value)
		{
			gameObject.SetActive(value);
		}
	}
}