bool runOn = false;
long int start_time = 1;
int minRunLength = 1000; // delay time
short int photoPin = 11; // pin to which photocell is connected
short int input_start = 0; // toggle what input is recognized as start

void setup() {
  pinMode(photoPin, INPUT_PULLUP);
  Serial.begin(9600);
}

void loop(){
  if(digitalRead(photoPin)==input_start && runOn==false){
    start_time = millis();
    Serial.println("Run started!");
    int result_time = minRunLength;
    runOn = true;
    delay(minRunLength);
    
    while(digitalRead(photoPin)!=input_start){
      result_time = millis()-start_time;
      // Serial.println(result_time);
    }
    
    runOn = false;
    Serial.println(result_time);
    delay(minRunLength);
  }
}
