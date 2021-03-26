using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    AudioSource source;
    [Header("Sound Effects")]
    public AudioClip lightSwitch;
    public AudioClip deliverPoster;
    public AudioClip thermostat;
    public AudioClip rightAnswer;
    public AudioClip wrongAnswer;
    public AudioClip unlockDoor;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("Volume");
        int isMute = PlayerPrefs.GetInt("Mute");
        source.mute = isMute == 0 ? false : true;
        
    }

    private void Start()
    {
        if (GameEvents.current)
        {
            GameEvents.current.onTurnLightOn += SFXSwitch;
            GameEvents.current.onTurnLightOff += SFXSwitch;
            GameEvents.current.onDeliverPoster += SFXDeliver;
            GameEvents.current.onChangeTemp += SFXThermo;
            GameEvents.current.onCorrectAnswer += SFXRight;
            GameEvents.current.onIncorrectAnswer += SFXWrong;
            GameEvents.current.onUnlockDoor += SFXDoor;
        }
    }
    private void OnDisable()
    {
        if (GameEvents.current)
        {
            GameEvents.current.onTurnLightOn -= SFXSwitch;
            GameEvents.current.onTurnLightOff -= SFXSwitch;
            GameEvents.current.onDeliverPoster -= SFXDeliver;
            GameEvents.current.onChangeTemp -= SFXThermo;
            GameEvents.current.onCorrectAnswer -= SFXRight;
            GameEvents.current.onIncorrectAnswer -= SFXWrong;
            GameEvents.current.onUnlockDoor -= SFXDoor;
        }
    }
    public void MuteSound(bool toggle)
    {
        source.mute = toggle;
        int isMute = toggle == true ? 1 : 0;
        PlayerPrefs.SetInt("Mute", isMute);
    }

    public void ChangeVolume(System.Single value)
    {
        source.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }

    public void PauseAudio()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    void SFXSwitch(int id) { source.PlayOneShot(lightSwitch, 0.75f); }
    void SFXDeliver(int id) { source.PlayOneShot(deliverPoster, 0.8f); }
    void SFXThermo(int id) { source.PlayOneShot(thermostat, 0.6f); }
    void SFXRight() { source.PlayOneShot(rightAnswer, 0.9f); }
    void SFXWrong() { source.PlayOneShot(wrongAnswer, 0.2f); }
    void SFXDoor(int id) { source.PlayOneShot(unlockDoor, 1); }
}
