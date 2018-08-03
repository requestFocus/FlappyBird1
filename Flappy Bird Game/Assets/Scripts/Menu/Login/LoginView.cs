using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoginView : MonoBehaviour
{
	[Inject]
	private LoginViewService _loginViewService;

	[SerializeField] private Button _logoButton;
	[SerializeField] private InputField _nameField;
	[SerializeField] private Text _enterYourName;
    [SerializeField] private Button _powerButton;

    public delegate void OnLoginViewSet(MenuScreensService.MenuScreens state);
	public OnLoginViewSet OnLoginViewSetDel;

	public void Start()
	{
		_enterYourName.text = "Enter your name\nand tap on the logo";

		_logoButton.onClick.AddListener(ClickLogo);
		_powerButton.onClick.AddListener(PowerOff);
	}

    public void ClickLogo()
	{
		if (_nameField.text.Length > 0)
		{
			_loginViewService.CheckPlayerPrefs(_nameField.text);                         // odpal LoadProfile, sprawdz aktualna liste i przypisz dane do pol obiektu
			OnLoginViewSetDel(MenuScreensService.MenuScreens.MainMenu);
			Destroy(gameObject);
		}
	}

    public void PowerOff()
    {
        Application.Quit();
    }
}
