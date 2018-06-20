using UnityEngine;
using Zenject;

public class BackgroundManager : MonoBehaviour
{
	[Inject]
	[SerializeField] private BackgroundGameView _backgroundGameViewPrefab;
}
