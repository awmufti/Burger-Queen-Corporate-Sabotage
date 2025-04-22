using UnityEngine;
using UnityEngine.InputSystem;

public class NPC_Talking : MonoBehaviour
{
    public GameObject NPC_talking;
    public GameObject otherNPC_talking;
    
    private bool npcCanStartWalking = false;
    private bool otherNpcCanStartWalking = false;

    private Vector3 npc_pos;
    private Vector3 othernpc_pos;

    void Start()
    {
        npc_pos = NPC_talking.transform.position;
        othernpc_pos = otherNPC_talking.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            npcCanStartWalking = true;
        }
        NPC_Walk();
        NPC_Stop();
        otherNPC_Walk();
        otherNPC_Stop();
    }

    void NPC_Walk()
    {
        if(npcCanStartWalking && !otherNPC_talking.activeSelf)
        {
            npc_pos.z -= 1 * Time.deltaTime;
            transform.position = npc_pos;
            UnityEngine.Debug.Log("walk");
        }
    }

    void NPC_Stop()
    {
        if (npcCanStartWalking && npc_pos.z <-48)
        {
            npcCanStartWalking = false;
            otherNpcCanStartWalking = true;
            NPC_talking.SetActive(false);
            otherNPC_talking.SetActive(true);
        }
    }

    void otherNPC_Walk()
    {
        if (otherNpcCanStartWalking && !NPC_talking.activeSelf)
        {
            othernpc_pos.z += 1 * Time.deltaTime;
            otherNPC_talking.transform.position = othernpc_pos;
        }
    }

    void otherNPC_Stop()
    {
        if (othernpc_pos.z > -33)
        {
            otherNpcCanStartWalking = false;
            npcCanStartWalking = true;
            NPC_talking.SetActive(false);
            otherNPC_talking.SetActive(true);
        }
    }
}
