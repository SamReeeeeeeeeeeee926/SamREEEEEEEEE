//IMGMODE CENTER FOR RECT IS GLITCHED, SYSTEM HAS RIGHT COORDS, BUT SCREEN SHOWS IMGMODE CORNER FOR RECT, EVEN THOUGH IT'S NOT SUPPOSED TO AFFECT THE SHAPE.


import de.looksgood.ani.*;
import de.looksgood.ani.easing.*;

float tX, tY, x, bX1, bY1, dia1, bX2, bY2, dia2, bX3, bY3, dia3;
float x1, y1, x2, y2;
float dia11, dia22;

int gameS;

PFont g;

AniSequence introWord;

void setup() {
  size(712, 1000);
  smooth();
  stroke(0);
  textAlign(CENTER);
  rectMode(CENTER);
  // background(0);

  tX = 356;
  tY = 1200;
  x = 0.5;
  bX1 =356;
  bY1 = 450;
  dia1 = 50;
  bX2 =356;
  bY2 = 550;
  dia2 = 50;
  bX3 =356;
  bY3 = 650;
  dia3 = 50;
  gameS = 1;

  //options
  x1 = 356;
  x2 = 356;  
  y1 = 400;
  y2 = 510;
  dia11 = 50;
  dia22 = 50;

  g = loadFont("Gulim.vlw");

  Ani.init(this);

  introWord = new AniSequence(this);
  introWord.beginSequence();

  //step 0
  introWord.add(Ani.to(this, 1.5, "tY:200", Ani.EXPO_OUT));

  introWord.endSequence();
  introWord.start();
}


void draw() {
  if (gameS ==1) {
    background(0);
    textFont(g);
    textSize(50);
    fill(255);
    text("TITLE", tX, tY);


    tY += sin(x/8)* 0.5; //title bounce
    x++;

    textSize(10);
    text("Title X:" + " " + tX, 80, 900);
    text("Title Y:" + " " + tY, 80, 930);
    text("Mouse X:" + " " + mouseX, 80, 870);
    text("Mouse Y:" + " " + mouseY, 80, 840);

    if (introWord.isEnded()) {
      fill(255, 0, 0);
      rect(bX1, bY1, dia1, dia1);
      fill(255);
      textSize(20);
      text("START", 356, 500);

      fill(0, 255, 0);
      rect(bX2, bY2, dia2, dia2);
      fill(255);
      textSize(20);
      text("OPTIONS", 356, 600);

      fill(100, 100, 10);
      rect(bX3, bY3, dia3, dia3);
      fill(255);
      textSize(20);
      text("EXIT", 356, 700);

      dia1 += sin(x/4)* 0.5; //heartbeat1
      dia2 += sin(x/4)* 0.5; //heartbeat2
      dia3 += sin(x/4)* 0.5; //heartbeat3
    }

    if (dist(mouseX, mouseY, bX1, bY1) < (dia1/2)) {
      ellipse(mouseX, mouseY, 10, 10);

      if (mousePressed == true) {
        gameS = 2;
      }
    }

    if (dist(mouseX, mouseY, bX2, bY2) < (dia2/2)) {
      ellipse(mouseX, mouseY, 10, 10);

      if (mousePressed == true) {
        gameS = 3;
      }
    }

    if (dist(mouseX, mouseY, bX3, bY3) < (dia1/3)) {
      ellipse(mouseX, mouseY, 10, 10);

      if (mousePressed == true) {
        gameS = 4;
      }
    }
  }

  if (gameS == 2) {
    background(255, 0, 0);
  }

  if (gameS == 3) {
    options();
  }
  if (gameS == 4) {
    exit();
  }
}

void options() {
  background(100);

  text("FPS" + " " + frameRate, 80, 740);

  rect(x1, y1, dia11, dia11);
  text("MEH", 356, 450);

  rect(x2, y2, dia22, dia22);
  text("BACK", 356, 570);

  dia11 += sin(x/4)* 0.5; //heartbeat11
  dia22 += sin(x/4)* 0.5; //heartbeat22
  x--;

  if (dist(mouseX, mouseY, x1, y1) < (dia11/2)) {
    ellipse(mouseX, mouseY, 10, 10);

    if (mousePressed == true) {
      background(random(255));
    }
  }

  if (dist(mouseX, mouseY, x2, y2) < (dia22/2)) {
    ellipse(mouseX, mouseY, 10, 10);

    if (mousePressed == true) {
      gameS = 1;
    }
  }
}
