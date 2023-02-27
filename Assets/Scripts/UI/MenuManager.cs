using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject mainMenuScreen;
    [SerializeField] Image progressBar;

    private void Awake()
    {
        //if(instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public void QuitGame()
    {
        //Close the Game
        Application.Quit();
    }

    //Function to wait for the new scene to be fully loaded before opening
    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        mainMenuScreen.SetActive(false);
        loadingScreen.SetActive(true);

        do
        {
            //Delay added since the new scene has no big requirements and to display the loading bar
            await Task.Delay(1000);
            progressBar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        loadingScreen.SetActive(false);
    }

    //A way to load a new scene without needing the loading bar or a different scene
    public async void LoadFast(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
    }
}
