using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveLobby : MonoBehaviour
{
    // Start is called before the first frame update
    public void LeaveGameLobby()
    {
        SceneManager.LoadScene(0);
    }
}
