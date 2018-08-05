using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    private AudioSource audioSource;        // AudioSorceを格納する変数の宣言.
    public AudioClip sound;             // 効果音を格納する変数の宣言.

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();   // AudioSorceコンポーネントを追加し、変数に代入.
        audioSource.clip = sound;       // 鳴らす音(変数)を格納.
        audioSource.loop = false;		// 音のループなし。
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            audioSource.Play();
        }  // 音を鳴らす.
    }
}