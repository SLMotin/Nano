public interface IChangeAmmo{
    IShoot Shooter { get; set; }
    void Change();
}