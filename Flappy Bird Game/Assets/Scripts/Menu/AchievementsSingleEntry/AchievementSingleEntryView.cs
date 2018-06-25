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

	public void ListAchievements(PlayerProfile playerProfile, Vector3 achievementsPos)
	{
		achievementsPos.x -= 30;                                        // wyrównanie do środka
		achievementsPos.y += 20;										// ============================ dlaczego musze to robic?
		_complete10Inactive.transform.position = achievementsPos;
		_complete10Active.transform.position = achievementsPos;

		if (playerProfile.Complete10)
			_complete10Active.gameObject.SetActive(true);
		else
			_complete10Active.gameObject.SetActive(false);

		achievementsPos.x += 30;
		_complete25Inactive.transform.position = achievementsPos;
		_complete25Active.transform.position = achievementsPos;

		if (playerProfile.Complete25)
			_complete25Active.gameObject.SetActive(true);
		else
			_complete25Active.gameObject.SetActive(false);

		achievementsPos.x += 30;
		_complete50Inactive.transform.position = achievementsPos;
		_complete50Active.transform.position = achievementsPos;

		if (playerProfile.Complete50)
			_complete50Active.gameObject.SetActive(true);
		else
			_complete50Active.gameObject.SetActive(false);
	}
}
