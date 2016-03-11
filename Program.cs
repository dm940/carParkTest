using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
			CarPark test = new CarPark("Test carpark", 10);
			test.addVehicle(new Vehicle(10,Type.StandardCar));
			test.addVehicle(new Vehicle(10, Type.LuxuryCar));
			test.addVehicle(new Vehicle(10, Type.Motorbike));
			test.addVehicle(new Vehicle(101, Type.Truck));
			test.printVehicles();
			test.vehicles[1].payFee();
			test.printVehicles();
			test.removeVehicle(1);
			test.printVehicles();
			foreach (Vehicle i in test.vehicles) {
				i.payFee();
			}
			while (test.vehicles.Count() > 0) {
				test.removeVehicle(0);
			}
			test.printVehicles();
			test.addVehicle(new Vehicle(10, Type.Motorbike));
			test.removeVehicle(0);
			test.printVehicles();
			Console.ReadKey();
        }
    }
}
