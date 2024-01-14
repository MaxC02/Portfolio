  import processing.pdf.*;                           // Import library for PDF export

PFont f;                                             // Font variable

PImage blackspeech;                                  // Image varibale

int i;                                               // Iterator number variable for loops
float arcLength;                                     // Variable to control rotation on letters
char currentChar;                                    // Variable storing current letter
float w;                                             // Variable for storing letter width
float theta;                                         // Variable to store angles

float lineStart = 5000;                              // Start y point for middle line
float lineEnd = 1800;                                // End y point for middle line
float lineCurrent = lineStart;                       // Initialise middle line current position and sets to line start
int lineR = 255;                                     // Middle line RGB red value
int lineG = 255;                                     // Middle line RGB green value
int lineB = 255;                                     // Middle line RGB blue value

//Frodo data input
float frodoStart = -64;                              // Start angle for Frodo
float frodoEnd = 101;                                // End angle for Frodo
float frodoCurrent = frodoStart;                     // Initialise Frodo angle current value and sets to Frodo start
int frodoR = 200;                                    // Frodo arc RGB red value
int frodoG = 48;                                     // Frodo arc RGB green value
int frodoB = 35;                                     // Frodo arc RGB blue value
String frodo = "Frodo Baggins";                      // String to store full character name for text display
float frodoRad = 3160;                               // Radius of Frodo arc

//Sam data input                                     //    Repeat for all characters
float samStart = -53;                                //              ||
float samEnd = 277;                                  //              ||
float samCurrent = samStart;                         //              ||
int samR = 200;                                      //              ||
int samG = 111;                                      //              \/
int samB =29;
String sam = "Samwise Gamgee";
float samRad = 2960;

//Aragorn data input
float aragornStart = 14;
float aragornEnd = 355;
float aragornCurrent = aragornStart;
int aragornR = 0;
int aragornG = 57;
int aragornB = 117;
String aragorn = "Aragorn";
float aragornRad = 2760;

//Pippin data input
float pipStart = -60;
float pipEnd = 256;
float pipCurrent = pipStart;
int pipR = 135;
int pipG = 154;
int pipB = 44;
String pip = "Peregrin Took";
float pipRad = 2560;

//Merry data input
float merryStart = -28;
float merryEnd = 284;
float merryCurrent = merryStart;
int merryR = 238;
int merryG = 208;
int merryB = 0;
String merry = "Meriadoc Brandybuck";
float merryRad = 2360;


//Gimli data input
float gimliStart = 52;
float gimliEnd = 394;
float gimliCurrent = gimliStart;
int gimliR = 120;
int gimliG = 42;
int gimliB = 29;
String gimli = "Gimli";
float gimliRad = 2160;

//Theoden data input
float theodenStart = -64;
float theodenEnd = 230;
float theodenCurrent = theodenStart;
int theodenR = 203;
int theodenG = 152;
int theodenB = 0;
String theoden = "Théoden";
float theodenRad = 1960;

//Boromir data input
float boromirStart = -62;
float boromirEnd = 43;
float boromirCurrent = boromirStart;
int boromirR = 91;
int boromirG = 16;
int boromirB = 26;
String boromir = "Boromir";
float boromirRad = 1760;

//Bilbo data input
float bilboStart = 68;
float bilboEnd = 382;
float bilboCurrent = bilboStart;
int bilboR = 161;
int bilboG = 83;
int bilboB = 81;
String bilbo = "Bilbo Baggins";
float bilboRad = 1560;

//Faramir data input
float faramirStart = -25;
float faramirEnd = 299;
float faramirCurrent = faramirStart;
int faramirR = 92;
int faramirG = 105;
int faramirB = 68;
String faramir = "Faramir";
float faramirRad = 1360;

//Eomer data input
float eomerStart = 5;
float eomerEnd = 329;
float eomerCurrent = eomerStart;
int eomerR = 176;
int eomerG = 139;
int eomerB = 103;
String eomer = "Éomer";
float eomerRad = 1160;

