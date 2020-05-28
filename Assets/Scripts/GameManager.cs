using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int totalRedInHouse, totalGreenInHouse, totalBlueInHouse, totalYellowInHouse;
    
    public GameObject frameRed, frameGreen, frameYellow, frameBlue;
    public GameObject redPlayer1Border, redPlayer2Border, redPlayer3Border, redPlayer4Border;
    public GameObject greenPlayer1Border, greenPlayer2Border, greenPlayer3Border, greenPlayer4Border;
    public GameObject bluePlayer1Border, bluePlayer2Border, bluePlayer3Border, bluePlayer4Border;
    public GameObject yellowPlayer1Border, yellowPlayer2Border, yellowPlayer3Border, yellowPlayer4Border;

    public Vector3 redPlayer1Pos, redPlayer2Pos, redPlayer3Pos, redPlayer4Pos;
    public Vector3 greenPlayer1Pos, greenPlayer2Pos, greenPlayer3Pos, greenPlayer4Pos;
    public Vector3 bluePlayer1Pos, bluePlayer2Pos, bluePlayer3Pos, bluePlayer4Pos;
    public Vector3 yellowPlayer1Pos, yellowPlayer2Pos, yellowPlayer3Pos, yellowPlayer4Pos;

    public Transform diceRoll;
    public Transform redDiceRoll, greenDiceRoll, blueDiceRoll, yellowDiceRoll;

    public Button diceRollButton;

    public Button redPlayer1Button, redPlayer2Button, redPlayer3Button, redPlayer4Button;
    public Button greenPlayer1Button, greenPlayer2Button, greenPlayer3Button, greenPlayer4Button;
    public Button bluePlayer1Button, bluePlayer2Button, bluePlayer3Button, bluePlayer4Button;
    public Button yellowPlayer1Button, yellowPlayer2Button, yellowPlayer3Button, yellowPlayer4Button;

    public GameObject blueScreen, greenScreen, yellowScreen, redScreen;

    private string playerTurn = "RED";
    private string currentPlayer = "none";
    private string currentPlayerName = "none";


