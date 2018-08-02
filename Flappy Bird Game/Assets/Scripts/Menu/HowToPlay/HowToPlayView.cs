using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HowToPlayView : MonoBehaviour
{
	[SerializeField] private Button _logoButton;
	[SerializeField] private Text _howToPlayText;
	[SerializeField] private Image _howToPlayButtonInactive;

	[Inject]
	private DelegateService _delegateService;

	public void Start()
	{
		_logoButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		_howToPlayText.text = "USE FINGERS TO CONTROL THE BEE\n\nBEAT HIGHSCORES, UNLOCK ACHIEVEMENTS\nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!";
	}
}
