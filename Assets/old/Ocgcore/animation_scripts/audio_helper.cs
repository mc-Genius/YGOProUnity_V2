using UnityEngine;
using System.Collections;

public class audio_helper : MonoBehaviour {
    public AudioSource audioMgr;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (played == false&&audioMgr.clip != null && !audioMgr.isPlaying && audioMgr.clip.loadState == AudioDataLoadState.Loaded)
        {
            audioMgr.Play();
            played = true;
        }
	}
    bool played = false;

    private IEnumerator Download(string url,float vol)
    {
        played = false;
        using (WWW www = new WWW(url))
        {
            yield return www;
            AudioClip ac = www.GetAudioClip(true, true);
            audioMgr.clip = ac;
        }
        audioMgr.volume = vol;
    }
    public void play(string u,float vol)
    {
       StartCoroutine(Download(u,vol));
    }

    public void change_bgm(string str)
    {
        StartCoroutine(Download(str, 100f));
        audioMgr.loop = true;
    }

    public void close_bgm()
    {
        audioMgr.Pause();
    }

}
