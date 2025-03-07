using UnityEngine;

public interface IHittable
{
    void TakeDamage(float damage);

    BodyPart GetBodyPart();
}


