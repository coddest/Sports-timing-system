bool runOn = false;
long int startTime = 0;
int minRunLength = 1000; // delay time
short int photoPin = 10; // pin to which photocell is connected

void setup() {
  pinMode(photoPin, INPUT_PULLUP);
  Serial.begin(9600);
}

void loop(){
  if(digitalRead(photoPin)==1 && runOn==false){
    startTime = millis();
    double resultTime = 0;
    runOn = true;
    Serial.println("Run started!");
    delay(minRunLength);
    while(digitalRead(photoPin)!=1){
      resultTime = (double(millis()-startTime))/1000;
      String message = "Run in progress!("+String(resultTime)+"s)";
      Serial.println(message);
    }
    Serial.println(resultTime);
    delay(minRunLength);
  }
}
