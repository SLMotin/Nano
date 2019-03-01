using UnityEngine;
public class VirusCanMove : MonoBehaviour, ICanMove{
    public IEnterOnScreen EnterOnScreen;

    void Awake(){
        EnterOnScreen = GetComponent<IEnterOnScreen>();
    }
    public bool CanMove() {
        return EnterOnScreen.HasEndedEnterOnScreen;
    }
}