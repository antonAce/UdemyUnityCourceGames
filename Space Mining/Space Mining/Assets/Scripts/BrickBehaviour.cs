using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickBehaviour : MonoBehaviour
{
    private int _maxPossibleHits, _timesHit;
    public GameObject SpawningDiamonds;
    public Sprite[] HitSprites;
    public List<int> Blocksid;
    public AudioClip Crackclip;
    private SpriteRenderer _brickRenderer;

    public enum BlockType
    {
        BlueBlock,
        GreenBlock,
        RedBlock,
        YellowBlock
    }

    public BlockType CurrentBlockType;

    void Awake ()
    {
        Blocksid.Clear();
        _brickRenderer = gameObject.GetComponent<SpriteRenderer>();
        _timesHit = 0;

	    switch (gameObject.tag)
	    {
	        case "BlueBlock":
	        {
	            CurrentBlockType = BlockType.BlueBlock;
	            _maxPossibleHits = 1;
                break;
	        }
	        case "GreenBlock":
	        {
	            CurrentBlockType = BlockType.GreenBlock;
                _maxPossibleHits = 2;
                break;
            }
	        case "RedBlock":
	        {
	            CurrentBlockType = BlockType.RedBlock;
                _maxPossibleHits = 3;
                break;
            }
	        case "YellowBlock":
	        {
	            CurrentBlockType = BlockType.YellowBlock;
                _maxPossibleHits = 4;
                break;
            }
        }
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        if (LevelManager.Instance.CurrentLevel() != "Level01" && LevelManager.Instance.CurrentLevel() != "VsStage")
        {
            if (Blocksid.Contains(GetInstanceID())) // Caught double registered collision bug
            {
                Blocksid.Remove(GetInstanceID()); // Quick fix by checking ID
                return;
            }
            Blocksid.Add(GetInstanceID());
            Debug.Log("Hit brick, ID:" + GetInstanceID() + ", Type: " + CurrentBlockType);
        }

        _timesHit++;
        if (_maxPossibleHits <= _timesHit)
        {
            GameObject.Instantiate(SpawningDiamonds, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            SoundManager.instance.RandomizeSfx(Crackclip);
            Destroy(gameObject);
        }
        else
        {
            _brickRenderer.sprite = HitSprites[_timesHit];
            SoundManager.instance.RandomizeSfx(Crackclip);
        }
    }
}
