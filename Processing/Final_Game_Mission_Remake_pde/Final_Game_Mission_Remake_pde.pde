import ddf.minim.*; //Libraries //<>// //<>// //<>// //<>//

import de.looksgood.ani.*; //<>// //<>//
import de.looksgood.ani.easing.*;

import gifAnimation.*;

PImage smolPot, badC, goodC; //Images
Gif bigPot, backg;
PFont pixel;

Minim minim;
AudioPlayer mainMenu, evilPot, gameStart,gameRestart,gameEnd,almostDead, levelUp,healthDown; //music

int potX,potY; //assets x's and y's

enemy d[]; //enemies

int gameStage, gameH, counter, tutorial; //inputs/progress number
int level;

click Clicker; //click asset

void setup() {

  size(700, 1000);
  bigPot = new Gif(this, "pot_pixel.gif");
  backg = new Gif(this, "background.gif");
  backg.loop();
  bigPot.loop();
  pixel = loadFont("Pixellari.vlw");
  smolPot = loadImage("smol_pot.png");
  badC = loadImage("badCircle.png");
  goodC = loadImage("goodCircle.png");
  //background = loadImage("background.png");
  
  minim = new Minim(this);
  //mainMenu = minim.loadFile("
  gameStart = minim.loadFile("Select Menu.wav");
  levelUp  = minim.loadFile("Level Up.wav");
  healthDown = minim.loadFile("DownSelect.wav");
  
  potX = 350;
  potY = 400;

  gameStage = 0;
  gameH = 50;
  counter = 0;
  tutorial = 1;
  level = 1;
 

  frameRate(30);
  textFont(pixel);

  d=new enemy[30];
  for (int i=0; i < 30; i++) {
    d[i] = new enemy();
  }

  Clicker = new click();
}


void draw() {



  if (gameStage == 0) { // Game Title
    background(200,100,50);
    textSize(30);
    text("Press t to check if this even works.", 100, 500);
    if (keyPressed == true) {
      if (key == 't') {
        gameStage = 1;
      }
    }
  }

  if (gameStage == 1) {  //Game Start
    gameStart.play();
    background(255);
    fill(0);
    text("INPUT ANIMATION HERE", 210,400);
    text("Press o to end tutorial!",210,450);
    
    if (keyPressed == true){
      if (key == 'o'){
        tutorial = 0;
      }
    }
    

    if (tutorial == 0) { //Game Begins
      image(backg, 350, 500);
      imageMode(CENTER);
      image(bigPot,potX,potY);
      for (int i=0; i< 30; i++) { //<>//
        d[i].display(); 
        if (d[i].y>height)
          d[i]=new enemy();
      }
      

      textSize(50);
      text( "Health", 30, 900);
      text( gameH, 250, 900);

      Clicker.display();
      Clicker.isclicked();
      Clicker.gui();
      
      
      
      if((counter > 10) && ( counter < 19)){
        level = 2;
        levelUp.play();
      }
       
         
      if((counter > 20) && ( counter < 29)){
        level = 3;
        levelUp.play();
        levelUp.rewind();
         }
         
      if((counter > 30) && ( counter < 39)){
        level = 4;
        levelUp.play();
        levelUp.rewind();
      }
       
         
      if((counter > 40) && ( counter < 49)){
        level = 5;
        levelUp.play();
        levelUp.rewind();
         }
         
      //if (counter == 30){ // thought about a end but it was boring af
      //  gameStage = 4;
      //}

      if (gameH == 0) {
        gameStage = 3;
      }
    }
  }

  if (gameStage == 3) {
    background(0);
    fill(255);
    textSize(30);
    text("You have perished!", 210, 400);
    text("Score",250,450);
    text(counter,400,450);
    text("Press space to start over", 180,500);
    
    if(keyPressed == true){
      if (key == ' '){
        setup();
      }
    }
  }
  
  //if (gameStage == 4) { //if there was a ending
  //  fill(255);
  //  background(0);
  //  textSize(25);
  //  text("YOU HAVE BEATEN THE EVIL POT LORD!", 110, 400);
    
  //}
}
