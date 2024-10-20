using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : Singleton<GameStarter>
{
    protected override void Awake()
    {
        base.Awake();
        SceneDialogueManager.Instance.StartScene0();
    }
}
