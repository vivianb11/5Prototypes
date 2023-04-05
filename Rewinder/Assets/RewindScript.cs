using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class RewindScript : MonoBehaviour
{
    private bool isRewinding = false;

    public float rewindTime = 5f;

    private List<Vector3> positions;
    private List<Quaternion> rotations;

    private CharacterController controller;

    [SerializeField] private TextMeshProUGUI rewindAmountText;

    private void Start()
    {
        positions = new List<Vector3>();
        rotations = new List<Quaternion>();
        controller = GetComponent<CharacterController>();

        rewindAmountText.text = "Rewind Amount: " + rewindTime;
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            isRewinding = true;
        }

        if (isRewinding)
        {
            RewindTime();
        }
        else
        {
            Record();
            CheckRewindTime();
        }

    }

    private void Record()
    {
        if (positions.Count > Mathf.Round(rewindTime / Time.fixedDeltaTime))
        {
            positions.RemoveAt(positions.Count - 1);
            rotations.RemoveAt(rotations.Count - 1);
        }

        positions.Insert(0, transform.position);
        rotations.Insert(0, transform.rotation);
    }

    private void RewindTime()
    {
        if (positions.Count > 0)
        {
            controller.enabled = false;
            transform.position = positions[0];
            transform.rotation = rotations[0];
            positions.RemoveAt(0);
            rotations.RemoveAt(0);
            controller.enabled = true;
        }
        else
        {
            StopRewind();
        }
    }

    private void StopRewind()
    {
        isRewinding = false;
    }

    private void CheckRewindTime()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            rewindTime -= 10f;
        }
        
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            rewindTime += 10f;
        }

        rewindTime = Mathf.Clamp(rewindTime, 10f, 100f);

        rewindAmountText.text = "Rewind Amount: " + rewindTime;
    }
}
