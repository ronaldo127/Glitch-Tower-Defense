using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button[] buttons = this.GetComponentsInChildren<Button>();
        int maxUnlocked = PlayerPrefsManager.MaxLevelUnlocked() - 1;
        for (int i = 0; i<buttons.Length; i++) {
            if (maxUnlocked<i)
            {
                Button button = buttons[i];
                button.interactable = false;
            }
        }
	}
	
}
