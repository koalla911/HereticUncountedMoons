using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	[CreateAssetMenu(fileName = "Card", menuName = "Game/Card", order = 1)]
	public class CardModel : ScriptableObject
	{
		public MinerBlueprintView minerBlueprint;
		public Miner summonPrefab;
		public Image cardImage;
		public int bluprintCount;
	}
}