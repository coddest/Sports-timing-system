#include <LiquidCrystal.h>

// initialize the library by associating any needed LCD interface
// pin with the arduino pin number it is connected to
const int rs = 12, en = 11, d4 = 4, d5 = 5, d6 = 6, d7 = 7;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

// set up variables:
bool run_on = false; // is the run in progress?
long int start_time = 1; // start time of run
long int result_time = 0; // time of run
int min_run_length = 1000; // delay time
short int photo_pin = 2; // pin to which photocell is connected
short int input_start = 0; // toggle what input is recognized as start

// functions declarations
void print_to_lcd(String message, int col=0, int row=0, bool clear=true);

void setup() {
  pinMode(photo_pin, INPUT_PULLUP);
  Serial.begin(9600);
  lcd.begin(16, 2);
  print_to_lcd("Welcome!", 4, 0);
}

void loop(){

  if(digitalRead(photo_pin)==input_start && run_on==false){
    start_time = millis(); // save the time when the run started
    Serial.println("Run started!"); // send message to serial monitor that run has started
    print_to_lcd("Run in progress!", 0, 0);
    result_time = min_run_length; // set the result time to the minimum run length
    run_on = true; // set the run_on flag to true
    delay(min_run_length);
    
    while(digitalRead(photo_pin)!=input_start){
      result_time = millis()-start_time;
      print_to_lcd(""+String(result_time/1000.0)+" s", 0, 1, false); // update time on LCD
    }
    
    run_on = false;
    Serial.println(result_time);
    print_to_lcd(String(result_time/1000.0)+"s", 0, 0); // print result to LCD
    delay(min_run_length);
  }
}

// functions definitions
void print_to_lcd(String message, int col=0, int row=0, bool clear=true){ // print message to LCD
  if(clear){
    lcd.clear();
  }
  lcd.setCursor(col, row);
  lcd.print(message);
}