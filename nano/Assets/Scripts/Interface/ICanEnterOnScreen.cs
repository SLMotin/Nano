public interface ICanEnterOnScreen{
    IDetachFromTrack DetachFromTrack { get; set; }
    bool CanEnterOnScreen();
}