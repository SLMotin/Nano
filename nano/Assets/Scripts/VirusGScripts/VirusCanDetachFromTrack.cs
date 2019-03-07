using UnityEngine;
public class VirusCanDetachFromTrack : MonoBehaviour, ICanDetachFromTrack{
    private bool canDetach = false;
    public bool CanDetach() {
        if(canDetach)
            return true;

        //Calculate if is inside move area
        Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 1.5f, Screen.height * 1.33f));
        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * -0.5f, Screen.height * -0.33f));
        Vector2 pos = transform.position;
        if(topRight.y >= pos.y && bottomLeft.y <= pos.y)
            canDetach = true;
        return canDetach;
    }
}