//Players ki movement ko control krta hy 

    public GameObject redPlayer1, redPlayer2, redPlayer3, redPlayer4;
    public GameObject bluePlayer1, bluePlayer2, bluePlayer3, bluePlayer4;
    public GameObject yellowPlayer1, yellowPlayer2, yellowPlayer3, yellowPlayer4;
    public GameObject greenPlayer1, greenPlayer2, greenPlayer3, greenPlayer4;

    private int redPlayer1Steps, redPlayer2Steps, redPlayer3Steps, redPlayer4Steps;
    private int bluePlayer1Steps, bluePlayer2Steps, bluePlayer3Steps, bluePlayer4Steps;
    private int greenPlayer1Steps, greenPlayer2Steps, greenPlayer3Steps, greenPlayer4Steps;
    private int yellowPlayer1Steps, yellowPlayer2Steps, yellowPlayer3Steps, yellowPlayer4Steps;

    private int selectDiceNumAnimation;

    public GameObject dice1RollAnimation, dice2RollAnimation, dice3RollAnimation;
    public GameObject dice4RollAnimation, dice5RollAnimation, dice6RollAnimation;

    public List<GameObject> redMovementBlock = new List<GameObject>();
    public List<GameObject> greenMovementBlock = new List<GameObject>();
    public List<GameObject> yellowMovementBlock = new List<GameObject>();
    public List<GameObject> blueMovementBlock = new List<GameObject>();

    public GameObject confirmScreen;
    public GameObject gameCompletedScreen;

    private System.Random randNo;

    public void ExitMethod()
    {
        confirmScreen.SetActive(true);
    }

    public void NoMethod()
    {
        confirmScreen.SetActive(false);
    }

    public void YesMethod()
    {
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator GameCompletedCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        gameCompletedScreen.SetActive(true);
    }

    public void YesGameCompleted()
    {
        SceneManager.LoadScene("Ludo");
    }

    public void NoGameCompleted()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void InitializeDice()
    {
        diceRollButton.interactable = true;

        dice1RollAnimation.SetActive(false);
        dice2RollAnimation.SetActive(false);
        dice3RollAnimation.SetActive(false);
        dice4RollAnimation.SetActive(false);
        dice5RollAnimation.SetActive(false);
        dice6RollAnimation.SetActive(false);


        switch (MainMenuManager.howManyPlayers)
        {
            case 2:
                if (totalRedInHouse > 3)
                {
                    redScreen.SetActive(true);
                    StartCoroutine("GameCompletedRoutine");
                    playerTurn = "none";
                }
                if (totalGreenInHouse > 3)
                {
                    greenScreen.SetActive(true);
                    StartCoroutine("GameCompletedRoutine");
                    playerTurn = "none";
                }
                break;


            case 3:

                //if any 1 of 3 players win the game..


                if(totalRedInHouse > 3 && totalBlueInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "RED")
                {
                    redScreen.SetActive(true);
                    Debug.Log("Red Player has won the game");
                    playerTurn = "BLUE";
                }

                if (totalBlueInHouse > 3 && totalRedInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "BLUE")
                {
                    blueScreen.SetActive(true);
                    Debug.Log("Blue Player has won the game");
                    playerTurn = "YELLOW";
                }

                if (totalYellowInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 4 && playerTurn == "YELLOW")
                {
                    yellowScreen.SetActive(true);
                    Debug.Log("Yellow Player has won the game");
                    playerTurn = "RED";
                }

                //if any 2 of 3 players win the game

                if (totalRedInHouse > 3 && totalBlueInHouse > 3 && totalYellowInHouse < 4)
                {
                    redScreen.SetActive(true);
                    blueScreen.SetActive(true);

                    StartCoroutine(GameCompletedCoroutine());
                    Debug.Log("Game is completed");
                    playerTurn = "none";
                  
                }

                if (totalRedInHouse > 3 && totalYellowInHouse > 3 && totalBlueInHouse < 4)
                {
                    redScreen.SetActive(true);
                    yellowScreen.SetActive(true);

                    StartCoroutine(GameCompletedCoroutine());
                    Debug.Log("Game is completed");
                    playerTurn = "none";

                }


                if (totalBlueInHouse > 3 && totalYellowInHouse > 3 && totalRedInHouse < 4)
                {
                    yellowScreen.SetActive(true);
                    blueScreen.SetActive(true);

                    StartCoroutine(GameCompletedCoroutine());
                    Debug.Log("Game is completed");
                    playerTurn = "none";

                }

                break;


            //    //if any 1 of 4 players win the game...


            //case 4:
            //    if (totalRedInHouse > 3 && totalBlueInHouse < 4 && totalGreenInHouse < 3 && totalYellowInHouse < 3 && playerTurn == "RED")
            //    {
            //        redScreen.SetActive(true);
            //        Debug.Log("Red Player has won the game");
            //        playerTurn = "BLUE";
            //    }


            //    if (totalBlueInHouse > 3 && totalRedInHouse < 4 && totalGreenInHouse < 3 && totalYellowInHouse < 3 && playerTurn == "BLUE")
            //    {
            //        blueScreen.SetActive(true);
            //        Debug.Log("Blue Player has won the game");
            //        playerTurn = "GREEN";
            //    }


            //    if (totalGreenInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 3 && totalYellowInHouse < 3 && playerTurn == "GREEN")
            //    {
            //        greenScreen.SetActive(true);
            //        Debug.Log("Green Player has won the game");
            //        playerTurn = "YELLOW";
            //    }


            //    if (totalYellowInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 3 && totalGreenInHouse < 3 && playerTurn == "YELLOW")
            //    {
            //        yellowScreen.SetActive(true);
            //        Debug.Log("Yellow Player has won the game");
            //        playerTurn = "RED";
            //    }


            //    // if any 2 of 4 players win the game...


            //    if (totalRedInHouse > 3 && totalBlueInHouse > 3 && totalGreenInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "RED" || playerTurn == "BLUE") 
            //    {
            //        redScreen.SetActive(true);
            //        blueScreen.SetActive(true);
            //        Debug.Log("Red and Blue have won the game");
            //        playerTurn = "GREEN";
                
            //    }

            //    if (totalRedInHouse > 3 && totalGreenInHouse > 3 && totalBlueInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "RED" || playerTurn == "GREEN")
            //    {
            //        redScreen.SetActive(true);
            //        greenScreen.SetActive(true);
            //        Debug.Log("Red and Green have won the game");
            //        playerTurn = "BLUE";

            //    }


            //    if (totalRedInHouse > 3 && totalYellowInHouse > 3 && totalBlueInHouse < 4 && totalGreenInHouse < 4 && playerTurn == "RED" || playerTurn == "YELLOW")
            //    {
            //        blueScreen.SetActive(true);
            //        yellowScreen.SetActive(true);
            //        Debug.Log("Blue and Yellow have won the game");
            //        playerTurn = "RED";

            //    }


            //    if (totalBlueInHouse > 3 && totalGreenInHouse > 3 && totalRedInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "BLUE" || playerTurn == "GREEN")
            //    {
            //        blueScreen.SetActive(true);
            //        greenScreen.SetActive(true);
            //        Debug.Log("Blue and Green have won the game");
            //        playerTurn = "YELLOW";

            //    }


            //    if (totalBlueInHouse > 3 && totalYellowInHouse > 3 && totalRedInHouse < 4 && totalGreenInHouse < 4 && playerTurn == "BLUE" || playerTurn == "YELLOW")
            //    {
            //        blueScreen.SetActive(true);
            //        greenScreen.SetActive(true);
            //        Debug.Log("Blue and Yellow have won the game");
            //        playerTurn = "YELLOW";

            //    }

            //    if (totalBlueInHouse > 3 && totalRedInHouse > 3 && totalRedInHouse < 4 && totalGreenInHouse < 4 && playerTurn == "BLUE" || playerTurn == "RED")
            //    {
            //        blueScreen.SetActive(true);
            //        redScreen.SetActive(true);
            //        Debug.Log("Blue and Red have won the game");
            //        playerTurn = "GREEN";

            //    }


            //    if (totalGreenInHouse > 3 && totalYellowInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 4 && playerTurn == "GREEN" || playerTurn == "YELLOW")
            //    {
            //        greenScreen.SetActive(true);
            //        yellowScreen.SetActive(true);
            //        Debug.Log("Green and Yellow have won the game");
            //        playerTurn = "RED";

            //    }

            //    if (totalGreenInHouse > 3 && totalRedInHouse > 3 && totalYellowInHouse < 4 && totalBlueInHouse < 4 && playerTurn == "GREEN" || playerTurn == "RED")
            //    {
            //        greenScreen.SetActive(true);
            //        redScreen.SetActive(true);
            //        Debug.Log("Green and Red have won the game");
            //        playerTurn = "BLUE";

            //    }

            //    if (totalGreenInHouse > 3 && totalBlueInHouse > 3 && totalYellowInHouse < 4 && totalBlueInHouse < 4 && playerTurn == "GREEN" || playerTurn == "BLUE")
            //    {
            //        greenScreen.SetActive(true);
            //        blueScreen.SetActive(true);
            //        Debug.Log("Green and Blue have won the game");
            //        playerTurn = "YELLOW";

            //    }
                


            //    break;





        }

        

        if (currentPlayerName.Contains("RED PLAYER"))
        {
            if (currentPlayerName == "RED PLAYER 1")
            {
                currentPlayer = RedPlayerOne.redPlayerOneColName;
            }
            if (currentPlayerName == "RED PLAYER 2")
            {
                currentPlayer = RedPlayerTwo.redPlayerTwoColName;
            }
            if (currentPlayerName == "RED PLAYER 3")
            {
                currentPlayer = RedPlayerThree.redPlayerThreeColName;
            }
            if (currentPlayerName == "RED PLAYER 4")
            {
                currentPlayer = RedPlayerFour.redPlayerFourColName;
            }
        }


        if (currentPlayerName.Contains("GREEN PLAYER"))
        {
            if (currentPlayerName == "GREEN PLAYER 1")
            {
                currentPlayer = GreenPlayerOne.greenPlayerOneColName;
            }
            if (currentPlayerName == "GREEN PLAYER 2")
            {
                currentPlayer = GreenPlayerTwo.greenPlayerTwoColName;
            }
            if (currentPlayerName == "GREEN PLAYER 3")
            {
                currentPlayer = GreenPlayerThree.greenPlayerThreeColName;
            }
            if (currentPlayerName == "GREEN PLAYER 4")
            {
                currentPlayer = GreenPlayerFour.greenPlayerFourColName;
            }
        }


        if (currentPlayerName.Contains("BLUE PLAYER"))
        {
            if (currentPlayerName == "BLUE PLAYER 1")
            {
                currentPlayer = BluePlayerOne.bluePlayerOneColName;
            }
            if (currentPlayerName == "BLUE PLAYER 2")
            {
                currentPlayer = BluePlayerTwo.bluePlayerTwoColName;
            }
            if (currentPlayerName == "BLUE PLAYER 3")
            {
                currentPlayer = BluePlayerThree.bluePlayerThreeColName;
            }
            if (currentPlayerName == "BLUE PLAYER 4")
            {
                currentPlayer = BluePlayerFour.bluePlayerFourColName;
            }
        }


        if (currentPlayerName.Contains("YELLOW PLAYER"))
        {
            if (currentPlayerName == "YELLOW PLAYER 1")
            {
                currentPlayer = YellowPlayerOne.yellowPlayerOneColName;
            }
            if (currentPlayerName == "YELLOW PLAYER 2")
            {
                currentPlayer = YellowPlayerTwo.yellowPlayerTwoColName;
            }
            if (currentPlayerName == "YELLOW PLAYER 3")
            {
                currentPlayer = YellowPlayerThree.yellowPlayerThreeColName;
            }
            if (currentPlayerName == "YELLOW PLAYER 4")
            {
                currentPlayer = YellowPlayerFour.yellowPlayerFourColName;
            }
        }


        

        // Player v.s opponent 

        if (currentPlayerName != "none")
        {
            switch (MainMenuManager.howManyPlayers)
            {
                case 2:
                    if (currentPlayerName.Contains("RED PLAYER"))
                    {
                        if (currentPlayer == GreenPlayerOne.greenPlayerOneColName && currentPlayer != "Star")
                        {
                            greenPlayer1.transform.position = greenPlayer1Pos;
                            GreenPlayerOne.greenPlayerOneColName = "none";
                            greenPlayer1Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenPlayerTwo.greenPlayerTwoColName && currentPlayer != "Star")
                        {
                            greenPlayer2.transform.position = greenPlayer2Pos;
                            GreenPlayerTwo.greenPlayerTwoColName = "none";
                            greenPlayer2Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenPlayerThree.greenPlayerThreeColName && currentPlayer != "Star")
                        {
                            greenPlayer3.transform.position = greenPlayer3Pos;
                            GreenPlayerThree.greenPlayerThreeColName = "none";
                            greenPlayer3Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenPlayerFour.greenPlayerFourColName && currentPlayer != "Star")
                        {
                            greenPlayer4.transform.position = greenPlayer4Pos;
                            GreenPlayerFour.greenPlayerFourColName = "none";
                            greenPlayer4Steps = 0;
                            playerTurn = "RED";
                        }
                    }

                    if (currentPlayerName.Contains("GREEN PLAYER"))
                    {
                        if (currentPlayer == RedPlayerOne.redPlayerOneColName && currentPlayer != "Star")
                        {
                            redPlayer1.transform.position = redPlayer1Pos;
                            RedPlayerOne.redPlayerOneColName = "none";
                            redPlayer1Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedPlayerTwo.redPlayerTwoColName && currentPlayer != "Star")
                        {
                            redPlayer2.transform.position = redPlayer2Pos;
                            RedPlayerTwo.redPlayerTwoColName = "none";
                            redPlayer2Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedPlayerThree.redPlayerThreeColName && currentPlayer != "Star")
                        {
                            redPlayer3.transform.position = redPlayer3Pos;
                            RedPlayerThree.redPlayerThreeColName = "none";
                            redPlayer3Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedPlayerFour.redPlayerFourColName && currentPlayer != "Star")
                        {
                            redPlayer4.transform.position = redPlayer4Pos;
                            RedPlayerFour.redPlayerFourColName = "none";
                            redPlayer4Steps = 0;
                            playerTurn = "GREEN";
                        }
                       
                    }   
                      break;

                case 3:
                      if (currentPlayerName.Contains("RED PLAYER"))
                      {
                          if (currentPlayer == BluePlayerOne.bluePlayerOneColName && currentPlayer != "Star")
                          {
                              bluePlayer1.transform.position = bluePlayer1Pos;
                              BluePlayerOne.bluePlayerOneColName = "none";
                              bluePlayer1Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == BluePlayerTwo.bluePlayerTwoColName && currentPlayer != "Star")
                          {
                              bluePlayer2.transform.position = bluePlayer2Pos;
                              BluePlayerTwo.bluePlayerTwoColName = "none";
                              bluePlayer2Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == BluePlayerThree.bluePlayerThreeColName && currentPlayer != "Star")
                          {
                              bluePlayer3.transform.position = bluePlayer3Pos;
                              BluePlayerThree.bluePlayerThreeColName = "none";
                              bluePlayer3Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == BluePlayerFour.bluePlayerFourColName && currentPlayer != "Star")
                          {
                              bluePlayer4.transform.position = bluePlayer4Pos;
                              BluePlayerFour.bluePlayerFourColName = "none";
                              bluePlayer4Steps = 0;
                              playerTurn = "RED";
                          }



                          if (currentPlayer == YellowPlayerOne.yellowPlayerOneColName && currentPlayer != "Star")
                          {
                              yellowPlayer1.transform.position = yellowPlayer1Pos;
                              YellowPlayerOne.yellowPlayerOneColName = "none";
                              yellowPlayer1Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == YellowPlayerTwo.yellowPlayerTwoColName && currentPlayer != "Star")
                          {
                              yellowPlayer2.transform.position = yellowPlayer2Pos;
                              YellowPlayerTwo.yellowPlayerTwoColName = "none";
                              yellowPlayer2Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == YellowPlayerThree.yellowPlayerThreeColName && currentPlayer != "Star")
                          {
                              yellowPlayer3.transform.position = yellowPlayer3Pos;
                              YellowPlayerThree.yellowPlayerThreeColName = "none";
                              yellowPlayer3Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == YellowPlayerFour.yellowPlayerFourColName && currentPlayer != "Star")
                          {
                              yellowPlayer4.transform.position = yellowPlayer4Pos;
                              YellowPlayerFour.yellowPlayerFourColName = "none";
                              yellowPlayer4Steps = 0;
                              playerTurn = "RED";
                          } 
                         

                      }

                      if (currentPlayerName.Contains("BLUE PLAYER"))
                      {
                          if (currentPlayer == YellowPlayerOne.yellowPlayerOneColName && currentPlayer != "Star")
                          {
                              yellowPlayer1.transform.position = yellowPlayer1Pos;
                              YellowPlayerOne.yellowPlayerOneColName = "none";
                              yellowPlayer1Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == YellowPlayerTwo.yellowPlayerTwoColName && currentPlayer != "Star")
                          {
                              yellowPlayer2.transform.position = yellowPlayer2Pos;
                              YellowPlayerTwo.yellowPlayerTwoColName = "none";
                              yellowPlayer2Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == YellowPlayerThree.yellowPlayerThreeColName && currentPlayer != "Star")
                          {
                              yellowPlayer3.transform.position = yellowPlayer3Pos;
                              YellowPlayerThree.yellowPlayerThreeColName = "none";
                              yellowPlayer3Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == YellowPlayerFour.yellowPlayerFourColName && currentPlayer != "Star")
                          {
                              yellowPlayer4.transform.position = yellowPlayer4Pos;
                              YellowPlayerFour.yellowPlayerFourColName = "none";
                              yellowPlayer4Steps = 0;
                              playerTurn = "BLUE";
                          }


                          if (currentPlayer == RedPlayerOne.redPlayerOneColName && currentPlayer != "Star")
                          {
                              redPlayer1.transform.position = redPlayer1Pos;
                              RedPlayerOne.redPlayerOneColName = "none";
                              redPlayer1Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == RedPlayerTwo.redPlayerTwoColName && currentPlayer != "Star")
                          {
                              redPlayer2.transform.position = redPlayer2Pos;
                              RedPlayerTwo.redPlayerTwoColName = "none";
                              redPlayer2Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == RedPlayerThree.redPlayerThreeColName && currentPlayer != "Star")
                          {
                              redPlayer3.transform.position = redPlayer3Pos;
                              RedPlayerThree.redPlayerThreeColName = "none";
                              redPlayer3Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == RedPlayerFour.redPlayerFourColName && currentPlayer != "Star")
                          {
                              redPlayer4.transform.position = redPlayer4Pos;
                              RedPlayerFour.redPlayerFourColName = "none";
                              redPlayer4Steps = 0;
                              playerTurn = "BLUE";
                          }
                       
                      }

                      if (currentPlayerName.Contains("YELLOW PLAYER"))
                      {
                          if (currentPlayer == RedPlayerOne.redPlayerOneColName && currentPlayer != "Star")
                          {
                              redPlayer1.transform.position = redPlayer1Pos;
                              RedPlayerOne.redPlayerOneColName = "none";
                              redPlayer1Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == RedPlayerTwo.redPlayerTwoColName && currentPlayer != "Star")
                          {
                              redPlayer2.transform.position = redPlayer2Pos;
                              RedPlayerTwo.redPlayerTwoColName = "none";
                              redPlayer2Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == RedPlayerThree.redPlayerThreeColName && currentPlayer != "Star")
                          {
                              redPlayer3.transform.position = redPlayer3Pos;
                              RedPlayerThree.redPlayerThreeColName = "none";
                              redPlayer3Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == RedPlayerFour.redPlayerFourColName && currentPlayer != "Star")
                          {
                              redPlayer4.transform.position = redPlayer4Pos;
                              RedPlayerFour.redPlayerFourColName = "none";
                              redPlayer4Steps = 0;
                              playerTurn = "YELLOW";
                          }


                          if (currentPlayer == BluePlayerOne.bluePlayerOneColName && currentPlayer != "Star")
                          {
                              bluePlayer1.transform.position = bluePlayer1Pos;
                              BluePlayerOne.bluePlayerOneColName = "none";
                              bluePlayer1Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == BluePlayerTwo.bluePlayerTwoColName && currentPlayer != "Star")
                          {
                              bluePlayer2.transform.position = bluePlayer2Pos;
                              BluePlayerTwo.bluePlayerTwoColName = "none";
                              bluePlayer2Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == BluePlayerThree.bluePlayerThreeColName && currentPlayer != "Star")
                          {
                              bluePlayer3.transform.position = bluePlayer3Pos;
                              BluePlayerThree.bluePlayerThreeColName = "none";
                              bluePlayer3Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == BluePlayerFour.bluePlayerFourColName && currentPlayer != "Star")
                          {
                              bluePlayer4.transform.position = bluePlayer4Pos;
                              BluePlayerFour.bluePlayerFourColName = "none";
                              bluePlayer4Steps = 0;
                              playerTurn = "YELLOW";
                          }
                       
                      }

                      break;


                case 4:

                      if (currentPlayerName.Contains("RED PLAYER"))
                      {
                          if (currentPlayer == BluePlayerOne.bluePlayerOneColName && currentPlayer != "Star")
                          {
                              bluePlayer1.transform.position = bluePlayer1Pos;
                              BluePlayerOne.bluePlayerOneColName = "none";
                              bluePlayer1Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == BluePlayerTwo.bluePlayerTwoColName && currentPlayer != "Star")
                          {
                              bluePlayer2.transform.position = bluePlayer2Pos;
                              BluePlayerTwo.bluePlayerTwoColName = "none";
                              bluePlayer2Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == BluePlayerThree.bluePlayerThreeColName && currentPlayer != "Star")
                          {
                              bluePlayer3.transform.position = bluePlayer3Pos;
                              BluePlayerThree.bluePlayerThreeColName = "none";
                              bluePlayer3Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == BluePlayerFour.bluePlayerFourColName && currentPlayer != "Star")
                          {
                              bluePlayer4.transform.position = bluePlayer4Pos;
                              BluePlayerFour.bluePlayerFourColName = "none";
                              bluePlayer4Steps = 0;
                              playerTurn = "RED";
                          }


                          if (currentPlayer == GreenPlayerOne.greenPlayerOneColName && currentPlayer != "Star")
                          {
                              greenPlayer1.transform.position = greenPlayer1Pos;
                              GreenPlayerOne.greenPlayerOneColName = "none";
                              greenPlayer1Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == GreenPlayerTwo.greenPlayerTwoColName && currentPlayer != "Star")
                          {
                              greenPlayer2.transform.position = greenPlayer2Pos;
                              GreenPlayerTwo.greenPlayerTwoColName = "none";
                              greenPlayer2Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == GreenPlayerThree.greenPlayerThreeColName && currentPlayer != "Star")
                          {
                              greenPlayer3.transform.position = greenPlayer3Pos;
                              GreenPlayerThree.greenPlayerThreeColName = "none";
                              greenPlayer3Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == GreenPlayerFour.greenPlayerFourColName && currentPlayer != "Star")
                          {
                              greenPlayer4.transform.position = greenPlayer4Pos;
                              GreenPlayerFour.greenPlayerFourColName = "none";
                              greenPlayer4Steps = 0;
                              playerTurn = "RED";
                          }

                          if (currentPlayer == YellowPlayerOne.yellowPlayerOneColName && currentPlayer != "Star")
                          {
                              yellowPlayer1.transform.position = yellowPlayer1Pos;
                              YellowPlayerOne.yellowPlayerOneColName = "none";
                              yellowPlayer1Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == YellowPlayerTwo.yellowPlayerTwoColName && currentPlayer != "Star")
                          {
                              yellowPlayer2.transform.position = yellowPlayer2Pos;
                              YellowPlayerTwo.yellowPlayerTwoColName = "none";
                              yellowPlayer2Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == YellowPlayerThree.yellowPlayerThreeColName && currentPlayer != "Star")
                          {
                              yellowPlayer3.transform.position = yellowPlayer3Pos;
                              YellowPlayerThree.yellowPlayerThreeColName = "none";
                              yellowPlayer3Steps = 0;
                              playerTurn = "RED";
                          }
                          if (currentPlayer == YellowPlayerFour.yellowPlayerFourColName && currentPlayer != "Star")
                          {
                              yellowPlayer4.transform.position = yellowPlayer4Pos;
                              YellowPlayerFour.yellowPlayerFourColName = "none";
                              yellowPlayer4Steps = 0;
                              playerTurn = "RED";
                          } 
                         

                      }


                      if (currentPlayerName.Contains("BLUE PLAYER"))
                      {
                          if (currentPlayer == GreenPlayerOne.greenPlayerOneColName && currentPlayer != "Star")
                          {
                              greenPlayer1.transform.position = greenPlayer1Pos;
                              GreenPlayerOne.greenPlayerOneColName = "none";
                              greenPlayer1Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == GreenPlayerTwo.greenPlayerTwoColName && currentPlayer != "Star")
                          {
                              greenPlayer2.transform.position = greenPlayer2Pos;
                              GreenPlayerTwo.greenPlayerTwoColName = "none";
                              greenPlayer2Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == GreenPlayerThree.greenPlayerThreeColName && currentPlayer != "Star")
                          {
                              greenPlayer3.transform.position = greenPlayer3Pos;
                              GreenPlayerThree.greenPlayerThreeColName = "none";
                              greenPlayer3Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == GreenPlayerFour.greenPlayerFourColName && currentPlayer != "Star")
                          {
                              greenPlayer4.transform.position = greenPlayer4Pos;
                              GreenPlayerFour.greenPlayerFourColName = "none";
                              greenPlayer4Steps = 0;
                              playerTurn = "BLUE";
                          }



                          if (currentPlayer == YellowPlayerOne.yellowPlayerOneColName && currentPlayer != "Star")
                          {
                              yellowPlayer1.transform.position = yellowPlayer1Pos;
                              YellowPlayerOne.yellowPlayerOneColName = "none";
                              yellowPlayer1Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == YellowPlayerTwo.yellowPlayerTwoColName && currentPlayer != "Star")
                          {
                              yellowPlayer2.transform.position = yellowPlayer2Pos;
                              YellowPlayerTwo.yellowPlayerTwoColName = "none";
                              yellowPlayer2Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == YellowPlayerThree.yellowPlayerThreeColName && currentPlayer != "Star")
                          {
                              yellowPlayer3.transform.position = yellowPlayer3Pos;
                              YellowPlayerThree.yellowPlayerThreeColName = "none";
                              yellowPlayer3Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == YellowPlayerFour.yellowPlayerFourColName && currentPlayer != "Star")
                          {
                              yellowPlayer4.transform.position = yellowPlayer4Pos;
                              YellowPlayerFour.yellowPlayerFourColName = "none";
                              yellowPlayer4Steps = 0;
                              playerTurn = "BLUE";
                          }


                          if (currentPlayer == RedPlayerOne.redPlayerOneColName && currentPlayer != "Star")
                          {
                              redPlayer1.transform.position = redPlayer1Pos;
                              RedPlayerOne.redPlayerOneColName = "none";
                              redPlayer1Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == RedPlayerTwo.redPlayerTwoColName && currentPlayer != "Star")
                          {
                              redPlayer2.transform.position = redPlayer2Pos;
                              RedPlayerTwo.redPlayerTwoColName = "none";
                              redPlayer2Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == RedPlayerThree.redPlayerThreeColName && currentPlayer != "Star")
                          {
                              redPlayer3.transform.position = redPlayer3Pos;
                              RedPlayerThree.redPlayerThreeColName = "none";
                              redPlayer3Steps = 0;
                              playerTurn = "BLUE";
                          }
                          if (currentPlayer == RedPlayerFour.redPlayerFourColName && currentPlayer != "Star")
                          {
                              redPlayer4.transform.position = redPlayer4Pos;
                              RedPlayerFour.redPlayerFourColName = "none";
                              redPlayer4Steps = 0;
                              playerTurn = "BLUE";
                          }

                      }


                      if (currentPlayerName.Contains("GREEN PLAYER"))
                      {
                          if (currentPlayer == YellowPlayerOne.yellowPlayerOneColName && currentPlayer != "Star")
                          {
                              yellowPlayer1.transform.position = yellowPlayer1Pos;
                              YellowPlayerOne.yellowPlayerOneColName = "none";
                              yellowPlayer1Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == YellowPlayerTwo.yellowPlayerTwoColName && currentPlayer != "Star")
                          {
                              yellowPlayer2.transform.position = yellowPlayer2Pos;
                              YellowPlayerTwo.yellowPlayerTwoColName = "none";
                              yellowPlayer2Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == YellowPlayerThree.yellowPlayerThreeColName && currentPlayer != "Star")
                          {
                              yellowPlayer3.transform.position = yellowPlayer3Pos;
                              YellowPlayerThree.yellowPlayerThreeColName = "none";
                              yellowPlayer3Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == YellowPlayerFour.yellowPlayerFourColName && currentPlayer != "Star")
                          {
                              yellowPlayer4.transform.position = yellowPlayer4Pos;
                              YellowPlayerFour.yellowPlayerFourColName = "none";
                              yellowPlayer4Steps = 0;
                              playerTurn = "GREEN";
                          }


                          if (currentPlayer == RedPlayerOne.redPlayerOneColName && currentPlayer != "Star")
                          {
                              redPlayer1.transform.position = redPlayer1Pos;
                              RedPlayerOne.redPlayerOneColName = "none";
                              redPlayer1Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == RedPlayerTwo.redPlayerTwoColName && currentPlayer != "Star")
                          {
                              redPlayer2.transform.position = redPlayer2Pos;
                              RedPlayerTwo.redPlayerTwoColName = "none";
                              redPlayer2Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == RedPlayerThree.redPlayerThreeColName && currentPlayer != "Star")
                          {
                              redPlayer3.transform.position = redPlayer3Pos;
                              RedPlayerThree.redPlayerThreeColName = "none";
                              redPlayer3Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == RedPlayerFour.redPlayerFourColName && currentPlayer != "Star")
                          {
                              redPlayer4.transform.position = redPlayer4Pos;
                              RedPlayerFour.redPlayerFourColName = "none";
                              redPlayer4Steps = 0;
                              playerTurn = "GREEN";
                          }


                          if (currentPlayer == BluePlayerOne.bluePlayerOneColName && currentPlayer != "Star")
                          {
                              bluePlayer1.transform.position = bluePlayer1Pos;
                              BluePlayerOne.bluePlayerOneColName = "none";
                              bluePlayer1Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == BluePlayerTwo.bluePlayerTwoColName && currentPlayer != "Star")
                          {
                              bluePlayer2.transform.position = bluePlayer2Pos;
                              BluePlayerTwo.bluePlayerTwoColName = "none";
                              bluePlayer2Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == BluePlayerThree.bluePlayerThreeColName && currentPlayer != "Star")
                          {
                              bluePlayer3.transform.position = bluePlayer3Pos;
                              BluePlayerThree.bluePlayerThreeColName = "none";
                              bluePlayer3Steps = 0;
                              playerTurn = "GREEN";
                          }
                          if (currentPlayer == BluePlayerFour.bluePlayerFourColName && currentPlayer != "Star")
                          {
                              bluePlayer4.transform.position = bluePlayer4Pos;
                              BluePlayerFour.bluePlayerFourColName = "none";
                              bluePlayer4Steps = 0;
                              playerTurn = "GREEN";
                          }


                      }

                      if (currentPlayerName.Contains("YELLOW PLAYER"))
                      {
                          if (currentPlayer == RedPlayerOne.redPlayerOneColName && currentPlayer != "Star")
                          {
                              redPlayer1.transform.position = redPlayer1Pos;
                              RedPlayerOne.redPlayerOneColName = "none";
                              redPlayer1Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == RedPlayerTwo.redPlayerTwoColName && currentPlayer != "Star")
                          {
                              redPlayer2.transform.position = redPlayer2Pos;
                              RedPlayerTwo.redPlayerTwoColName = "none";
                              redPlayer2Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == RedPlayerThree.redPlayerThreeColName && currentPlayer != "Star")
                          {
                              redPlayer3.transform.position = redPlayer3Pos;
                              RedPlayerThree.redPlayerThreeColName = "none";
                              redPlayer3Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == RedPlayerFour.redPlayerFourColName && currentPlayer != "Star")
                          {
                              redPlayer4.transform.position = redPlayer4Pos;
                              RedPlayerFour.redPlayerFourColName = "none";
                              redPlayer4Steps = 0;
                              playerTurn = "YELLOW";
                          }

                          if (currentPlayer == BluePlayerOne.bluePlayerOneColName && currentPlayer != "Star")
                          {
                              bluePlayer1.transform.position = bluePlayer1Pos;
                              BluePlayerOne.bluePlayerOneColName = "none";
                              bluePlayer1Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == BluePlayerTwo.bluePlayerTwoColName && currentPlayer != "Star")
                          {
                              bluePlayer2.transform.position = bluePlayer2Pos;
                              BluePlayerTwo.bluePlayerTwoColName = "none";
                              bluePlayer2Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == BluePlayerThree.bluePlayerThreeColName && currentPlayer != "Star")
                          {
                              bluePlayer3.transform.position = bluePlayer3Pos;
                              BluePlayerThree.bluePlayerThreeColName = "none";
                              bluePlayer3Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == BluePlayerFour.bluePlayerFourColName && currentPlayer != "Star")
                          {
                              bluePlayer4.transform.position = bluePlayer4Pos;
                              BluePlayerFour.bluePlayerFourColName = "none";
                              bluePlayer4Steps = 0;
                              playerTurn = "YELLOW";
                          }


                          if (currentPlayer == GreenPlayerOne.greenPlayerOneColName && currentPlayer != "Star")
                          {
                              greenPlayer1.transform.position = greenPlayer1Pos;
                              GreenPlayerOne.greenPlayerOneColName = "none";
                              greenPlayer1Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == GreenPlayerTwo.greenPlayerTwoColName && currentPlayer != "Star")
                          {
                              greenPlayer2.transform.position = greenPlayer2Pos;
                              GreenPlayerTwo.greenPlayerTwoColName = "none";
                              greenPlayer2Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == GreenPlayerThree.greenPlayerThreeColName && currentPlayer != "Star")
                          {
                              greenPlayer3.transform.position = greenPlayer3Pos;
                              GreenPlayerThree.greenPlayerThreeColName = "none";
                              greenPlayer3Steps = 0;
                              playerTurn = "YELLOW";
                          }
                          if (currentPlayer == GreenPlayerFour.greenPlayerFourColName && currentPlayer != "Star")
                          {
                              greenPlayer4.transform.position = greenPlayer4Pos;
                              GreenPlayerFour.greenPlayerFourColName = "none";
                              greenPlayer4Steps = 0;
                              playerTurn = "YELLOW";
                          }


                      }



                      break;

            }

        }


        switch (MainMenuManager.howManyPlayers)
        {
            case 2:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRoll.position;
                    frameRed.SetActive(true);
                    frameGreen.SetActive(false);
                }
                if (playerTurn == "GREEN")
                {
                    diceRoll.position = greenDiceRoll.position;
                    frameRed.SetActive(false);
                    frameGreen.SetActive(true);
                }

                redPlayer1Button.interactable = false;
                redPlayer2Button.interactable = false;
                redPlayer3Button.interactable = false;
                redPlayer4Button.interactable = false;

                greenPlayer1Button.interactable = false;
                greenPlayer2Button.interactable = false;
                greenPlayer3Button.interactable = false;
                greenPlayer4Button.interactable = false;

                redPlayer1Border.SetActive(false);
                redPlayer2Border.SetActive(false);
                redPlayer3Border.SetActive(false);
                redPlayer4Border.SetActive(false);

                greenPlayer1Border.SetActive(false);
                greenPlayer2Border.SetActive(false);
                greenPlayer3Border.SetActive(false);
                greenPlayer4Border.SetActive(false);
                break;

            case 3:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRoll.position;
                    frameRed.SetActive(true);
                    frameYellow.SetActive(false);
                    frameBlue.SetActive(false);
                }
                if (playerTurn == "YELLOW")
                {
                    diceRoll.position = yellowDiceRoll.position;
                    frameRed.SetActive(false);
                    frameYellow.SetActive(true);
                    frameBlue.SetActive(false);
                }
                if (playerTurn == "BLUE")
                {
                    diceRoll.position = blueDiceRoll.position;
                    frameRed.SetActive(false);
                    frameYellow.SetActive(false);
                    frameBlue.SetActive(true);
                }

                redPlayer1Button.interactable = false;
                redPlayer2Button.interactable = false;
                redPlayer3Button.interactable = false;
                redPlayer4Button.interactable = false;

                bluePlayer1Button.interactable = false;
                bluePlayer2Button.interactable = false;
                bluePlayer3Button.interactable = false;
                bluePlayer4Button.interactable = false;

                yellowPlayer1Button.interactable = false;
                yellowPlayer2Button.interactable = false;
                yellowPlayer3Button.interactable = false;
                yellowPlayer4Button.interactable = false;

                redPlayer1Border.SetActive(false);
                redPlayer2Border.SetActive(false);
                redPlayer3Border.SetActive(false);
                redPlayer4Border.SetActive(false);

                bluePlayer1Border.SetActive(false);
                bluePlayer2Border.SetActive(false);
                bluePlayer3Border.SetActive(false);
                bluePlayer4Border.SetActive(false);

                yellowPlayer1Border.SetActive(false);
                yellowPlayer2Border.SetActive(false);
                yellowPlayer3Border.SetActive(false);
                yellowPlayer4Border.SetActive(false);

                break;

            case 4:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRoll.position;

                    frameRed.SetActive(true);
                    frameGreen.SetActive(false);
                    frameYellow.SetActive(false);
                    frameBlue.SetActive(false);
                }

                if (playerTurn == "BLUE")
                {
                    diceRoll.position = blueDiceRoll.position;

                    frameRed.SetActive(false);
                    frameGreen.SetActive(false);
                    frameYellow.SetActive(false);
                    frameBlue.SetActive(true);
                }

                if (playerTurn == "YELLOW")
                {
                    diceRoll.position = yellowDiceRoll.position;

                    frameRed.SetActive(false);
                    frameGreen.SetActive(false);
                    frameYellow.SetActive(true);
                    frameBlue.SetActive(false);
                }

                if (playerTurn == "GREEN")
                {
                    diceRoll.position = greenDiceRoll.position;

                    frameRed.SetActive(false);
                    frameGreen.SetActive(true);
                    frameYellow.SetActive(false);
                    frameBlue.SetActive(false);
                }

                redPlayer1Button.interactable = false;
                redPlayer2Button.interactable = false;
                redPlayer3Button.interactable = false;
                redPlayer4Button.interactable = false;

                bluePlayer1Button.interactable = false;
                bluePlayer2Button.interactable = false;
                bluePlayer3Button.interactable = false;
                bluePlayer4Button.interactable = false;

                yellowPlayer1Button.interactable = false;
                yellowPlayer2Button.interactable = false;
                yellowPlayer3Button.interactable = false;
                yellowPlayer4Button.interactable = false;

                greenPlayer1Button.interactable = false;
                greenPlayer2Button.interactable = false;
                greenPlayer3Button.interactable = false;
                greenPlayer4Button.interactable = false;

                redPlayer1Border.SetActive(false);
                redPlayer2Border.SetActive(false);
                redPlayer3Border.SetActive(false);
                redPlayer4Border.SetActive(false);

                bluePlayer1Border.SetActive(false);
                bluePlayer2Border.SetActive(false);
                bluePlayer3Border.SetActive(false);
                bluePlayer4Border.SetActive(false);

                yellowPlayer1Border.SetActive(false);
                yellowPlayer2Border.SetActive(false);
                yellowPlayer3Border.SetActive(false);
                yellowPlayer4Border.SetActive(false);

                greenPlayer1Border.SetActive(false);
                greenPlayer2Border.SetActive(false);
                greenPlayer3Border.SetActive(false);
                greenPlayer4Border.SetActive(false);

                break;

        }



    }


    public void DiceRoll()
    {
        diceRollButton.interactable = false;

        selectDiceNumAnimation = randNo.Next(1, 7);
        //selectDiceNumAnimation = 6;

        switch (selectDiceNumAnimation)
        {
            case 1:
                dice1RollAnimation.SetActive(true);
                dice2RollAnimation.SetActive(false);
                dice3RollAnimation.SetActive(false);
                dice4RollAnimation.SetActive(false);
                dice5RollAnimation.SetActive(false);
                dice6RollAnimation.SetActive(false);
                break;

            case 2:
                dice1RollAnimation.SetActive(false);
                dice2RollAnimation.SetActive(true);
                dice3RollAnimation.SetActive(false);
                dice4RollAnimation.SetActive(false);
                dice5RollAnimation.SetActive(false);
                dice6RollAnimation.SetActive(false);
                break;
            
            case 3:
                dice1RollAnimation.SetActive(false);
                dice2RollAnimation.SetActive(false);
                dice3RollAnimation.SetActive(true);
                dice4RollAnimation.SetActive(false);
                dice5RollAnimation.SetActive(false);
                dice6RollAnimation.SetActive(false);
                break;

            case 4:
                dice1RollAnimation.SetActive(false);
                dice2RollAnimation.SetActive(false);
                dice3RollAnimation.SetActive(false);
                dice4RollAnimation.SetActive(true);
                dice5RollAnimation.SetActive(false);
                dice6RollAnimation.SetActive(false);
                break;

            case 5:
                dice1RollAnimation.SetActive(false);
                dice2RollAnimation.SetActive(false);
                dice3RollAnimation.SetActive(false);
                dice4RollAnimation.SetActive(false);
                dice5RollAnimation.SetActive(true);
                dice6RollAnimation.SetActive(false);
                break;

            case 6:
                dice1RollAnimation.SetActive(false);
                dice2RollAnimation.SetActive(false);
                dice3RollAnimation.SetActive(false);
                dice4RollAnimation.SetActive(false);
                dice5RollAnimation.SetActive(false);
                dice6RollAnimation.SetActive(true);
                break;

        }

        StartCoroutine("PlayersNotInitialized");
    }

    IEnumerator PlayersNotInitialized()
    {
        yield return new WaitForSeconds(1f);

        switch(playerTurn)
        {
            case "RED":

                if ((redMovementBlock.Count - redPlayer1Steps) >= selectDiceNumAnimation && redPlayer1Steps > 0 && (redMovementBlock.Count > redPlayer1Steps))
                {
                    redPlayer1Border.SetActive(true);
                    redPlayer1Button.interactable = true; 
                }
                else
                {
                    redPlayer1Border.SetActive(false);
                    redPlayer1Button.interactable = false; 
                }


                if ((redMovementBlock.Count - redPlayer2Steps) >= selectDiceNumAnimation && redPlayer2Steps > 0 && (redMovementBlock.Count > redPlayer2Steps))
                {
                    redPlayer2Border.SetActive(true);
                    redPlayer2Button.interactable = true;
                }
                else
                {
                    redPlayer2Border.SetActive(false);
                    redPlayer2Button.interactable = false;
                }


                if ((redMovementBlock.Count - redPlayer3Steps) >= selectDiceNumAnimation && redPlayer3Steps > 0 && (redMovementBlock.Count > redPlayer3Steps))
                {
                    redPlayer3Border.SetActive(true);
                    redPlayer3Button.interactable = true;
                }
                else
                {
                    redPlayer3Border.SetActive(false);
                    redPlayer3Button.interactable = false;
                }


                if ((redMovementBlock.Count - redPlayer4Steps) >= selectDiceNumAnimation && redPlayer4Steps > 0 && (redMovementBlock.Count > redPlayer4Steps))
                {
                    redPlayer4Border.SetActive(true);
                    redPlayer4Button.interactable = true;
                }
                else
                {
                    redPlayer4Border.SetActive(false);
                    redPlayer4Button.interactable = false;
                }






                if (selectDiceNumAnimation == 6 && redPlayer1Steps == 0)
                {
                    redPlayer1Border.SetActive(true);
                    redPlayer1Button.interactable = true;

                }

                if (selectDiceNumAnimation == 6 && redPlayer2Steps == 0)
                {
                    redPlayer2Border.SetActive(true);
                    redPlayer2Button.interactable = true;

                }

                if (selectDiceNumAnimation == 6 && redPlayer3Steps == 0)
                {
                    redPlayer3Border.SetActive(true);
                    redPlayer3Button.interactable = true;

                }

                if (selectDiceNumAnimation == 6 && redPlayer4Steps == 0)
                {
                    redPlayer4Border.SetActive(true);
                    redPlayer4Button.interactable = true;

                }


                if(!redPlayer1Border.activeInHierarchy && !redPlayer2Border.activeInHierarchy && !redPlayer3Border.activeInHierarchy && !redPlayer4Border.activeInHierarchy)
                {
                    redPlayer1Button.interactable = false;
                    redPlayer2Button.interactable = false;
                    redPlayer3Button.interactable = false;
                    redPlayer4Button.interactable = false;
                    switch(MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            InitializeDice();
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;

                    }


                }
                break;
                
            case "GREEN":


                if ((greenMovementBlock.Count - greenPlayer1Steps) >= selectDiceNumAnimation && greenPlayer1Steps > 0 && (greenMovementBlock.Count > greenPlayer1Steps))
                {
                    greenPlayer1Border.SetActive(true);
                    greenPlayer1Button.interactable = true;
                }
                else
                {
                    greenPlayer1Border.SetActive(false);
                    greenPlayer1Button.interactable = false;
                }


                if ((greenMovementBlock.Count - greenPlayer2Steps) >= selectDiceNumAnimation && greenPlayer2Steps > 0 && (greenMovementBlock.Count > greenPlayer2Steps))
                {
                    greenPlayer2Border.SetActive(true);
                    greenPlayer2Button.interactable = true;
                }
                else
                {
                    greenPlayer2Border.SetActive(false);
                    greenPlayer2Button.interactable = false;
                }


                if ((greenMovementBlock.Count - greenPlayer3Steps) >= selectDiceNumAnimation && greenPlayer3Steps > 0 && (greenMovementBlock.Count > greenPlayer3Steps))
                {
                    greenPlayer3Border.SetActive(true);
                    greenPlayer3Button.interactable = true;
                }
                else
                {
                    greenPlayer3Border.SetActive(false);
                    greenPlayer3Button.interactable = false;
                }



                if ((greenMovementBlock.Count - greenPlayer4Steps) >= selectDiceNumAnimation && greenPlayer4Steps > 0 && (greenMovementBlock.Count > greenPlayer4Steps))
                {
                    greenPlayer4Border.SetActive(true);
                    greenPlayer4Button.interactable = true;
                }
                else
                {
                    greenPlayer4Border.SetActive(false);
                    greenPlayer4Button.interactable = false;
                }


                if (selectDiceNumAnimation == 6 && greenPlayer1Steps == 0)
                {
                    greenPlayer1Border.SetActive(true);
                    greenPlayer1Button.interactable = true;
                }
                
                if (selectDiceNumAnimation == 6 && greenPlayer2Steps == 0)
                {
                    greenPlayer2Border.SetActive(true);
                    greenPlayer2Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && greenPlayer3Steps == 0) 
                {
                    greenPlayer3Border.SetActive(true);
                    greenPlayer3Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && greenPlayer4Steps == 0)
                {
                    greenPlayer4Border.SetActive(true);
                    greenPlayer4Button.interactable = true;
                }




                if (!greenPlayer1Border.activeInHierarchy && !greenPlayer2Border.activeInHierarchy && !greenPlayer3Border.activeInHierarchy && !greenPlayer4Border.activeInHierarchy)
                {
                    greenPlayer1Button.interactable = false;
                    greenPlayer2Button.interactable = false;
                    greenPlayer3Button.interactable = false;
                    greenPlayer4Button.interactable = false;
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                        case 3:
                            //Green is not available...
                            break;
                    
                        case 4:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;
                    
                    }

                }
                break;
               
            case "BLUE":


                if ((blueMovementBlock.Count - bluePlayer1Steps) >= selectDiceNumAnimation && bluePlayer1Steps > 0 && (blueMovementBlock.Count > bluePlayer1Steps))
                {
                    bluePlayer1Border.SetActive(true);
                    bluePlayer1Button.interactable = true;
                }
                else
                {
                    bluePlayer1Border.SetActive(false);
                    bluePlayer1Button.interactable = false;
                }


                if ((blueMovementBlock.Count - bluePlayer2Steps) >= selectDiceNumAnimation && bluePlayer2Steps > 0 && (blueMovementBlock.Count > bluePlayer2Steps))
                {
                    bluePlayer2Border.SetActive(true);
                    bluePlayer2Button.interactable = true;
                }
                else
                {
                    bluePlayer2Border.SetActive(false);
                    bluePlayer2Button.interactable = false;
                }


                if ((blueMovementBlock.Count - bluePlayer3Steps) >= selectDiceNumAnimation && bluePlayer3Steps > 0 && (blueMovementBlock.Count > bluePlayer3Steps))
                {
                    bluePlayer3Border.SetActive(true);
                    bluePlayer3Button.interactable = true;
                }
                else
                {
                    bluePlayer3Border.SetActive(false);
                    bluePlayer3Button.interactable = false;
                }



                if ((blueMovementBlock.Count - bluePlayer4Steps) >= selectDiceNumAnimation && bluePlayer4Steps > 0 && (blueMovementBlock.Count > bluePlayer4Steps))
                {
                    bluePlayer4Border.SetActive(true);
                    bluePlayer4Button.interactable = true;
                }
                else
                {
                    bluePlayer4Border.SetActive(false);
                    bluePlayer4Button.interactable = false;
                }




                if(selectDiceNumAnimation == 6 && bluePlayer1Steps == 0)
                {
                    bluePlayer1Border.SetActive(true);
                    bluePlayer1Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && bluePlayer2Steps == 0)
                {
                    bluePlayer2Border.SetActive(true);
                    bluePlayer2Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && bluePlayer3Steps == 0)
                {
                    bluePlayer3Border.SetActive(true);
                    bluePlayer3Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && bluePlayer4Steps == 0)
                {
                    bluePlayer4Border.SetActive(true);
                    bluePlayer4Button.interactable = true;
                }


                if (!bluePlayer1Border.activeInHierarchy && !bluePlayer2Border.activeInHierarchy && !bluePlayer3Border.activeInHierarchy && !bluePlayer4Border.activeInHierarchy)
                {
                    bluePlayer1Button.interactable = false;
                    bluePlayer2Button.interactable = false;
                    bluePlayer3Button.interactable = false;
                    bluePlayer4Button.interactable = false;

                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                           
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            InitializeDice();
                            break;

                    }
                    
                }
                break;

            case "YELLOW":

                if ((yellowMovementBlock.Count - yellowPlayer1Steps) >= selectDiceNumAnimation && yellowPlayer1Steps > 0 && (yellowMovementBlock.Count > yellowPlayer1Steps))
                {
                    yellowPlayer1Border.SetActive(true);
                    yellowPlayer1Button.interactable = true;
                }
                else
                {
                    yellowPlayer1Border.SetActive(false);
                    yellowPlayer1Button.interactable = false;
                }


                if ((yellowMovementBlock.Count - yellowPlayer2Steps) >= selectDiceNumAnimation && yellowPlayer2Steps > 0 && (yellowMovementBlock.Count > yellowPlayer2Steps))
                {
                    yellowPlayer2Border.SetActive(true);
                    yellowPlayer2Button.interactable = true;
                }
                else
                {
                    yellowPlayer2Border.SetActive(false);
                    yellowPlayer2Button.interactable = false;
                }


                if ((yellowMovementBlock.Count - yellowPlayer3Steps) >= selectDiceNumAnimation && yellowPlayer3Steps > 0 && (yellowMovementBlock.Count > yellowPlayer3Steps))
                {
                    yellowPlayer3Border.SetActive(true);
                    yellowPlayer3Button.interactable = true;
                }
                else
                {
                    yellowPlayer3Border.SetActive(false);
                    yellowPlayer3Button.interactable = false;
                }



                if ((yellowMovementBlock.Count - yellowPlayer4Steps) >= selectDiceNumAnimation && yellowPlayer4Steps > 0 && (yellowMovementBlock.Count > yellowPlayer4Steps))
                {
                    yellowPlayer4Border.SetActive(true);
                    yellowPlayer4Button.interactable = true;
                }
                else
                {
                    yellowPlayer4Border.SetActive(false);
                    yellowPlayer4Button.interactable = false;
                }


                if (selectDiceNumAnimation == 6 && yellowPlayer1Steps == 0)
                {
                    yellowPlayer1Border.SetActive(true);
                    yellowPlayer1Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && yellowPlayer2Steps == 0)
                {
                    yellowPlayer2Border.SetActive(true);
                    yellowPlayer2Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && yellowPlayer3Steps == 0)
                {
                    yellowPlayer3Border.SetActive(true);
                    yellowPlayer3Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && yellowPlayer4Steps == 0)
                {
                    yellowPlayer4Border.SetActive(true);
                    yellowPlayer4Button.interactable = true;
                }






                if (!yellowPlayer1Border.activeInHierarchy && !yellowPlayer2Border.activeInHierarchy && !yellowPlayer3Border.activeInHierarchy && !yellowPlayer4Border.activeInHierarchy)
                {
                    yellowPlayer1Button.interactable = false;
                    yellowPlayer2Button.interactable = false;
                    yellowPlayer3Button.interactable = false;
                    yellowPlayer4Button.interactable = false;


                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:

                            break;

                        case 3:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                    }
                }
                break;



          }
       

    }

    public void RedPlayer1Movement()
    {
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        redPlayer1Button.interactable = false;
        redPlayer2Button.interactable = false;
        redPlayer3Button.interactable = false;
        redPlayer4Button.interactable = false;

        if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer1Steps) > selectDiceNumAnimation)
        {
            if (redPlayer1Steps > 0)
            {
                Vector3[] redPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer1Path[i] = redMovementBlock[redPlayer1Steps + i].transform.position;

                }
            

                redPlayer1Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;
                                
                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer1, iTween.Hash("path", redPlayer1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer1, iTween.Hash("position", redPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "RED PLAYER 1"; 
            }
            else
            {
                if (selectDiceNumAnimation == 6 && redPlayer1Steps == 0)
                {
                    Vector3[] redPlayer1Path = new Vector3[1];
                    redPlayer1Path[0] = redMovementBlock[redPlayer1Steps].transform.position;
                    redPlayer1Steps += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER 1";
                    iTween.MoveTo(redPlayer1, iTween.Hash("position", redPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer1Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer1Path[i] = redMovementBlock[redPlayer1Steps + i].transform.position;

                }
                redPlayer1Steps += selectDiceNumAnimation;

                if (redPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer1, iTween.Hash("path", redPlayer1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer1, iTween.Hash("position", redPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "RED";
                totalRedInHouse += 1;
                Debug.Log("Great job....");
                redPlayer1Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlock.Count - redPlayer1Steps).ToString() + "steps to enter into the house");
                if (redPlayer2Steps == 0 && redPlayer3Steps == 0 && redPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }


    public void RedPlayer2Movement()
    {
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        redPlayer1Button.interactable = false;
        redPlayer2Button.interactable = false;
        redPlayer3Button.interactable = false;
        redPlayer4Button.interactable = false;

        if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer2Steps) > selectDiceNumAnimation)
        {
            if (redPlayer2Steps > 0)
            {
                Vector3[] redPlayer2Path = new Vector3[selectDiceNumAnimation];
                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer2Path[i] = redMovementBlock[redPlayer2Steps + i].transform.position;

                }
                redPlayer2Steps += selectDiceNumAnimation;
                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer2, iTween.Hash("path", redPlayer2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer2, iTween.Hash("position", redPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "RED PLAYER 2";
            }
            else
            {

                if (selectDiceNumAnimation == 6 && redPlayer2Steps == 0)
                {
                    Vector3[] redPlayer2Path = new Vector3[1];
                    redPlayer2Path[0] = redMovementBlock[redPlayer2Steps].transform.position;
                    redPlayer2Steps += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER 2";
                    iTween.MoveTo(redPlayer2, iTween.Hash("position", redPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer2Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer2Path[i] = redMovementBlock[redPlayer2Steps + i].transform.position;

                }
                redPlayer2Steps += selectDiceNumAnimation;

                if (redPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer2, iTween.Hash("path", redPlayer2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer2, iTween.Hash("position", redPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "RED";
                totalRedInHouse += 1;
                Debug.Log("Great job....");
                redPlayer2Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlock.Count - redPlayer2Steps).ToString() + "steps to enter into the house");
                if (redPlayer1Steps == 0 && redPlayer3Steps == 0 && redPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }

    public void RedPlayer3Movement()
    {
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        redPlayer1Button.interactable = false;
        redPlayer2Button.interactable = false;
        redPlayer3Button.interactable = false;
        redPlayer4Button.interactable = false;

        if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer3Steps) > selectDiceNumAnimation)
        {
            if (redPlayer3Steps > 0)
            {
                Vector3[] redPlayer3Path = new Vector3[selectDiceNumAnimation];
                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer3Path[i] = redMovementBlock[redPlayer3Steps + i].transform.position;

                }
                redPlayer3Steps += selectDiceNumAnimation;
                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer3, iTween.Hash("path", redPlayer3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer3, iTween.Hash("position", redPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "RED PLAYER 3";
            }
            else
            {

                if (selectDiceNumAnimation == 6 && redPlayer3Steps == 0)
                {
                    Vector3[] redPlayer3Path = new Vector3[1];
                    redPlayer3Path[0] = redMovementBlock[redPlayer3Steps].transform.position;
                    redPlayer3Steps += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER 3";
                    iTween.MoveTo(redPlayer3, iTween.Hash("position", redPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer3Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer3Path[i] = redMovementBlock[redPlayer3Steps + i].transform.position;

                }
                redPlayer3Steps += selectDiceNumAnimation;

                if (redPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer3, iTween.Hash("path", redPlayer3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer3, iTween.Hash("position", redPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "RED";
                totalRedInHouse += 1;
                Debug.Log("Great job....");
                redPlayer3Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlock.Count - redPlayer3Steps).ToString() + "steps to enter into the house");
                if (redPlayer1Steps == 0 && redPlayer2Steps == 0 && redPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }

    public void RedPlayer4Movement()
    {
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        redPlayer1Button.interactable = false;
        redPlayer2Button.interactable = false;
        redPlayer3Button.interactable = false;
        redPlayer4Button.interactable = false;

        if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer4Steps) > selectDiceNumAnimation)
        {
            if (redPlayer4Steps > 0)
            {
                Vector3[] redPlayer4Path = new Vector3[selectDiceNumAnimation];
                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer4Path[i] = redMovementBlock[redPlayer4Steps + i].transform.position;

                }
                redPlayer4Steps += selectDiceNumAnimation;
                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer4, iTween.Hash("path", redPlayer4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer4, iTween.Hash("position", redPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "RED PLAYER 4";
            }
            else
            {

                if (selectDiceNumAnimation == 6 && redPlayer4Steps == 0)
                {
                    Vector3[] redPlayer4Path = new Vector3[1];
                    redPlayer4Path[0] = redMovementBlock[redPlayer4Steps].transform.position;
                    redPlayer4Steps += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER 4";
                    iTween.MoveTo(redPlayer4, iTween.Hash("position", redPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer4Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer4Path[i] = redMovementBlock[redPlayer4Steps + i].transform.position;

                }
                redPlayer4Steps += selectDiceNumAnimation;

                if (redPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer4, iTween.Hash("path", redPlayer4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer4, iTween.Hash("position", redPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "RED";
                totalRedInHouse += 1;
                Debug.Log("Great job....");
                redPlayer4Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlock.Count - redPlayer4Steps).ToString() + "steps to enter into the house");
                if (redPlayer1Steps == 0 && redPlayer2Steps == 0 && redPlayer3Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }



    //.............................Green...................................................


    public void GreenPlayer1Movement()
    {
        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        greenPlayer1Button.interactable = false;
        greenPlayer2Button.interactable = false;
        greenPlayer3Button.interactable = false;
        greenPlayer4Button.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer1Steps) > selectDiceNumAnimation)
        {
            if (greenPlayer1Steps > 0)
            {
                Vector3[] greenPlayer1Path = new Vector3[selectDiceNumAnimation];
                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer1Path[i] = greenMovementBlock[greenPlayer1Steps + i].transform.position;

                }
                greenPlayer1Steps += selectDiceNumAnimation;
                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:

                            //Green is not available...
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                if (greenPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer1, iTween.Hash("path", greenPlayer1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer1, iTween.Hash("position", greenPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "GREEN PLAYER 1";
            }
            else
            {

                if (selectDiceNumAnimation == 6 && greenPlayer1Steps == 0)
                {
                    Vector3[] greenPlayer1Path = new Vector3[1];
                    greenPlayer1Path[0] = greenMovementBlock[greenPlayer1Steps].transform.position;
                    greenPlayer1Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER 1";
                    iTween.MoveTo(greenPlayer1, iTween.Hash("position", greenPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer1Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer1Path[i] = greenMovementBlock[greenPlayer1Steps + i].transform.position;

                }
                greenPlayer1Steps += selectDiceNumAnimation;

                if (greenPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer1, iTween.Hash("path", greenPlayer1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer1, iTween.Hash("position", greenPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "GREEN";
                totalGreenInHouse += 1;
                Debug.Log("Great job....");
                greenPlayer1Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlock.Count - greenPlayer1Steps).ToString() + "steps to enter into the house");
                if (greenPlayer2Steps == 0 && greenPlayer3Steps == 0 && greenPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:

                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }



    public void GreenPlayer2Movement()
    {
        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        greenPlayer1Button.interactable = false;
        greenPlayer2Button.interactable = false;
        greenPlayer3Button.interactable = false;
        greenPlayer4Button.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer2Steps) > selectDiceNumAnimation)
        {
            if (greenPlayer2Steps > 0)
            {
                Vector3[] greenPlayer2Path = new Vector3[selectDiceNumAnimation];
                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer2Path[i] = greenMovementBlock[greenPlayer2Steps + i].transform.position;

                }
                greenPlayer2Steps += selectDiceNumAnimation;
                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:

                            //Green is not available...
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                if (greenPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer2, iTween.Hash("path", greenPlayer2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer2, iTween.Hash("position", greenPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "GREEN PLAYER 2";
            }
            else
            {

                if (selectDiceNumAnimation == 6 && greenPlayer2Steps == 0)
                {
                    Vector3[] greenPlayer2Path = new Vector3[1];
                    greenPlayer2Path[0] = greenMovementBlock[greenPlayer2Steps].transform.position;
                    greenPlayer2Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER 2";
                    iTween.MoveTo(greenPlayer2, iTween.Hash("position", greenPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer2Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer2Path[i] = greenMovementBlock[greenPlayer2Steps + i].transform.position;

                }
                greenPlayer2Steps += selectDiceNumAnimation;

                if (greenPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer2, iTween.Hash("path", greenPlayer2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer2, iTween.Hash("position", greenPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "GREEN";
                totalGreenInHouse += 1;
                Debug.Log("Great job....");
                greenPlayer2Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlock.Count - greenPlayer2Steps).ToString() + "steps to enter into the house");
                if (greenPlayer1Steps == 0 && greenPlayer3Steps == 0 && greenPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:

                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }



    public void GreenPlayer3Movement()
    {
        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        greenPlayer1Button.interactable = false;
        greenPlayer2Button.interactable = false;
        greenPlayer3Button.interactable = false;
        greenPlayer4Button.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer3Steps) > selectDiceNumAnimation)
        {
            if (greenPlayer3Steps > 0)
            {
                Vector3[] greenPlayer3Path = new Vector3[selectDiceNumAnimation];
                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer3Path[i] = greenMovementBlock[greenPlayer3Steps + i].transform.position;

                }
                greenPlayer3Steps += selectDiceNumAnimation;
                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:

                            //Green is not available...
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                if (greenPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer3, iTween.Hash("path", greenPlayer3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer3, iTween.Hash("position", greenPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "GREEN PLAYER 3";
            }
            else
            {

                if (selectDiceNumAnimation == 6 && greenPlayer3Steps == 0)
                {
                    Vector3[] greenPlayer3Path = new Vector3[1];
                    greenPlayer3Path[0] = greenMovementBlock[greenPlayer3Steps].transform.position;
                    greenPlayer3Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER 3";
                    iTween.MoveTo(greenPlayer3, iTween.Hash("position", greenPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer3Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer3Path[i] = greenMovementBlock[greenPlayer3Steps + i].transform.position;

                }
                greenPlayer3Steps += selectDiceNumAnimation;

                if (greenPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer3, iTween.Hash("path", greenPlayer3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer3, iTween.Hash("position", greenPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "GREEN";
                totalGreenInHouse += 1;
                Debug.Log("Great job....");
                greenPlayer3Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlock.Count - greenPlayer3Steps).ToString() + "steps to enter into the house");
                if (greenPlayer1Steps == 0 && greenPlayer2Steps == 0 && greenPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:

                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }



    public void GreenPlayer4Movement()
    {
        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        greenPlayer1Button.interactable = false;
        greenPlayer2Button.interactable = false;
        greenPlayer3Button.interactable = false;
        greenPlayer4Button.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer4Steps) > selectDiceNumAnimation)
        {
            if (greenPlayer4Steps > 0)
            {
                Vector3[] greenPlayer4Path = new Vector3[selectDiceNumAnimation];
                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer4Path[i] = greenMovementBlock[greenPlayer4Steps + i].transform.position;

                }
                greenPlayer4Steps += selectDiceNumAnimation;
                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:

                            //Green is not available...
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                if (greenPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer4, iTween.Hash("path", greenPlayer4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer4, iTween.Hash("position", greenPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "GREEN PLAYER 4";
            }
            else
            {

                if (selectDiceNumAnimation == 6 && greenPlayer4Steps == 0)
                {
                    Vector3[] greenPlayer4Path = new Vector3[1];
                    greenPlayer4Path[0] = greenMovementBlock[greenPlayer4Steps].transform.position;
                    greenPlayer4Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER 4";
                    iTween.MoveTo(greenPlayer4, iTween.Hash("position", greenPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer4Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer4Path[i] = greenMovementBlock[greenPlayer4Steps + i].transform.position;

                }
                greenPlayer4Steps += selectDiceNumAnimation;

                if (greenPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer4, iTween.Hash("path", greenPlayer4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer4, iTween.Hash("position", greenPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "GREEN";
                totalGreenInHouse += 1;
                Debug.Log("Great job....");
                greenPlayer4Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlock.Count - greenPlayer4Steps).ToString() + "steps to enter into the house");
                if (greenPlayer1Steps == 0 && greenPlayer2Steps == 0 && greenPlayer3Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:

                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }



    //.............................BLue..........................................







    public void BluePlayer1Movement()
    {
        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        bluePlayer1Button.interactable = false;
        bluePlayer2Button.interactable = false;
        bluePlayer3Button.interactable = false;
        bluePlayer4Button.interactable = false;

        if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer1Steps) > selectDiceNumAnimation)
        {
            if (bluePlayer1Steps > 0)
            {
                Vector3[] bluePlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer1Path[i] = blueMovementBlock[bluePlayer1Steps + i].transform.position;

                }


                bluePlayer1Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                           //not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }

                if (bluePlayer1Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer1, iTween.Hash("path", bluePlayer1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer1, iTween.Hash("position", bluePlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "BLUE PLAYER 1";
            }
            else
            {
                if (selectDiceNumAnimation == 6 && bluePlayer1Steps == 0)
                {
                    Vector3[] bluePlayer1Path = new Vector3[1];
                    bluePlayer1Path[0] = blueMovementBlock[bluePlayer1Steps].transform.position;
                    bluePlayer1Steps += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "BLUE PLAYER 1";
                    iTween.MoveTo(bluePlayer1, iTween.Hash("position", bluePlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer1Steps) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer1Path[i] = blueMovementBlock[bluePlayer1Steps + i].transform.position;

                }
                bluePlayer1Steps += selectDiceNumAnimation;

                if (bluePlayer1Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer1, iTween.Hash("path", bluePlayer1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer1, iTween.Hash("position", bluePlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "BLUE";
                totalBlueInHouse += 1;
                Debug.Log("Great job....");
                bluePlayer1Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (blueMovementBlock.Count - bluePlayer1Steps).ToString() + "steps to enter into the house");
                if (bluePlayer2Steps == 0 && bluePlayer3Steps == 0 && bluePlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }



    public void BluePlayer2Movement()
    {
        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        bluePlayer1Button.interactable = false;
        bluePlayer2Button.interactable = false;
        bluePlayer3Button.interactable = false;
        bluePlayer4Button.interactable = false;

        if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer2Steps) > selectDiceNumAnimation)
        {
            if (bluePlayer2Steps > 0)
            {
                Vector3[] bluePlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer2Path[i] = blueMovementBlock[bluePlayer2Steps + i].transform.position;

                }


                bluePlayer2Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }

                if (bluePlayer2Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer2, iTween.Hash("path", bluePlayer2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer2, iTween.Hash("position", bluePlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "BLUE PLAYER 2";
            }
            else
            {
                if (selectDiceNumAnimation == 6 && bluePlayer2Steps == 0)
                {
                    Vector3[] bluePlayer2Path = new Vector3[1];
                    bluePlayer2Path[0] = blueMovementBlock[bluePlayer2Steps].transform.position;
                    bluePlayer2Steps += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "BLUE PLAYER 2";
                    iTween.MoveTo(bluePlayer2, iTween.Hash("position", bluePlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer2Steps) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer2Path[i] = blueMovementBlock[bluePlayer2Steps + i].transform.position;

                }
                bluePlayer2Steps += selectDiceNumAnimation;

                if (bluePlayer2Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer2, iTween.Hash("path", bluePlayer2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer2, iTween.Hash("position", bluePlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "BLUE";
                totalBlueInHouse += 1;
                Debug.Log("Great job....");
                bluePlayer2Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (blueMovementBlock.Count - bluePlayer2Steps).ToString() + "steps to enter into the house");
                if (bluePlayer1Steps == 0 && bluePlayer3Steps == 0 && bluePlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }




    public void BluePlayer3Movement()
    {
        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        bluePlayer1Button.interactable = false;
        bluePlayer2Button.interactable = false;
        bluePlayer3Button.interactable = false;
        bluePlayer4Button.interactable = false;

        if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer3Steps) > selectDiceNumAnimation)
        {
            if (bluePlayer3Steps > 0)
            {
                Vector3[] bluePlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer3Path[i] = blueMovementBlock[bluePlayer3Steps + i].transform.position;

                }


                bluePlayer3Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }

                if (bluePlayer3Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer3, iTween.Hash("path", bluePlayer3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer3, iTween.Hash("position", bluePlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "BLUE PLAYER 3";
            }
            else
            {
                if (selectDiceNumAnimation == 6 && bluePlayer3Steps == 0)
                {
                    Vector3[] bluePlayer3Path = new Vector3[1];
                    bluePlayer3Path[0] = blueMovementBlock[bluePlayer3Steps].transform.position;
                    bluePlayer3Steps += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "BLUE PLAYER 3";
                    iTween.MoveTo(bluePlayer3, iTween.Hash("position", bluePlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer3Steps) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer3Path[i] = blueMovementBlock[bluePlayer3Steps + i].transform.position;

                }
                bluePlayer3Steps += selectDiceNumAnimation;

                if (bluePlayer3Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer3, iTween.Hash("path", bluePlayer3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer3, iTween.Hash("position", bluePlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "BLUE";
                totalBlueInHouse += 1;
                Debug.Log("Great job....");
                bluePlayer3Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (blueMovementBlock.Count - bluePlayer3Steps).ToString() + "steps to enter into the house");
                if (bluePlayer1Steps == 0 && bluePlayer2Steps == 0 && bluePlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }



    public void BluePlayer4Movement()
    {
        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        bluePlayer1Button.interactable = false;
        bluePlayer2Button.interactable = false;
        bluePlayer3Button.interactable = false;
        bluePlayer4Button.interactable = false;

        if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer4Steps) > selectDiceNumAnimation)
        {
            if (bluePlayer4Steps > 0)
            {
                Vector3[] bluePlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer4Path[i] = blueMovementBlock[bluePlayer4Steps + i].transform.position;

                }


                bluePlayer4Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }

                if (bluePlayer4Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer4, iTween.Hash("path", bluePlayer4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer4, iTween.Hash("position", bluePlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "BLUE PLAYER 4";
            }
            else
            {
                if (selectDiceNumAnimation == 6 && bluePlayer4Steps == 0)
                {
                    Vector3[] bluePlayer4Path = new Vector3[1];
                    bluePlayer4Path[0] = blueMovementBlock[bluePlayer4Steps].transform.position;
                    bluePlayer4Steps += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "BLUE PLAYER 4";
                    iTween.MoveTo(bluePlayer4, iTween.Hash("position", bluePlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer4Steps) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer4Path[i] = blueMovementBlock[bluePlayer4Steps + i].transform.position;

                }
                bluePlayer4Steps += selectDiceNumAnimation;

                if (bluePlayer4Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer4, iTween.Hash("path", bluePlayer4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer4, iTween.Hash("position", bluePlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "BLUE";
                totalBlueInHouse += 1;
                Debug.Log("Great job....");
                bluePlayer4Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (blueMovementBlock.Count - bluePlayer4Steps).ToString() + "steps to enter into the house");
                if (bluePlayer1Steps == 0 && bluePlayer2Steps == 0 && bluePlayer3Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }




    //..................................yellow.................................................




    public void YellowPlayer1Movement()
    {
        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        yellowPlayer1Button.interactable = false;
        yellowPlayer2Button.interactable = false;
        yellowPlayer3Button.interactable = false;
        yellowPlayer4Button.interactable = false;

        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer1Steps) > selectDiceNumAnimation)
        {
            if (yellowPlayer1Steps > 0)
            {
                Vector3[] yellowPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer1Path[i] = yellowMovementBlock[yellowPlayer1Steps + i].transform.position;

                }


                yellowPlayer1Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }

                if (yellowPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("path", yellowPlayer1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("position", yellowPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "YELLOW PLAYER 1";
            }
            else
            {
                if (selectDiceNumAnimation == 6 && yellowPlayer1Steps == 0)
                {
                    Vector3[] yellowPlayer1Path = new Vector3[1];
                    yellowPlayer1Path[0] = yellowMovementBlock[yellowPlayer1Steps].transform.position;
                    yellowPlayer1Steps += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW PLAYER 1";
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("position", yellowPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer1Steps) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer1Path[i] = yellowMovementBlock[yellowPlayer1Steps + i].transform.position;

                }
                yellowPlayer1Steps += selectDiceNumAnimation;

                if (yellowPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("path", yellowPlayer1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("position", yellowPlayer1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "YELLOW";
                totalYellowInHouse += 1;
                Debug.Log("Great job....");
                yellowPlayer1Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (yellowMovementBlock.Count - yellowPlayer1Steps).ToString() + "steps to enter into the house");
                if (yellowPlayer2Steps == 0 && yellowPlayer3Steps == 0 && yellowPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }




    public void YellowPlayer2Movement()
    {
        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        yellowPlayer1Button.interactable = false;
        yellowPlayer2Button.interactable = false;
        yellowPlayer3Button.interactable = false;
        yellowPlayer4Button.interactable = false;

        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer2Steps) > selectDiceNumAnimation)
        {
            if (yellowPlayer2Steps > 0)
            {
                Vector3[] yellowPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer2Path[i] = yellowMovementBlock[yellowPlayer2Steps + i].transform.position;

                }


                yellowPlayer2Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }

                if (yellowPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("path", yellowPlayer2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("position", yellowPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "YELLOW PLAYER 2";
            }
            else
            {
                if (selectDiceNumAnimation == 6 && yellowPlayer2Steps == 0)
                {
                    Vector3[] yellowPlayer2Path = new Vector3[1];
                    yellowPlayer2Path[0] = yellowMovementBlock[yellowPlayer2Steps].transform.position;
                    yellowPlayer2Steps += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW PLAYER 2";
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("position", yellowPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer2Steps) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer2Path[i] = yellowMovementBlock[yellowPlayer2Steps + i].transform.position;

                }
                yellowPlayer2Steps += selectDiceNumAnimation;

                if (yellowPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("path", yellowPlayer2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("position", yellowPlayer2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "YELLOW";
                totalYellowInHouse += 1;
                Debug.Log("Great job....");
                yellowPlayer2Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (yellowMovementBlock.Count - yellowPlayer2Steps).ToString() + "steps to enter into the house");
                if (yellowPlayer1Steps == 0 && yellowPlayer3Steps == 0 && yellowPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }

  






    public void YellowPlayer3Movement()
    {
        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        yellowPlayer1Button.interactable = false;
        yellowPlayer2Button.interactable = false;
        yellowPlayer3Button.interactable = false;
        yellowPlayer4Button.interactable = false;

        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer3Steps) > selectDiceNumAnimation)
        {
            if (yellowPlayer3Steps > 0)
            {
                Vector3[] yellowPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer3Path[i] = yellowMovementBlock[yellowPlayer3Steps + i].transform.position;

                }


                yellowPlayer3Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }

                if (yellowPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("path", yellowPlayer3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("position", yellowPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "YELLOW PLAYER 3";
            }
            else
            {
                if (selectDiceNumAnimation == 6 && yellowPlayer3Steps == 0)
                {
                    Vector3[] yellowPlayer3Path = new Vector3[1];
                    yellowPlayer3Path[0] = yellowMovementBlock[yellowPlayer3Steps].transform.position;
                    yellowPlayer3Steps += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW PLAYER 3";
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("position", yellowPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer3Steps) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer3Path[i] = yellowMovementBlock[yellowPlayer3Steps + i].transform.position;

                }
                yellowPlayer3Steps += selectDiceNumAnimation;

                if (yellowPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("path", yellowPlayer3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("position", yellowPlayer3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "YELLOW";
                totalYellowInHouse += 1;
                Debug.Log("Great job....");
                yellowPlayer3Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (yellowMovementBlock.Count - yellowPlayer3Steps).ToString() + "steps to enter into the house");
                if (yellowPlayer1Steps == 0 && yellowPlayer2Steps == 0 && yellowPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }




    public void YellowPlayer4Movement()
    {
        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        yellowPlayer1Button.interactable = false;
        yellowPlayer2Button.interactable = false;
        yellowPlayer3Button.interactable = false;
        yellowPlayer4Button.interactable = false;

        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer4Steps) > selectDiceNumAnimation)
        {
            if (yellowPlayer4Steps > 0)
            {
                Vector3[] yellowPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer4Path[i] = yellowMovementBlock[yellowPlayer4Steps + i].transform.position;

                }


                yellowPlayer4Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }

                if (yellowPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("path", yellowPlayer4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("position", yellowPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                currentPlayerName = "YELLOW PLAYER 4";
            }
            else
            {
                if (selectDiceNumAnimation == 6 && yellowPlayer4Steps == 0)
                {
                    Vector3[] yellowPlayer4Path = new Vector3[1];
                    yellowPlayer4Path[0] = yellowMovementBlock[yellowPlayer4Steps].transform.position;
                    yellowPlayer4Steps += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW PLAYER 4";
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("position", yellowPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

            }

        }

        else
        {
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer4Steps) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer4Path[i] = yellowMovementBlock[yellowPlayer4Steps + i].transform.position;

                }
                yellowPlayer4Steps += selectDiceNumAnimation;

                if (yellowPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("path", yellowPlayer4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("position", yellowPlayer4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }

                playerTurn = "YELLOW";
                totalYellowInHouse += 1;
                Debug.Log("Great job....");
                yellowPlayer4Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (yellowMovementBlock.Count - yellowPlayer4Steps).ToString() + "steps to enter into the house");
                if (yellowPlayer2Steps == 0 && yellowPlayer2Steps == 0 && yellowPlayer3Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;

                    }
                }
                InitializeDice();
            }

        }

    }




    // Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;

        randNo = new System.Random();

        dice1RollAnimation.SetActive(false);
        dice2RollAnimation.SetActive(false);
        dice3RollAnimation.SetActive(false);
        dice4RollAnimation.SetActive(false); 
        dice5RollAnimation.SetActive(false);
        dice6RollAnimation.SetActive(false);

        //Players initial Positions.......
        redPlayer1Pos = redPlayer1.transform.position;
        redPlayer2Pos = redPlayer2.transform.position;
        redPlayer3Pos = redPlayer3.transform.position;
        redPlayer4Pos = redPlayer4.transform.position;

        greenPlayer1Pos = greenPlayer1.transform.position;
        greenPlayer2Pos = greenPlayer2.transform.position;
        greenPlayer3Pos = greenPlayer3.transform.position;
        greenPlayer4Pos = greenPlayer4.transform.position;

        yellowPlayer1Pos = yellowPlayer1.transform.position;
        yellowPlayer2Pos = yellowPlayer2.transform.position;
        yellowPlayer3Pos = yellowPlayer3.transform.position;
        yellowPlayer4Pos = yellowPlayer4.transform.position;

        bluePlayer1Pos = bluePlayer1.transform.position;
        bluePlayer2Pos = bluePlayer2.transform.position;
        bluePlayer3Pos = bluePlayer3.transform.position;
        bluePlayer4Pos = bluePlayer4.transform.position;

        //Deactivating players round borders.......

        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        redScreen.SetActive(false);
        blueScreen.SetActive(false);
        yellowScreen.SetActive(false);
        greenScreen.SetActive(false);


        switch(MainMenuManager.howManyPlayers){
            case 2:
                playerTurn = "RED";

                frameRed.SetActive(true);
                frameGreen.SetActive(false);
                
                bluePlayer1.SetActive(false);
                bluePlayer2.SetActive(false);
                bluePlayer3.SetActive(false);
                bluePlayer4.SetActive(false);

                yellowPlayer1.SetActive(false);
                yellowPlayer2.SetActive(false);
                yellowPlayer3.SetActive(false);
                yellowPlayer4.SetActive(false);

                break;

            case 3:

                playerTurn = "RED";

                frameYellow.SetActive(false);
                frameRed.SetActive(true);
                frameBlue.SetActive(false);

                diceRoll.position = redDiceRoll.position;

                greenPlayer1.SetActive(false);
                greenPlayer2.SetActive(false);
                greenPlayer3.SetActive(false);
                greenPlayer4.SetActive(false);

                break;

            case 4:
                playerTurn = "RED";
                
                diceRoll.position = redDiceRoll.position;

                frameRed.SetActive(true);
                frameGreen.SetActive(false);
                frameBlue.SetActive(false);
                frameYellow.SetActive(false);

                break;

        }
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
