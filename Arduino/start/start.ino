bool run_on = false; // is the run in progress?
short int start_pin = 2;  // the number of the pushbutton pin
short int input_start = 0; // toggle what input is recognized as start

void setup()
{
  Serial.begin(9600);
  pinMode(start_pin, INPUT_PULLUP);
}

void loop()
{
  Serial.println(digitalRead(start_pin));
  delay(100);
}