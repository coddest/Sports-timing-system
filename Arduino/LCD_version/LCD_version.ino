#include <LiquidCrystal.h>

// initialize the library by associating any needed LCD interface pin
// with the arduino pin number it is connected to
const int rs = 12, en = 11, d4 = 4, d5 = 5, d6 = 6, d7 = 7;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

bool runOn = false;
long int start_time = 1;
int minRunLength = 1000; // delay time
short int photoPin = 2; // pin to which photocell is connected
short int buttonPin = 3; // pin to which button is connected
short int input_start = 0; // toggle what input is recognized as start

void setup() {
  pinMode(photoPin, INPUT_PULLUP);
  pinMode(buttonPin, INPUT_PULLUP);
  Serial.begin(9600);
  lcd.begin(16, 2);
  lcd.setCursor(4, 0);
  lcd.print("Welcome!");
}

void loop(){
  Serial.println(digitalRead(buttonPin));

  if(digitalRead(photoPin)==input_start && runOn==false){
     lcd.clear();
     lcd.setCursor(0, 0);
    start_time = millis();
    Serial.println("Run started!");
    lcd.print("Run in progress!");
    unsigned long result_time = minRunLength;
    runOn = true;
    delay(minRunLength);
    
    while(digitalRead(photoPin)!=input_start){
      result_time = millis()-start_time;
       lcd.setCursor(0, 1);
       lcd.print(float(result_time)/1000);
       lcd.print("s");
      Serial.println(result_time);
    }
    
    runOn = false;
    Serial.println(result_time);
     lcd.clear();
     lcd.setCursor(0, 0);
     lcd.print(float(result_time)/1000);
     lcd.print("s");
    delay(minRunLength);
  }
}
