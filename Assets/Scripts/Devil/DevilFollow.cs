using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilFollow : MonoBehaviour
{
    private DevilBreathing devilBreathing;
    private Distance distance;
    [SerializeField]
    private Transform cowBoy;
  //  private Vector3 distance;
  //  public Vector3 Distance { get { return distance; } }
    [SerializeField]
    private float distanceTofollow = 7f;
    private bool isFollowing;
    public bool IsFollowing { get { return isFollowing; } set { isFollowing = value; } }
    [SerializeField]
    private float followSpeed = 5;

    private void Awake()
    {
        distance = GetComponent<Distance>();
        devilBreathing = GetComponent<DevilBreathing>();
    }
    private void Update()
    {
       

       // distance = this.cowBoy.position - transform.position;
        if (distance.DisTance.magnitude < distanceTofollow &&!devilBreathing.IsBreath /* || isFollowing && !devilBreathing.IsBreath*/)
        {
            FollowCowboy();
            isFollowing = true;
        }
        else if (distance.DisTance.magnitude > distanceTofollow)
        {
            isFollowing = false;
        }
    }
    public void FollowCowboy()
    {
        //enemyManager.Followcowboy = true;
        Vector2 targetpoint = (Vector2)this.cowBoy.position - distance.DisTance.normalized; // ở đây distance là 1 điểm mới khi ta distance.normalize nó sẽ trả về 1 điểm để khi ta tính độ lớn độ này giá trị trả ra luôn bằng 1 
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetpoint, followSpeed * Time.deltaTime);// speed là khoảng cách tối đa di chuyển trong 1 khùng hình, nếu speed càng lớn thì tốc độ càng nhanh 
    }
}
