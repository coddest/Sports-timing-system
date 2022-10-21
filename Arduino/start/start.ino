bool run_on = false; // is the run in progress?
short int start_pin = 2;  // the number of the pushbutton pin
short int input_start = 0; // toggle what input is recognized as start

void setup() {
  pinMode(start_pin, INPUT);
}

void loop() {
  if(digitalRead(start_pin)==input_start && run_on==false){
}