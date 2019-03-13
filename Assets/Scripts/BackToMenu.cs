using UnityEngine;
using UnityEngine.EventSystems;

public class BackToMenu : MonoBehaviour, IPointerClickHandler
{

	public GameManager gameManager;

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("BackToMenu");
		gameManager.BackToMenu();
	}
	
	
}
