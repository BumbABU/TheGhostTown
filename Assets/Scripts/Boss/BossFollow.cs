using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    [SerializeField]
    private HealthEnemy health;
    [SerializeField]
    private Transform cowBoy;
    private Vector2 distance;
    public Vector2 Distance { get { return distance; } }
    [SerializeField]
    private float distanceTofollow;
    private bool isFollowing;
    public bool IsFollowing { get { return isFollowing; } set { isFollowing = value; } }
    private float distanceY;
    [SerializeField]
    private float distanceYToUnfollow = 6f;
    private MumyTakeDamage mummyTakeDamage;
    [SerializeField]
    private float followSpeed = 5;

    private void Awake()
    {

    }
    private void Update()
    {
        distance = this.cowBoy.position - transform.position;

        if (health.Health <= 20)
        {
            FollowCowboy();
            isFollowing = true;
        }
        /*        if (distanceY > distanceYToUnfollow)
                {
                    isFollowing = false;
                }*/
    }
    public void FollowCowboy()
    {
        //enemyManager.Followcowboy = true;

        Vector2 targetpoint = (Vector2)this.cowBoy.position - distance.normalized; // ở đây distance là 1 điểm mới khi ta distance.normalize nó sẽ trả về 1 điểm để khi ta tính độ lớn độ này giá trị trả ra luôn bằng 1 
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetpoint, followSpeed * Time.deltaTime);// speed là khoảng cách tối đa di chuyển trong 1 khùng hình, nếu speed càng lớn thì tốc độ càng nhanh 
    }
}
