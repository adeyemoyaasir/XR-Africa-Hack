using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceOverTrigger : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip nextAudioClip;
    public AudioClip lastAudioClip;
    public bool nextClip = false;
    public bool lastClip = false;
    public string nextRoom;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        nextClip = true;
        Debug.Log("I've Played First Clip");
        StartCoroutine(PlayAudioCouroutine());
    }

    IEnumerator PlayAudioCouroutine()
    {
        yield return new WaitForSeconds(1);
        audioSource.Play();
        audioSource.GetComponent<AudioSource>();

        Invoke("AudioFinished", audioSource.clip.length);
    }

    void AudioFinished()
    {
        if (nextClip == true && nextAudioClip != null)
        {
            nextClip = false;
            audioSource.clip = nextAudioClip;
            StartCoroutine(PlayAudioCouroutine());
            lastClip = true;
            Debug.Log("I've Played Next Clip");
        }
        else if (lastClip == true && lastAudioClip != null)
        {
            audioSource.clip = lastAudioClip;
            StartCoroutine(PlayAudioCouroutine());
            lastClip = false;
            Debug.Log("I've Played Last Clip");
        }
        else
        {
            Debug.Log("Done Playing Clips");
            ChangeScene(nextRoom);
        }
    }

    public void ChangeScene(string sceneName)
    {
        sceneName = nextRoom;
        SceneManager.LoadScene(sceneName);
    }

}
