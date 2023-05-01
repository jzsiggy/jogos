// Esse script é responsável por gerenciar os sons do jogo, como música e efeitos sonoros.
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource gameMusicSource;
    public AudioSource deathMusicSource;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayDeathMusic()
    {
        gameMusicSource.Stop();
        deathMusicSource.Play();
    }

    public void StopMainMenuMusic()
    {
        musicSource.Stop();
    }

    public void ReturntoMainMenu()
    {
        deathMusicSource.Stop();
        musicSource.Play();
    }

    public void PlayGameMusic()
    {
        gameMusicSource.Play();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Game")
        {
            musicSource.Stop();
            deathMusicSource.Stop();
            gameMusicSource.Play();
        }
        else if (scene.name == "GameOver")
        {
            gameMusicSource.Stop();
            deathMusicSource.Play();
        }
        else if (scene.name == "MainMenu")
        {
            deathMusicSource.Stop();
            musicSource.Play();
        }
    }

    public void PlayCollectibleSound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayGameOverMusic(AudioClip clip)
    {
        gameMusicSource.Stop();
        deathMusicSource.PlayOneShot(clip);
    }

}