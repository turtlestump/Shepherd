using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extra import: This will allow us access into Unity's scene manager for transitioning between screens
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // This will allow the coroutine below to access the animator.
    public Animator transition;

    // Update is called once per frame
    void Update() {
        
        /* PLACEHOLDER: Press 'T' to change scenes, will be changed and linked to a specific scene trigger during development */
        if (Input.GetKeyDown(KeyCode.T)) {

            LoadNextScene();

        }

    }

    // This method will load the next scene
    public void LoadNextScene() {

        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));    // Note: Unity handles scenes in terms of indices, so when opening the build manager each scene has an index.
                                                                                    //       This line will load the scene succeeding the one currently loaded (essentially going to the next item in an array)
    }                                                                               //       I will likely change this and give a unique script to each scene so that the player can switch back and forth
    
    // A coroutine is necessary for the above method so that the transition can delay for enough time as to let the animation play
    IEnumerator LoadScene(int sceneIndex) {

        // Play animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(2);

        // Load scene
        SceneManager.LoadScene(sceneIndex);

    }

}
