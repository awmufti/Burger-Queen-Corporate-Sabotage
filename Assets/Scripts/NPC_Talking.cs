using UnityEngine;
using UnityEngine.InputSystem;

public class NPC_Talking : MonoBehaviour
{
    public GameObject NPC_talking;
    public GameObject otherNPC_talking;

    private bool npcCanStartWalking = true;
    private bool otherNpcCanStartWalking = false;

    private Vector3 npc_pos;
    private Vector3 othernpc_pos;

    private bool npcGoingToCounter = true;
    private bool otherNpcGoingToCounter = true;

    private bool npcPausedAtCounter = false;
    private bool otherNpcPausedAtCounter = false;


    void Start()
    {
        npc_pos = NPC_talking.transform.position;
        othernpc_pos = otherNPC_talking.transform.position;

        NPC_talking.SetActive(true);         // NPC1 starts at door
        otherNPC_talking.SetActive(false);   // NPC2 hidden at start
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (npcPausedAtCounter)
            {
                npcPausedAtCounter = false;
                npcCanStartWalking = true;
                npcGoingToCounter = false; // walk back
                NPC_talking.transform.rotation = Quaternion.Euler(89.98f, 0, 0);
            }
            else if (otherNpcPausedAtCounter)
            {
                otherNpcPausedAtCounter = false;
                otherNpcCanStartWalking = true;
                otherNpcGoingToCounter = false; // walk back
                otherNPC_talking.transform.rotation = Quaternion.Euler(89.98f, 0, 0);
            }
        }


        NPC_Walk();
        NPC_Stop();
        otherNPC_Walk();
        otherNPC_Stop();
    }

    void NPC_Walk()
    {
        if (npcCanStartWalking)
        {
            float direction = npcGoingToCounter ? 2 : -2;
            npc_pos.z += direction * Time.deltaTime;
            NPC_talking.transform.position = npc_pos;
        }
    }

    void NPC_Stop()
    {
        if (npcGoingToCounter && npc_pos.z >= -33f)
        {
            npcCanStartWalking = false;
            npcPausedAtCounter = true;
        }
        else if (!npcGoingToCounter && npc_pos.z <= -49f)
        {
            npcCanStartWalking = false;
            NPC_talking.SetActive(false);        // hide NPC1
            npcGoingToCounter = true;            // reset for next cycle
            otherNpcCanStartWalking = true;
            otherNPC_talking.SetActive(true);    // show NPC2
            NPC_talking.transform.rotation = Quaternion.Euler(89.98f, 0, -180);
        }
    }

    void otherNPC_Walk()
    {
        if (otherNpcCanStartWalking)
        {
            float direction = otherNpcGoingToCounter ? 2 : -2;
            othernpc_pos.z += direction * Time.deltaTime;
            otherNPC_talking.transform.position = othernpc_pos;
        }
    }

    void otherNPC_Stop()
    {
        if (otherNpcGoingToCounter && othernpc_pos.z >= -33f)
        {
            otherNpcCanStartWalking = false;
            otherNpcPausedAtCounter = true;
        }
        else if (!otherNpcGoingToCounter && othernpc_pos.z <= -49f)
        {
            otherNpcCanStartWalking = false;
            otherNPC_talking.SetActive(false);     // hide NPC2
            otherNpcGoingToCounter = true;         // reset for next time
            NPC_talking.SetActive(true);
            npcCanStartWalking = true;
            otherNPC_talking.transform.rotation = Quaternion.Euler(89.98f, 0, -180);
        }
    }

}
