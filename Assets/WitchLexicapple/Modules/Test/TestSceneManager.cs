using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace MysticalDreamers.WitchLexicapple
{
    public class TestSceneManager : Singleton<TestSceneManager>
    {
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Keyboard.current[Key.F5].wasPressedThisFrame)
            {
                SceneManager.LoadScene(0);
            }
            if (Keyboard.current[Key.F6].wasPressedThisFrame)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
