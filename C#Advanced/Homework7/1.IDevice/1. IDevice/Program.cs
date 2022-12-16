using _1._IDevice;

var phone = new Phone();
phone.Processor = "intel";
phone.Ram = "1";

var computer = new Computer();
computer.Processor = "amd";
computer.Ram = "2";

ShowInformation(phone);
ShowInformation(computer);  

static void ShowInformation(IDevice device)
{
    Console.WriteLine($"{device.Ram} {device.Processor}");
}