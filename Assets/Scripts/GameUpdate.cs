using UnityEngine;

public class GameUpdate : MonoBehaviour
{
	private const int version = 6;
	// Use this for initialization
	void Awake () {
		if (PlayerPrefs.GetInt("Version") != version)
		{
			Debug.Log("RESET HIGHSCORE ON UPDATE");
			PlayerPrefs.SetInt("Highscore", 0);
		}
		PlayerPrefs.SetInt("Version", version);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
