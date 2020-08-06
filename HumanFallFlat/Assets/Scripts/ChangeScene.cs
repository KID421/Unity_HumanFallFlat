using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) Change();
    }

    private void Change()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index == 0 ? 1 : 0);
    }
}
