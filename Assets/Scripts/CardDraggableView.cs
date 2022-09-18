using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Game
{
	public class CardDraggableView : MonoBehaviour
	{
		[SerializeField] private CardModel cardModel;
		[SerializeField] private SpriteRenderer cardSprite;
		[SerializeField] private GameObject spawner;
		private PoolMono<MinerBlueprintView> blueprintPool;
		public PoolMono<MinerBlueprintView> BlueprintPool => blueprintPool;

		private void Awake()
		{
			blueprintPool = new PoolMono<MinerBlueprintView>(cardModel.minerBlueprint, cardModel.bluprintCount, this.gameObject);
		}

		private void Update()
		{
			if (this.gameObject.activeInHierarchy)
			{
				Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
				transform.position = mousePosition;
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			cardSprite.enabled = false;
			for (int i = 0; i < cardModel.bluprintCount; i++)
			{
				var blueprint = blueprintPool.GetFreeElement();
			}
		}
		
		private void OnTriggerEnter2D(Collider2D collision)
		{
			cardSprite.enabled = true;
			foreach (var item in blueprintPool.Pool)
			{
				item.gameObject.SetActive(false);
			}
		}
	}
}