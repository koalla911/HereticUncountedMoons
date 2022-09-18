using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private CardDraggable[] cardDraggables;
		[SerializeField] private CardModel cardModel;
		private PoolMono<Miner> summonPool;

		private void Awake()
		{
			summonPool = new PoolMono<Miner>(cardModel.summonPrefab, cardModel.bluprintCount, this.gameObject);
		}

		private void OnEnable()
		{
			for (int i = 0; i < cardDraggables.Length; i++)
			{
				cardDraggables[i].OnSpawnSummon += Spawn;
			}
		}

		private void OnDisable()
		{
			for (int i = 0; i < cardDraggables.Length; i++)
			{
				cardDraggables[i].OnSpawnSummon -= Spawn;
			}
		}

		private void Spawn(List<Transform> transforms)
		{
			for (int i = 0; i < cardModel.bluprintCount; i++)
			{
				var summon = summonPool.GetFreeElement();
				summon.gameObject.transform.position = transforms[i].position;
			}
		}
	}
}