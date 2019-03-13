using UnityEngine;
using UnityEngine.EventSystems;

public class SprintMode : MonoBehaviour, IPointerClickHandler
{

    public GameManager gameManager;

  public void OnPointerClick(PointerEventData eventData)
  {
      Debug.Log("StartSprintMode");
      gameManager.StartSprintMode();
  }
}
