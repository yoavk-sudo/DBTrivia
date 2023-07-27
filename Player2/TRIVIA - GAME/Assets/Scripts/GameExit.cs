using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void ExitGame()
    {
        // This will quit the application (close the game) in both the editor and the built executable.
        Application.Quit();

        // In the Unity Editor, the above line won't work, so you can use the following line instead to stop the play mode:
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
