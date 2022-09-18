using System.Collections;
using UnityEngine;

namespace Game
{
	public class MinerBlueprintView : MonoBehaviour
	{
		private Vector3 offset;

		private void OnEnable()
		{
			offset = new Vector3(Random.Range(-6, 6), Random.Range(-6, 6));
		}

		private void Update()
		{
			if (this.gameObject.activeInHierarchy)
			{
				Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
				transform.position = mousePosition + offset;
			}
		}
	}
}