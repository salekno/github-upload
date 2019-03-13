using UnityEngine;
using UnityEngine.UI;


  public class ColorManager : MonoBehaviour
  {


    public GameObject firstRow;
    public GameObject secondRow;
    public GameObject thirdRow;
    public GameObject fourthRow;

    // Use this for initialization
    void Awake()
    {
      makeOneFromRandomRowBlack();
      makeOneFromRandomRowBlack();
      makeOneFromRandomRowBlack();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void makeOneFromRandomRowBlack()
    {

      int rng = Random.Range(1, 5);
      switch (rng)
      {
        case 1:
          makeRandomFromRowBlack(firstRow);
          break;
        case 2:
          makeRandomFromRowBlack(secondRow);
          break;
        case 3:
          makeRandomFromRowBlack(thirdRow);
          break;
        case 4:
          makeRandomFromRowBlack(fourthRow);
          break;
        default:
          Debug.LogError("rng out of range, this shouldnt happen: rng = " + rng);
          break;
      }

    }

    void makeRandomFromRowBlack(GameObject gameObject)
    {

      int rng = Random.Range(0, 4);
      if (gameObject.transform.GetChild(rng).GetComponent<Image>().color == Color.black)
      {
        Debug.Log("Tried to make already black tile black, fix this");
        makeOneFromRandomRowBlack();
      }
      gameObject.transform.GetChild(rng).GetComponent<Image>().color = Color.black;
    }

  }