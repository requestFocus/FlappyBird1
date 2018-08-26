using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CreditsView : MonoBehaviour
{
	[SerializeField] private Button _logoButton;
	[SerializeField] private Text _creditsViewText;
	[SerializeField] private Image _creditsViewButtonInactive;

	[Inject]
	private DelegateService _delegateService;

    [Inject]
    private SoundService _soundService;

	public void Start()
	{
		_logoButton.onClick.AddListener(delegate
		{
            _soundService.PlayOkSound();
            Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		_creditsViewText.text = "PROGRAMMING / DESIGN\nMACIEJ NIEŚCIORUK\n\nGRAPHICS/SOUNDS\nINTERNET\n\nMUSIC\nCINNAMON CHASERS - LUV DELUXE\n\nSPECIAL THANKS TO\nMICHAŁ PODYMA";
	}
}
