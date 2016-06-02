using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class WinCondition : MonoBehaviour {

	public int secondsToSurvive = 100;
	public AudioClip winSound;
	public LevelManager levelManager;

	private float currentTime = 0.0f;
	private Slider slider;
	private bool hasWon;
	private GameObject winText;
    private int currentLevel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		FindWinLabel ();
		hasWon = false;
        string levelText = transform.parent.FindChild("Level indicator").GetComponent<Text>().text;
        string[] temp = levelText.Split(' ');
        if (temp.Length > 1)
            currentLevel = int.Parse(temp[1]);
        else
            currentLevel = 1;
    }

	void FindWinLabel ()
	{
		winText = GameObject.Find ("Win") as GameObject;
		if (!winText)
			Debug.LogWarning ("Insert the Win label named [Win]");
		else
			winText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime;
		slider.value = Mathf.Clamp(currentTime / secondsToSurvive, 0.0f, 1.0f);
		if (slider.value==1.0f&&!hasWon) {
			Win();
		}
	}
	private void Win ()
	{
		DestroyActors();
		hasWon=true;
		if (winText) winText.SetActive(true);
		MusicPlayer.PlayAudio(winSound);
		Invoke("LoadNextLevel", winSound.length);
        PlayerPrefsManager.UnlockLevel(currentLevel+1);
	}

	private void DestroyActors ()
	{
		GameObject[] attackers = GameObject.FindGameObjectsWithTag ("Attacker");
		GameObject[] defenders = GameObject.FindGameObjectsWithTag ("Defender");
		foreach (GameObject aux in attackers) {
			Destroy(aux);
		}
		foreach (GameObject aux in defenders) {
			Destroy(aux);
		}
	}

	private void LoadNextLevel ()
	{
		levelManager.LoadNextLevel();
	}
}
