public interface IEnterOnScreen{
    bool HasEndedEnterOnScreen { get; set; }
    bool HasStartedAnimation { get; set; }
    ICanEnterOnScreen CanEnterOnScreen { get; set; }
    void EnterOnScreen();
}