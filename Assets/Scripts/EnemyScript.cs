using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float timeToChangeDirection = 3;
    Vector3 direction = Vector3.right;
    bool isDead;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }


    public void TakeDamage()
    {
        // Only kill the zombie if it hasn't died already
        if (!isDead)
        {
            anim.Play("Z_FallingBack");
            isDead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only do this if the zombie is still alive
        if (!isDead)
        {
            timeToChangeDirection -= Time.deltaTime;
            if (timeToChangeDirection < 0)
            {
                // Calculate the movement direction and orientation
                float horizontalMovement = Random.Range(-1.0f, 1.0f);
                float verticalMovement = Random.Range(-1.0f, 1.0f);
                direction = new Vector3(horizontalMovement, 0, verticalMovement);
                transform.rotation = Quaternion.LookRotation(direction);

                // Attack, then go back to walking
                anim.Play("Z_Attack");
                anim.PlayQueued("Z_Walk");
                timeToChangeDirection = 3;
            }

            // Only move the zombie if it is currently in the walking state
            if (anim.IsPlaying("Z_Walk"))
            {
                transform.Translate(direction * Time.deltaTime);
            }
        }
    }
}
