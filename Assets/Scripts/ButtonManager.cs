using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public string sceneName;

    public void OpenScene()
    {

        SceneManager.LoadScene(sceneName);

    }

}
