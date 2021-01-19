class click {
  float xpos;
  float ypos = 50;
  float wide;
  float high;
  float colour;

  click() {
    wide = 50;
    high = 50;
    colour = 0;
  }

  void display() { //<>//
    fill(colour);
    image(goodC, xpos, ypos, wide, high);
  }

  void isclicked() {
    if (mousePressed) {
      if (mouseX >= xpos && mouseX <= xpos + 50) {
        if (mouseY >= ypos && mouseY <= ypos + 50) {
          counter = counter + 1;
          xpos = random(100, 600);
          ypos = random(50, 800);
        }
      }
    }
  }
  void gui() {
    text("Score: " + counter, 10, 790);
    textSize(35);
    line(0, 700, 800, 700);
  }
} //<>//
