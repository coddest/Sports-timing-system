// variables declarations:
bool run_on = false; // is the run in progress?
long int start_time = 1; // start time of run
long int result_time = 0; // time of run
int min_run_length = 1000; // delay time
short int photo_pin = 2; // pin to which photocell is connected
short int input_start = 0; // toggle what input is recognized as start

void setup() {
  pinMode(photo_pin, INPUT_PULLUP);
  Serial.begin(9600);
}

void loop(){
  if(digitalRead(photo_pin)==input_start && run_on==false){
    start_time = millis(); // save the time when the run started
    Serial.println("Run started!");
    result_time = min_run_length; // set the result time to the minimum run length
    run_on = true; // set the run_on flag to true
    delay(min_run_length);
    
    while(digitalRead(photo_pin)!=input_start){
      result_time = millis()-start_time; // calculate the result time
      Serial.println(result_time); // print the result time
    }
    
    run_on = false; // set the run_on flag to false
    Serial.println(result_time); // print the result time
    delay(min_run_length); // delay to prevent multiple runs
  }
}
