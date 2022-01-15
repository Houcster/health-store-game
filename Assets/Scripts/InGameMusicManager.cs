using UnityEngine;

public class InGameMusicManager : MonoBehaviour
{
    public AudioClip[] musicList;
    private AudioClip currentMusic;

    void Start()
    {
        //AudioManager.Instance.musicSource.clip
        //currentMusic = musicList[Random.Range(0, musicList.Length)];
        //AudioManager.Instance.PlayMusic(currentMusic);
        if (AudioManager.Instance.musicSource.isPlaying)
        {
            currentMusic = AudioManager.Instance.musicSource.clip;
        }
        else
        {
            currentMusic = musicList[Random.Range(0, musicList.Length)];
            AudioManager.Instance.PlayMusic(currentMusic);
        }
    }

    private void FixedUpdate()
    {
        if (!AudioManager.Instance.musicSource.isPlaying)
        {
            if (currentMusic == musicList[0])
            {
                currentMusic = musicList[1];
            } else
            {
                currentMusic = musicList[0];
            }

            AudioManager.Instance.PlayMusic(currentMusic);
        } 
    }
}
