public interface IEnterOnScreen{
    bool HasEndedEnterOnScreen { get; set; }
    ICanEnterOnScreen CanEnterOnScreen { get; set; }
    void EnterOnScreen();
}