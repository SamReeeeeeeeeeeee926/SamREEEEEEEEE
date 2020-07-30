class enemy {

  float x, y, speed;
  color c;
  float dia = 30;
 
  enemy() {
    x=random(width);
    y=random(-300, 0);
    speed=random(5, 10);
    c=color(255, 255, 255);
  }

  void update() {
    y += speed;

    if (dist(mouseX, mouseY, x, y) < dia/2) {
      gameH --;
      healthDown.play();
      healthDown.rewind();
    }
    
      if(level == 2){
       
        speed = random(8,10);
      }
       if(level == 3){
        speed = random(10, 15);
      }
      
      if(level == 4){
       
        speed = random(15,20);
      }
       if(level == 5){
        speed = random(25, 30);
      }
  }

  void display() {
    fill(c);
    noStroke();
    image(badC, x, y, dia, dia);
    update();
  }
}
