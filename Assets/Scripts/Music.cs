using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

    private Transform target_ = null;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Use this for initialization
    void Start()
    {
        updateTarget();
    }
    
    void OnLevelWasLoaded(int level)
    {
        updateTarget();

    }

    private void updateTarget()
    {
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        target_ = mainCamera.transform;
    }

    void Update()
    {
        transform.position = target_.position;
    }
}
