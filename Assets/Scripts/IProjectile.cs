public interface IProjectile {

    void ShakeCamera();
    int GetDamage();
    //void GetModifiers();

    bool ShouldBeDestroyed();
}
