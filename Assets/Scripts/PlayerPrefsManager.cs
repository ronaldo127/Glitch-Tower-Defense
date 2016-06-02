using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "MASTER_VOLUME";
	const string DIFFICULTY_KEY = "DIFFICULTY";
	const string UNLOCK_LEVEL_KEY = "LEVEL_UNLOCK";
    const string LOST_LEVEL_KEY = "LOST_LEVEL";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
        {
            Debug.LogError("Invalid volume " + volume.ToString());
        }
    }

    public static float GetMasterVolume()
    {
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        else
            return GetDefaultMasterVolume();
    }

    public static float GetDefaultMasterVolume()
    {
        return 0.5f;
    }


    public static void UnlockLevel(int level)
    {
        if (PlayerPrefs.HasKey(UNLOCK_LEVEL_KEY))
        {
            if (!IsLevelUnlocked(level))
            {
                PlayerPrefs.SetInt(UNLOCK_LEVEL_KEY, level);
            }
        }
        else
        {
            PlayerPrefs.SetInt(UNLOCK_LEVEL_KEY, level);
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level == 1) return true;
        if (PlayerPrefs.HasKey(UNLOCK_LEVEL_KEY))
            return level <= PlayerPrefs.GetInt(UNLOCK_LEVEL_KEY);

        return false;
    }
    public static int MaxLevelUnlocked()
    {
        if (PlayerPrefs.HasKey(UNLOCK_LEVEL_KEY))
            return PlayerPrefs.GetInt(UNLOCK_LEVEL_KEY);

        return 1;
    }

    public static void SetDifficulty(float diff)
    {
        if (diff >= 1f && diff <= 3f) { 
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else
        {
            Debug.LogError("Invalid difficulty " + diff.ToString());
        }
    }

    public static float GetDifficulty()
    {
        if (PlayerPrefs.HasKey(DIFFICULTY_KEY))
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
        else
            return GetDefaultDifficulty();
    }

    public static float GetDefaultDifficulty()
    {
        return 2f;
    }

    public static void SetLostLevel (int level)
	{
		PlayerPrefs.SetInt(LOST_LEVEL_KEY, level);
	}
    public static int GetLostLevel ()
	{
		if (PlayerPrefs.HasKey(LOST_LEVEL_KEY))
			return PlayerPrefs.GetInt(LOST_LEVEL_KEY);
		else
			return 1;
	}
}
