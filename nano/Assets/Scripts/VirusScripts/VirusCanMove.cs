using UnityEngine;
public class VirusCanMove : MonoBehaviour, ICanMove{
    public IEnterOnScreen EnterOnScreen;

    void Awake(){
        EnterOnScreen = GetComponent<VirusEnterOnScreen>();
    }
    public bool CanMove() {
        return EnterOnScreen.HasEndedEnterOnScreen;
    }
}