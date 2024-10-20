using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    public Vector3 targetTransform;
    public GameObject player;
    public GameObject characters;
    public BoxCollider2D boxCollider2D;
    public int MapID;
    public int targetMapID;
    public bool sceneChange = false;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Try");
        if(true)
        {
            player.GetComponent<PlayerMovement>().targetPosition = targetTransform;
            player.transform.position = targetTransform;
            MapManager.Instance.ChangeMap(targetMapID);
            characters.SetActive(true);
            NPCManager.Instance.updateNPCList();
            sceneChange = true;
        }
    }
}
