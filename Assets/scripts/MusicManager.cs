using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;




public class MusicManager : MonoBehaviour
{
    [SerializeField] private DirectoryInfo folder = new DirectoryInfo("Assets/assets/music");
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip song1;
    [SerializeField] private AudioClip song2;
    [SerializeField] private AudioClip song3;
    private ArrayList songs = new ArrayList();
    private string currentSong;
    private string previousSong;

    void Start()
    {
        //FileInfo[] fileok = folder.GetFiles();
        //foreach (FileInfo file in fileok) {
            //if (!file.Name.EndsWith(".meta"))
            //{
            //    songs.Add(file.Name);
            //}
        //}
        songs.Add(song1);
        songs.Add(song2);
        songs.Add(song3);

        previousSong = null;
        NewMusic();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (audioSource.time == 0)
        {
            NewMusic();
        }
    }

    void NewMusic()
    {

        AudioClip newSong = (AudioClip)songs[Random.Range(0, songs.Count)];
        if (!newSong.name.Equals(currentSong))
        {
            Debug.Log("Current song: " + newSong.name);
            audioSource.clip = newSong;
            audioSource.Play();
            currentSong = newSong.name;
        }
        else
        {
            NewMusic();
        }
        

        //AudioClip clip = Resources.Load<AudioClip>("\\Assets\\assets\\music\\Lvstlove");
        //Debug.Log(clip);
        //audioSource.clip = clip;
        //audioSource.Play();
    }
}
