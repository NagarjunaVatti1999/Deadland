using StarterAssets;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas gameOverCanvas;
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleDeath()
    {
        GetComponent<FirstPersonController>().enabled = false;
        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        Cursor.visible = true;
    }
}
