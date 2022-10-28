#include <SoftwareSerial.h>

// wireless communication setup
SoftwareSerial HC12(9, 8); // HC-12 TX Pin, HC-12 RX Pin

bool run_on = false; // is the run in progress?
short int start_pin = 2;  // the number of the pushbutton pin
short int input_start = 0; // toggle what input is recognized as start

void setup()
{
  Serial.begin(9600); // serial port to computer
  HC12.begin(9600); // serial port to HC-12
  
  pinMode(start_pin, INPUT_PULLUP);
}

void loop()
{
  if(digitalRead(start_pin)==input_start)
  {
    HC12.write("run-started"); // send message over HC-12 that run has started
    Serial.println("run-started"); // for debugging
    run_on = true;
    delay(1000);
  }
}