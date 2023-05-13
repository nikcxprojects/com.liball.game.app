using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] Image musicImg;

    [Space(10)]
    [SerializeField] Image soundsImg;

    [Space(10)]
    [SerializeField] Image vibrationImg;

    [Space(10)]
    [SerializeField] Sprite enable;
    [SerializeField] Sprite disable;

    public static bool VibraEnbled { get; set; } = true;
    public static bool SoundsEnabled { get; set; } = true;

    private void Start()
    {
        musicImg.sprite = music.mute ? disable : enable;

        soundsImg.sprite = SoundsEnabled ? enable : disable;
        vibrationImg.sprite = VibraEnbled ? enable : disable;
    }

    public void SetMusicStatus()
    {
        music.mute = !music.mute;
        musicImg.sprite = music.mute ? disable : enable;
    }

    public void SetSoundsStatus()
    {
        SoundsEnabled = !SoundsEnabled;
        soundsImg.sprite = SoundsEnabled ? enable : disable;
    }

    public void SetVibrationStatus()
    {
        VibraEnbled = !VibraEnbled;
        vibrationImg.sprite = VibraEnbled ? enable : disable;
    }
}
