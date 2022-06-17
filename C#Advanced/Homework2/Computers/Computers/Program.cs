using Computers;

Computer computer1 = new Computer();

double ram = 6;
string processor = "intel";
string videoCard = "GeForce";
bool wifiAdapter = true;

Computer computer2 = new Computer(ram, processor, videoCard);
Computer computer3 = new Computer(processor, videoCard, wifiAdapter);
Computer computer4 = new Computer(ram, processor, videoCard, wifiAdapter);