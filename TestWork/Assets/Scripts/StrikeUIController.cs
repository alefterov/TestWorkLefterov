using UnityEngine;
using UnityEngine.EventSystems;

public class StrikeUIController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _player;
    StrikeController strikeController;

    public void Awake()
    {
        strikeController = _player.GetComponent<StrikeController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        strikeController.GrowStrike();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        strikeController.Strike();  
    }
}
