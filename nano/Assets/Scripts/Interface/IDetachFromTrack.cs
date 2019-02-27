public interface IDetachFromTrack{
    bool HasDetached { get; set; }
    ICanDetachFromTrack CanDetach { get; set; }
    void DetachFromTrack();
}