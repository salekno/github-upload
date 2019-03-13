using UnityEngine;
using UnityEngine.EventSystems;

public class PlayAgain : MonoBehaviour, IPointerClickHandler
{

	public GameManager gameManager;

	

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("PlayAgain");
		gameManager.PlayAgain();
	}
}
