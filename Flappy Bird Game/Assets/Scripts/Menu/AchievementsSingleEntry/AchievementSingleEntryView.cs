using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class AchievementSingleEntryView : MonoBehaviour
{
	[SerializeField] private Image Complete10Active;
	[SerializeField] private Image Complete10Inactive;
	[SerializeField] private Image Complete25Active;
	[SerializeField] private Image Complete25Inactive;
	[SerializeField] private Image Complete50Active;
	[SerializeField] private Image Complete50Inactive;

	public void ListAchievements(PlayerProfile playerProfile, int xPosition, int yPosition)
	{
		Complete10Inactive.transform.position = new Vector3(xPosition, yPosition);
		Complete10Active.transform.position = new Vector3(xPosition, yPosition);

		if (playerProfile.Complete10)
			Complete10Active.gameObject.SetActive(true);
		else
			Complete10Active.gameObject.SetActive(false);

		xPosition += 30;
		Complete25Inactive.transform.position = new Vector3(xPosition, yPosition);
		Complete25Active.transform.position = new Vector3(xPosition, yPosition);

		if (playerProfile.Complete25)
			Complete25Active.gameObject.SetActive(true);
		else
			Complete25Active.gameObject.SetActive(false);

		xPosition += 30;
		Complete50Inactive.transform.position = new Vector3(xPosition, yPosition);
		Complete50Active.transform.position = new Vector3(xPosition, yPosition);

		if (playerProfile.Complete50)
			Complete50Active.gameObject.SetActive(true);
		else
			Complete50Active.gameObject.SetActive(false);
	}
}
