using UnityEngine;
using UnityEngine.UI;
 
public class AchievementSingleEntryView : MonoBehaviour
{
	public Image Complete10Active;
	public Image Complete10Inactive;
	public Image Complete25Active;
	public Image Complete25Inactive;
	public Image Complete50Active;
	public Image Complete50Inactive;

	public void ListAchievements(PlayerProfile playerProfile, Vector3 achievementsPos)
	{
		achievementsPos.x -= 40;                                        // wyrównanie do środka
		Complete10Inactive.transform.position = achievementsPos;
		Complete10Active.transform.position = achievementsPos;

		if (playerProfile.Complete10)
			Complete10Active.gameObject.SetActive(true);
		else
			Complete10Active.gameObject.SetActive(false);

		achievementsPos.x += 40;
		Complete25Inactive.transform.position = achievementsPos;
		Complete25Active.transform.position = achievementsPos;

		if (playerProfile.Complete25)
			Complete25Active.gameObject.SetActive(true);
		else
			Complete25Active.gameObject.SetActive(false);

		achievementsPos.x += 40;
		Complete50Inactive.transform.position = achievementsPos;
		Complete50Active.transform.position = achievementsPos;

		if (playerProfile.Complete50)
			Complete50Active.gameObject.SetActive(true);
		else
			Complete50Active.gameObject.SetActive(false);
	}
}
