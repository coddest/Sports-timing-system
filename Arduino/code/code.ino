bool runOn = false;
long int start_time = 0;
int minRunLength = 1000; // delay time
short int photoPin = 10; // pin to which photocell is connected

void setup() {
  pinMode(photoPin, INPUT_PULLUP);
  Serial.begin(9600);
}

void loop(){
  if(digitalRead(photoPin)==1 && runOn==false){
    start_time = millis();
    Serial.println("run_start");
    int result_time = 1;
    runOn = true;
    delay(minRunLength);
    
    while(digitalRead(photoPin)!=1){
      result_time = millis()-start_time;
      Serial.println(result_time);
    }
    
    runOn = false;
    Serial.println("run_end");
    delay(minRunLength);
  }
}
