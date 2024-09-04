using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.ChangeMusic();
    }
}
