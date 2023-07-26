using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float _maxDisplacement;
    Vector2 startPos;
    Transform handle;

    public AudioSource freeBird;

    public static float Horizontal = 0,
                        Vertical = 0;

    public static bool isSpin = false;

    public GameManager gameManager;

    void Start()
    {
        handle = transform.GetChild(0);
        startPos = handle.position;
        freeBird = GameObject.Find("Game Audio").GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void UpdateHandlePosition(Vector2 position)
    {
        var delta = position - startPos;
        delta = Vector2.ClampMagnitude(delta, _maxDisplacement);
        handle.position = startPos + delta;
        Horizontal = delta.x;
        Vertical = delta.y;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateHandlePosition(eventData.position);
        freeBird.Play();
        isSpin = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateHandlePosition(eventData.position);

        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UpdateHandlePosition(startPos);
        freeBird.Pause();
        isSpin = false;
    }

}
