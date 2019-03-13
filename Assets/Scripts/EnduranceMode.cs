using UnityEngine;
using UnityEngine.EventSystems;

public class EnduranceMode : MonoBehaviour, IPointerClickHandler
{

	public GameManager gameManager;

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("StartEnduranceMode");
		gameManager.StartEnduranceMode();		
	}
}
