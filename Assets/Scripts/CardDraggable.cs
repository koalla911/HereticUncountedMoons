using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game 
{
	public class CardDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private CardModel cardModel;
		[SerializeField] private RectTransform rectTransform;
		[SerializeField] private LayoutElement layoutElement;
		[SerializeField] private Image cardImage;
		[SerializeField] private CardDraggableView drag;

		private HorizontalLayoutGroup horizontalLayout;
		private Vector2 startPosition;
		private Vector2 beginDragPosition;
		private float topOffset;
		private float slideOn = 100f;
		private List<Transform> minerPositions;

		public Action<List<Transform>> OnSpawnSummon;

		private void Awake()
		{
			minerPositions = new List<Transform>();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			//beginDragPosition = eventData.pointerCurrentRaycast.screenPosition;
		}

		public void OnDrag(PointerEventData eventData)
		{
			drag.gameObject.SetActive(true);
			//drag.gameObject.transform.position = eventData.pointerCurrentRaycast.screenPosition;
			cardImage.gameObject.SetActive(false);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			for (int i = 0; i < cardModel.bluprintCount; i++)
			{
				minerPositions.Add(drag.BlueprintPool.Pool[i].gameObject.transform);
			}
			OnSpawnSummon?.Invoke(minerPositions);
			cardImage.gameObject.SetActive(true);
			drag.gameObject.SetActive(false);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			//rectTransform.DOMoveY(slideOn, 0.3f);
			startPosition = this.transform.position;

			Vector3 temp = new Vector3(0f, slideOn, 0);
			this.transform.position += temp;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			//rectTransform.DOMoveY(0f, 0.3f);
			Vector3 temp = new Vector3(0f, slideOn, 0);
			this.transform.position -= temp;
		}
	}
}
