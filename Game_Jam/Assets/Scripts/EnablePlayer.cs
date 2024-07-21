using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayer : MonoBehaviour
{
    [SerializeField] Player player;
    private void Start() {
        player.Stop();

        StoryManager.Instance.OnEnablePlayer += OnEnablePlayer;
        StoryManager.Instance.OnDisablePlayer += OnDisablePlayer;
    }

    private void OnDisablePlayer()
    {
        player.Stop();

    }

    private void OnEnablePlayer()
    {
        player.StartToMove();

    }
}
