using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class StoryManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> audios;

    public static StoryManager Instance {get ; private set ;}

    private void Awake() {
        Instance = this;
    }

    public event Action OnEnablePlayer;
    public event Action OnDisablePlayer;
    public event Action ShowControlls;

    

    private void Start() {
        
        StartCoroutine(PlayFirstAudio());
        StartCoroutine(PlaySecondAudio());

        StoryEndPoint.Instance.OnFirst += PlayThirdAudio;
        StoryEndPoint.Instance.OnSecond += PlayFourthAudio;

    }

    IEnumerator PlayFirstAudio()
    {
        yield return new WaitForSeconds(0.5f);
        AudioSource.PlayClipAtPoint(audios[0] , transform.position , 1);

    }

        IEnumerator PlaySecondAudio()
    {
        yield return new WaitForSeconds(7.5f);
        AudioSource.PlayClipAtPoint(audios[1] , transform.position , 1);

        StartCoroutine(CallFunctionAfterAudio(audios[1].length , true));
    }

    void PlayThirdAudio()
    {
        OnDisablePlayer?.Invoke();

        AudioSource.PlayClipAtPoint(audios[2] , transform.position , 1);

        StartCoroutine(CallFunctionAfterAudio(audios[2].length));

    }

    void  PlayFourthAudio()
    {
        OnDisablePlayer?.Invoke();


        AudioSource.PlayClipAtPoint(audios[3] , transform.position , 1);

        StartCoroutine(CallFunctionAfterAudio(audios[3].length));

    }

    IEnumerator CallFunctionAfterAudio(float delay , bool CallShowControlls = false)
    {
        yield return new WaitForSeconds(delay);
        
        OnEnablePlayer?.Invoke();

        if(CallShowControlls)
        {
            ShowControlls?.Invoke();
        }
    }

    


    

    
}

