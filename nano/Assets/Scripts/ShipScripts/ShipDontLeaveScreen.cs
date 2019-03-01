using UnityEngine;
public class ShipDontLeaveScreen : MonoBehaviour, IDontLeaveScreen{
    Vector2 cornerTopRight;
    Vector2 cornerLeftBot;
    Rigidbody2D rb;
    Vector2 shipSize;

    void Awake(){
        cornerTopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        cornerLeftBot = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        rb = GetComponent<Rigidbody2D>();
		shipSize = GetComponent<BoxCollider2D>().size / 2f;
    }
    public void StayOnScreen(){
		Vector2 fixedPosition = new Vector2(rb.position.x, rb.position.y);
		if(rb.position.x > cornerTopRight.x - shipSize.x)
			fixedPosition.x = cornerTopRight.x - shipSize.x;
		else if(rb.position.x < cornerLeftBot.x + shipSize.x)
			fixedPosition.x = cornerLeftBot.x + shipSize.x;
		if(rb.position.y > cornerTopRight.y - shipSize.y)
			fixedPosition.y = cornerTopRight.y - shipSize.y;
		else if(rb.position.y < cornerLeftBot.y + shipSize.y)
			fixedPosition.y = cornerLeftBot.y + shipSize.y;
		
		rb.position = fixedPosition;
    }
}