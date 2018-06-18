using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class AchievementSingleEntryView : MonoBehaviour
{
	[SerializeField] private Image _complete10Active;
	[SerializeField] private Image _complete10Inactive;
	[SerializeField] private Image _complete25Active;
	[SerializeField] private Image _complete25Inactive;
	[SerializeField] private Image _complete50Active;
	[SerializeField] private Image _complete50Inactive;

	public void ListAchievements(PlayerProfile playerProfile, int xPosition, int yPosition)
	{
		_complete10Inactive.transform.position = new Vector3(xPosition, yPosition);
		_complete10Active.transform.position = new Vector3(xPosition, yPosition);

		if (playerProfile.Complete10)
			_complete10Active.gameObject.SetActive(true);
		else
			_complete10Active.gameObject.SetActive(false);

		xPosition += 30;
		_complete25Inactive.transform.position = new Vector3(xPosition, yPosition);
		_complete25Active.transform.position = new Vector3(xPosition, yPosition);

		if (playerProfile.Complete25)
			_complete25Active.gameObject.SetActive(true);
		else
			_complete25Active.gameObject.SetActive(false);

		xPosition += 30;
		_complete50Inactive.transform.position = new Vector3(xPosition, yPosition);
		_complete50Active.transform.position = new Vector3(xPosition, yPosition);

		if (playerProfile.Complete50)
			_complete50Active.gameObject.SetActive(true);
		else
			_complete50Active.gameObject.SetActive(false);
	}
}