//Denethor data input
float denethorStart = -38;
float denethorEnd = 199;
float denethorCurrent = denethorStart;
int denethorR = 81;
int denethorG = 81;
int denethorB = 81;
String denethor = "Denethor";
float denethorRad = 960;

void setup() {                                                // Begin setup
  size(10000, 10000, PDF, "LOTRLifespan.pdf");                // Set canvas size and PDF output file

  f = createFont("Apple-Chancery", 176);                      // Assign font variable f to font style and set font size
  textFont(f);                                                // Set default font to variable f
  textAlign(CENTER);                                          // Aligns text to centre
  
  blackspeech = loadImage("blackspeech.png");                 // Loads black speech image from folder
    
  strokeWeight(120);                                          // Sets stroke size
  
}

void draw() {                                                 // Begin draw
  
  background(0);                                              // Set background to black
  
  //Ring image
  image(blackspeech, 1000, 1000, width * 0.8, height * 0.8);  // Paste black speech image and set size and offset
  
  //Frodo
  if (frodoCurrent < frodoEnd) {                              // This will execute every draw cycle while the current Frodo arc angle is less than the end arc angle value
                                                              // so that it will iteratively draw the arc until it reaches the end point
    stroke(frodoR, frodoG, frodoB);                           // Sets the stroke colour to the assigned colour for Frodo
    noFill();                                                 // Disables fill
    arc(5000, 5000, 6400, 6400, radians(frodoStart), radians(frodoCurrent), OPEN);        // Begin drawing arc at frodoStart and finish at frodoCurrent
    frodoCurrent++;                                           // Increments the frodoCurrent value for the next iteration
    
    stroke(255, 255, 255);                                    // Sets stroke colour to white
    fill(255, 255, 255);                                      // Enables fill and sets fill colour to white
    ellipse(5000 + cos(radians(frodoCurrent)) * (frodoRad + 40), 5000 + (sin(radians(frodoCurrent)) * (frodoRad + 40)), 70, 70);    // Creates an ellipse at the end of the current position of the arc
    
  }
  
  if (frodoCurrent == frodoEnd) {                             // This will execute once the frodoCurrent value has reached the frodoEnd value/when the arc has reached the desired point
    
    stroke(frodoR, frodoG, frodoB);                           // Sets stroke colour to the assigned colour for Frodo
    noFill();
    arc(5000, 5000, 6400, 6400, radians(frodoStart), radians(frodoEnd), OPEN);      // Draws the complete arc from frodoStart to frodoEnd/will remain unchanged through future iterations while frodoCurrent is equal to frodoEnd
    
    stroke(255, 255, 255);                                    // Sets stroke colour to white
    fill(255, 255, 255);                                      // Enables fill and sets fill colour to white
    ellipse(5000 + cos(radians(frodoEnd)) * (frodoRad + 40), 5000 + (sin(radians(frodoEnd)) * (frodoRad + 40)), 70, 70);            // Creates an ellipse at the end of the arc
    
    //FrodoText
  noFill();                                                   // Disables fill
  stroke(frodoR, frodoG, frodoB);                             // Sets the stroke colour to the assigned colour for Frodo
  
  arcLength = 0;                                              // Resets arcLength to zero

  for (i = 0; i < frodo.length (); i ++ ) {                   // Loop to iterate through the length of the String text

    currentChar = frodo.charAt(i);                            // Sets the current letter to the iterator i value
    w = textWidth(currentChar);                               // Sets the letter width variable to the current letter width
    arcLength += w/2;                                         // Adds half the letter width to the arcLength

    theta = PI * 1.02 + arcLength / frodoRad;                 // Sets the position of the text to the appropriate position on the circumference of the arc 

    pushMatrix();                                             // Pushes the current transformation matrix to the matrix stack

    translate(frodoRad*cos(theta) + 5000, frodoRad*sin(theta) + 5000);   // Places the text at the correct offset
    rotate(theta + PI/2);                                     // Rotates the text according to its position on the circumference
  
    fill(frodoR, frodoG, frodoB);                             // Sets the text colour to the assigned colour for Frodo
    translate(frodoRad, frodoRad);                            // Sets the text to the height and width of the radius to the correct position on the circumference
    rotate(89.6);                                             // Fine tuning rotation
    text(currentChar, 0, 0);                                  // Prints text
    popMatrix();                                              // Pops the current transformation matrix off the matrix stack

    arcLength += w/2;                                         // Adds half the letter width to the arcLength once more
                                                              // Will repeat for all letters of the string
    
  }
    
    
  }
  
  //Pippin                                                                                                                                //    Repeat for all characters
  if (pipCurrent < pipEnd) {                                                                                                              //              ||
                                                                                                                                          //              ||
    stroke(pipR, pipG, pipB);                                                                                                             //              ||
    noFill();                                                                                                                             //              ||
    arc(5000, 5000, 5200, 5200, radians(pipStart), radians(pipCurrent), OPEN);      // Subsequent characters have a smaller arcs          //              \/
    pipCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(pipCurrent)) * (pipRad + 40), 5000 + (sin(radians(pipCurrent)) * (pipRad + 40)), 70, 70);
    
  }
  
  if (pipCurrent == pipEnd) {
    
    stroke(pipR, pipG, pipB);
    noFill();
    arc(5000, 5000, 5200, 5200, radians(pipStart), radians(pipEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(pipEnd)) * (pipRad + 40), 5000 + (sin(radians(pipEnd)) * (pipRad + 40)), 70, 70);
    
    //PippinText
  noFill();
  stroke(pipR, pipG, pipB);
  
  arcLength = 0;

  for (i = 0; i < pip.length (); i ++ ) {

    currentChar = pip.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.02 + arcLength / pipRad;

    pushMatrix();

    translate(pipRad*cos(theta) + 5000, pipRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(pipR, pipG, pipB);
    translate(pipRad, pipRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  //Theoden
  if (theodenCurrent < theodenEnd) {
    
    stroke(theodenR, theodenG, theodenB);
    noFill();
    arc(5000, 5000, 4000, 4000, radians(theodenStart), radians(theodenCurrent), OPEN);
    theodenCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(theodenCurrent)) * (theodenRad + 40), 5000 + (sin(radians(theodenCurrent)) * (theodenRad + 40)), 70, 70);
    
  }
  
  if (theodenCurrent == theodenEnd) {
    
    stroke(theodenR, theodenG, theodenB);
    noFill();
    arc(5000, 5000, 4000, 4000, radians(theodenStart), radians(theodenEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(theodenEnd)) * (theodenRad + 40), 5000 + (sin(radians(theodenEnd)) * (theodenRad + 40)), 70, 70);
    
    //TheodenText
  noFill();
  stroke(theodenR, theodenG, theodenB);
  
  arcLength = 0;

  for (i = 0; i < theoden.length (); i ++ ) {

    currentChar = theoden.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.025 + arcLength / theodenRad;

    pushMatrix();

    translate(theodenRad*cos(theta) + 5000, theodenRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(theodenR, theodenG, theodenB);
    translate(theodenRad, theodenRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  //Boromir
  if (boromirCurrent < boromirEnd) {
    
    stroke(boromirR, boromirG, boromirB);
    noFill();
    arc(5000, 5000, 3600, 3600, radians(boromirStart), radians(boromirCurrent), OPEN);
    boromirCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(boromirCurrent)) * (boromirRad + 40), 5000 + (sin(radians(boromirCurrent)) * (boromirRad + 40)), 70, 70);
    
  }
  
  if (boromirCurrent == boromirEnd) {
    
    stroke(boromirR, boromirG, boromirB);
    noFill();
    arc(5000, 5000, 3600, 3600, radians(boromirStart), radians(boromirEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(boromirEnd)) * (boromirRad + 40), 5000 + (sin(radians(boromirEnd)) * (boromirRad + 40)), 70, 70);
    
    //BoromirText
  noFill();
  stroke(boromirR, boromirG, boromirB);

  arcLength = 0;

  for (i = 0; i < boromir.length (); i ++ ) {

    currentChar = boromir.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.025 + arcLength / boromirRad;

    pushMatrix();

    translate(boromirRad*cos(theta) + 5000, boromirRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(boromirR, boromirG, boromirB);
    translate(boromirRad, boromirRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  //Denethor
  if (denethorCurrent < denethorEnd) {
    
    stroke(denethorR, denethorG, denethorB);
    noFill();
    arc(5000, 5000, 2000, 2000, radians(denethorStart), radians(denethorCurrent), OPEN);
    denethorCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(denethorCurrent)) * (denethorRad + 4), 5000 + (sin(radians(denethorCurrent)) * (denethorRad + 40)), 70, 70);
    
  }
  
  if (denethorCurrent == denethorEnd) {
    
    stroke(denethorR, denethorG, denethorB);
    noFill();
    arc(5000, 5000, 2000, 2000, radians(denethorStart), radians(denethorEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(denethorEnd)) * (denethorRad + 40), 5000 + (sin(radians(denethorEnd)) * (denethorRad + 40)), 70, 70);
    
    //DenethorText
  noFill();
  stroke(denethorR, denethorG, denethorB);

  arcLength = 0;

  for (i = 0; i < denethor.length (); i ++ ) {

    currentChar = denethor.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.03 + arcLength / denethorRad;

    pushMatrix();

    translate(denethorRad*cos(theta) + 5000, denethorRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(denethorR, denethorG, denethorB);
    translate(denethorRad, denethorRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  
  //Line
  if (lineCurrent > lineEnd) {
    
    stroke(lineR, lineG, lineB);
    line(5000, lineStart, 5000, lineCurrent);
    lineCurrent = lineCurrent - 10;
    
  }
  
  if (lineCurrent == lineEnd) {
    
    stroke(lineR, lineG, lineB);
    line(5000, lineStart, 5000, lineEnd);
    
  }
  
  
  //Sam
  if (samCurrent < samEnd) {
    
    stroke(samR, samG, samB);
    noFill();
    arc(5000, 5000, 6000, 6000, radians(samStart), radians(samCurrent), OPEN);
    samCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(samCurrent)) * (samRad + 40), 5000 + (sin(radians(samCurrent)) * (samRad + 40)), 70, 70);
    
  }
  
  if (samCurrent == samEnd) {
    
    stroke(samR, samG, samB);
    noFill();
    arc(5000, 5000, 6000, 6000, radians(samStart), radians(samEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(samEnd)) * (samRad + 40), 5000 + (sin(radians(samEnd)) * (samRad + 40)), 70, 70);
    
    //SamText
  noFill();
  stroke(samR, samG, samB);

  arcLength = 0;

  for (i = 0; i < sam.length (); i ++ ) {

    currentChar = sam.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.058 + arcLength / samRad;

    pushMatrix();

    translate(samRad*cos(theta) + 5000, samRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(samR, samG, samB);
    translate(samRad, samRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  //Aragorn
  if (aragornCurrent < aragornEnd) {
    
    stroke(aragornR, aragornG, aragornB);
    noFill();
    arc(5000, 5000, 5600, 5600, radians(aragornStart), radians(aragornCurrent), OPEN);
    aragornCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(aragornCurrent)) * (aragornRad + 40), 5000 + (sin(radians(aragornCurrent)) * (aragornRad + 40)), 70, 70);
    
  }
  
  if (aragornCurrent == aragornEnd) {
    
    stroke(aragornR, aragornG, aragornB);
    noFill();
    arc(5000, 5000, 5600, 5600, radians(aragornStart), radians(aragornEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(aragornEnd)) * (aragornRad + 40), 5000 + (sin(radians(aragornEnd)) * (aragornRad + 40)), 70, 70);
    
    //AragornText
  noFill();
  stroke(aragornR, aragornG, aragornB);

  arcLength = 0;

  for (i = 0; i < aragorn.length (); i ++ ) {

    currentChar = aragorn.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.4925 + arcLength / aragornRad;

    pushMatrix();

    translate(aragornRad*cos(theta) + 5000, aragornRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(aragornR, aragornG, aragornB);
    translate(aragornRad, aragornRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  //Merry
  if (merryCurrent < merryEnd) {
    
    stroke(merryR, merryG, merryB);
    noFill();
    arc(5000, 5000, 4800, 4800, radians(merryStart), radians(merryCurrent), OPEN);
    merryCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(merryCurrent)) * (merryRad + 40), 5000 + (sin(radians(merryCurrent)) * (merryRad + 40)), 70, 70);
    
  }
  
  if (merryCurrent == merryEnd) {
    
    stroke(merryR, merryG, merryB);
    noFill();
    arc(5000, 5000, 4800, 4800, radians(merryStart), radians(merryEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(merryEnd)) * (merryRad + 40), 5000 + (sin(radians(merryEnd)) * (merryRad + 40)), 70, 70);
    
    //MerryText
  noFill();
  stroke(merryR, merryG, merryB);
  
  arcLength = 0;

  for (i = 0; i < merry.length (); i ++ ) {

    currentChar = merry.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.1 + arcLength / merryRad;

    pushMatrix();

    translate(merryRad*cos(theta) + 5000, merryRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(merryR, merryG, merryB);
    translate(merryRad, merryRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  //Gimli
  if (gimliCurrent < gimliEnd) {
    
    stroke(gimliR, gimliG, gimliB);
    noFill();
    arc(5000, 5000, 4400, 4400, radians(gimliStart), radians(gimliCurrent), OPEN);
    gimliCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(gimliCurrent)) * (gimliRad + 40), 5000 + (sin(radians(gimliCurrent)) * (gimliRad + 40)), 70, 70);
    
  }
  
  if (gimliCurrent == gimliEnd) {
    
    stroke(gimliR, gimliG, gimliB);
    noFill();
    arc(5000, 5000, 4400, 4400, radians(gimliStart), radians(gimliEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(gimliEnd)) * (gimliRad + 40), 5000 + (sin(radians(gimliEnd)) * (gimliRad + 40)), 70, 70);
    
    //GimliText
  noFill();
  stroke(gimliR, gimliG, gimliB);

  arcLength = 0;

  for (i = 0; i < gimli.length (); i ++ ) {

    currentChar = gimli.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.71 + arcLength / gimliRad;

    pushMatrix();

    translate(gimliRad*cos(theta) + 5000, gimliRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(gimliR, gimliG, gimliB);
    translate(gimliRad, gimliRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  //Bilbo
  if (bilboCurrent < bilboEnd) {
    
    stroke(bilboR, bilboG, bilboB);
    noFill();
    arc(5000, 5000, 3200, 3200, radians(bilboStart), radians(bilboCurrent), OPEN);
    bilboCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(bilboCurrent)) * (bilboRad + 40), 5000 + (sin(radians(bilboCurrent)) * (bilboRad + 40)), 70, 70);
    
  }
  
  if (bilboCurrent == bilboEnd) {
    
    stroke(bilboR, bilboG, bilboB);
    noFill();
    arc(5000, 5000, 3200, 3200, radians(bilboStart), radians(bilboEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(bilboEnd)) * (bilboRad + 40), 5000 + (sin(radians(bilboEnd)) * (bilboRad + 40)), 70, 70);
    
    //BilboText
  noFill();
  stroke(bilboR, bilboG, bilboB);

  arcLength = 0;

  for (i = 0; i < bilbo.length (); i ++ ) {

    currentChar = bilbo.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.643 + arcLength / bilboRad;

    pushMatrix();

    translate(bilboRad*cos(theta) + 5000, bilboRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(bilboR, bilboG, bilboB);
    translate(bilboRad, bilboRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  //Faramir
  if (faramirCurrent < faramirEnd) {
    
    stroke(faramirR, faramirG, faramirB);
    noFill();
    arc(5000, 5000, 2800, 2800, radians(faramirStart), radians(faramirCurrent), OPEN);
    faramirCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(faramirCurrent)) * (faramirRad + 40), 5000 + (sin(radians(faramirCurrent)) * (faramirRad + 40)), 70, 70);
    
  }
  
  if (faramirCurrent == faramirEnd) {
    
    stroke(faramirR, faramirG, faramirB);
    noFill();
    arc(5000, 5000, 2800, 2800, radians(faramirStart), radians(faramirEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(faramirEnd)) * (faramirRad + 40), 5000 + (sin(radians(faramirEnd)) * (faramirRad + 40)), 70, 70);
    
    //FaramirText
  noFill();
  stroke(faramirR, faramirG, faramirB);

  arcLength = 0;

  for (i = 0; i < faramir.length (); i ++ ) {

    currentChar = faramir.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.185 + arcLength / faramirRad;

    pushMatrix();

    translate(faramirRad*cos(theta) + 5000, faramirRad*sin(theta) + 5000); 
    rotate(theta + PI/2); 

    fill(faramirR, faramirG, faramirB);
    translate(faramirRad, faramirRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();
    
    arcLength += w/2;
    
  }
    
  }
  
  //Eomer
  if (eomerCurrent < eomerEnd) {
    
    stroke(eomerR, eomerG, eomerB);
    noFill();
    arc(5000, 5000, 2400, 2400, radians(eomerStart), radians(eomerCurrent), OPEN);
    eomerCurrent++;
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(eomerCurrent)) * (eomerRad + 40), 5000 + (sin(radians(eomerCurrent)) * (eomerRad + 40)), 70, 70);
    
  }
  
  if (eomerCurrent == eomerEnd) {
    
    stroke(eomerR, eomerG, eomerB);
    noFill();
    arc(5000, 5000, 2400, 2400, radians(eomerStart), radians(eomerEnd), OPEN);
    
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(5000 + cos(radians(eomerEnd)) * (eomerRad + 40), 5000 + (sin(radians(eomerEnd)) * (eomerRad + 40)), 70, 70);
    
    //EomerText
  noFill();
  stroke(eomerR, eomerG, eomerB);

  arcLength = 0;

  for (i = 0; i < eomer.length (); i ++ ) {

    currentChar = eomer.charAt(i);
    w = textWidth(currentChar); 
    arcLength += w/2;

    theta = PI*1.365 + arcLength / eomerRad;

    pushMatrix();

    translate(eomerRad*cos(theta) + 5000, eomerRad*sin(theta) + 5000); 
    // Rotate the box (rotation is offset by 90 degrees)
    rotate(theta + PI/2); 

    fill(eomerR, eomerG, eomerB);
    translate(eomerRad, eomerRad);
    rotate(89.6);
    text(currentChar, 0, 0);
    popMatrix();

    arcLength += w/2;
    
  }
    
  }
  
  if (lineCurrent == lineEnd && frodoCurrent == frodoEnd && samCurrent == samEnd && aragornCurrent == aragornEnd && pipCurrent == pipEnd &&
  merryCurrent == merryEnd && gimliCurrent == gimliEnd && theodenCurrent == theodenEnd && boromirCurrent == boromirEnd && bilboCurrent == bilboEnd &&        //If all shapes are finished drawing, exit and save PDF
  faramirCurrent == faramirEnd && eomerCurrent == eomerEnd && denethorCurrent == denethorEnd) {
    
    exit();                                                                                       // Stop process
    
  }
  

}
