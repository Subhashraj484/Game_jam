using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] List<SFXData> sFXDatas;
    public static SFXManager Instance {get ; private set ;}

    private void Awake() {
        Instance = this;
    }

    public void PlayJumpSound(Vector3 position , float volume = 1)
    {
        AudioClip audioClip = GetAudioClipFromData(SFX.Jump);

        if(audioClip == null)  return;

        AudioSource.PlayClipAtPoint(audioClip , position , volume);
    }

    public void PlayBreakSound(Vector3 position , float volume = 1)
    {
        AudioClip audioClip = GetAudioClipFromData(SFX.Break);

        if(audioClip == null)  return;

        AudioSource.PlayClipAtPoint(audioClip , position , volume);
    }

    AudioClip GetAudioClipFromData(SFX sFX)
    {
        foreach(SFXData sFXData in sFXDatas)
        {
            if(sFXData.sFX != sFX) continue;

            return sFXData.audioClip;
        }

        return null;
    }


}

public enum SFX
{
    Jump , 
    Break
}
[System.Serializable]
public struct SFXData
{
    public AudioClip audioClip;
    public SFX sFX;
}
