using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] Player player;

    private void Start() {
        player.OnPlayerJump += Player_OnPlayerJump;
    }

    private void Player_OnPlayerJump(object sender, EventArgs e)
    {
        SFXManager.Instance.PlayJumpSound(player.transform.position );
    }
}
