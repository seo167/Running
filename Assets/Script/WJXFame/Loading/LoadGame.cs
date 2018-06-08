using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WJX {
    public class LoadGame : MonoBehaviour
    {
        public string ScenenName;


        // Use this for initialization
        void Awake(){
            DontDestroyOnLoad(this.gameObject);
        }

        void Start() {
            Application.LoadLevel("Loading");
        }

        public void StartLoad() {
            StartCoroutine("LoadFGame");
        }


        IEnumerator LoadFGame() {
            AsyncOperation _asyn = SceneManager.LoadSceneAsync(ScenenName);
            _asyn.allowSceneActivation = false;
            while (!_asyn.isDone) {
                yield return null;
            }
            _asyn.allowSceneActivation = true;

            yield return new WaitForSeconds(1.0f);

            Destroy(this.gameObject);

        }

        void OnDestroy() {

        }

    }
}


