﻿
public class DelegateService
{ 
	public delegate void OnStateSet(MenuScreensService.MenuScreens state);
	public OnStateSet OnStateSetDel;

	public void ClickLogo(MenuScreensService.MenuScreens state)
	{
		OnStateSetDel(state);
	}
}
