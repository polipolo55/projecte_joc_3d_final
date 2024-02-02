using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioSource cutsceneAudio;
    public AudioClip ringSound;
    public AudioClip DialogSound;
    public AudioClip Music1;
    public TMP_Text cutsceneText;

    public float typingSpeed = 20f;

    public void playCutscene()
    {
        Invoke("PlayRingSound", 1f);

        Invoke("StartTyping", 4f);

        Invoke("LoadGameScene", 14.5f);    
    }

    void PlayRingSound()
    {
        cutsceneAudio.PlayOneShot(ringSound);
    }

    void StartTyping()
    {
        cutsceneAudio.PlayOneShot(DialogSound);
        StartCoroutine(TypeText("You are fired mate, sorry, hope we can still be friends", "Wait what?? No way you are doing this to me right?"));
    }

    IEnumerator TypeText(string text, string text2)
    {
        cutsceneText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            cutsceneText.text += letter;
            yield return new WaitForSeconds(1f / typingSpeed);
        }
        yield return new WaitForSeconds(1f);
        cutsceneText.text = "";
        cutsceneAudio.PlayOneShot(Music1);
        foreach (char letter in text2.ToCharArray())
        {
            cutsceneText.text += letter;
            yield return new WaitForSeconds(1f / typingSpeed);
        }

    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("Office1");
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
