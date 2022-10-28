#include <LiquidCrystal.h>

// initialize the library by associating any needed LCD interface
// pin with the arduino pin number it is connected to
const int rs = 12, en = 11, d4 = 4, d5 = 5, d6 = 6, d7 = 7;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

// set up variables:
bool run_on = false; // is the run in progress?
long int start_time = 1; // start time of run
long int result_time = 0; // time of run
long int prev_time = 0; // previous time
int min_run_length = 1000; // delay time
short int photo_pin = 2; // pin to which photocell is connected
short int input_start = 0; // toggle what input is recognized as start

// functions declarations
void print_ln_lcd(String message, int col=0, int row=0, bool clear=false);
String ms_to_print(long int ms);

void setup() {
  pinMode(photo_pin, INPUT_PULLUP);
  Serial.begin(9600);
  lcd.begin(16, 2);
  print_ln_lcd("Welcome!", 4, 0, true);
}

void loop(){

  if(digitalRead(photo_pin)==input_start && run_on==false){
    start_time = millis(); // save the time when the run started
    Serial.println("run-started"); // send message to serial monitor that run has started
    result_time = min_run_length; // set the result time to the minimum run length
    run_on = true; // set the run_on flag to true

    if(prev_time != 0)
    print_ln_lcd(ms_to_print(prev_time), 0, 0, true); // print prev time on LCD
    delay(min_run_length);
    
    while(digitalRead(photo_pin)!=input_start){
      result_time = millis()-start_time;
      print_ln_lcd(ms_to_print(result_time), 0, 1); // update time on LCD
    }
    
    run_on = false;
    prev_time = result_time; // save the result time as the previous time for LCD display
    Serial.println(result_time);
    delay(min_run_length);
  }

}

// functions definitions
void print_ln_lcd(String message, int col=0, int row=0, bool clear=false){ // print message to LCD
  if(clear){
    lcd.clear();
  }
  lcd.setCursor(col, row);
  lcd.print(message);
}

String ms_to_print(long int ms){ // convert milliseconds to string
  String result = "";
  int sec = ms/1000;
  int min = sec/60;
  int hr = min/60;
  if(hr>0){
    result += String(hr)+":";
  }
  if(min>0){
    if(min%60<10){
      result += "0";
    }
    result += String(min%60)+":";
  }
  if(sec>0){
    if(sec%60<10){
      result += "0";
    }
    result += String(sec%60)+".";
  }
  if(ms>0){
    result += String(ms%1000);
  }
  return result;
}