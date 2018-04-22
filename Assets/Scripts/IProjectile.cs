public enum ProjectileTypes { Blank, Normal, Super};

public interface IProjectile {

    UnityEngine.GameObject GetObjectToInstantiate();

    void ShakeCamera(CameraShaker cameraShaker);
    int GetDamage();
    //void GetModifiers();
    bool ShouldBeDestroyed();
    float GetMaxTimelimit();

    float GetProjectileSpeed();
}
