public enum ProjectileTypes { Blank, Normal, Super};

public interface IProjectile {

    UnityEngine.GameObject GetObjectToInstantiate();

    void ShakeCamera();
    int GetDamage();
    //void GetModifiers();
    bool ShouldBeDestroyed();

}
