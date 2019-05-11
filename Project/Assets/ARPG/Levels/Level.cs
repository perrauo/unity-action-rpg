using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


namespace Cirrus.ARPG.Levels
{
    public class Level : MonoBehaviour
    {
        public static Level Instance;

        public Tags.Tag Destination { get; private set; }

        public bool CanStart = true;

        public void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            // Dont destroy on load must be at the root 
            gameObject.transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadRoom(string scenePath, Tags.Tag destinationTag)
        {
            Instance.Destination = destinationTag;
            SceneManager.LoadScene(scenePath);            
        }
    }

}