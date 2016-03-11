using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class CarPark {
		//vars
        string name;
        int bays;
        public List<Vehicle> vehicles;
        
        public CarPark(string name="Unnamed", int bays=10) { //default constructor
            this.name = name;
            this.bays = bays;
            vehicles = new List<Vehicle>();
			Console.Write("A new carpark called " + name + " has been created with " + bays + " bays\n");
        }

        string getName() {
            return name;
		}

		public bool addVehicle(Vehicle newVehicle) { //Park vehicle
			if (vehicles.Count() == bays) { //
				Console.Write("This carpark is full!  Cannot add more vehicles to this carpark!\n");
				return false;
			}
			vehicles.Add(newVehicle);
			Console.Write("A " + newVehicle.getWeight() + "kg " + newVehicle.getWriteableType() + " has parked in " + name + ".  Fee: $" + newVehicle.getFee() + "\n");
			return true;
		}

		public void printVehicles() {
			if (vehicles.Count() == 0) {
				Console.Write("No vehicles in carpark!\n");
				return;
			}
			Console.Write("\n{0,-12}{1,10}{2,10}\n", "Type","Weight","Owing");
			foreach (Vehicle i in vehicles) {
				string outstanding;
				if (i.getOutstanding() == 0)
					outstanding = "Paid";
				else
					outstanding = "$" + i.getOutstanding();
				Console.Write("{0,-12}{1,10}{2,10}\n", 
					i.getWriteableType(), 
					i.getWeight() + "kg",
					outstanding
					);
			}
			Console.Write("\n");
		}

		public bool removeVehicle(int index) {
			if (vehicles[index].getOutstanding() > 0) {
				Console.Write("Vehicle cannot leave with outstanding fees\n");
				return false;
			}
			Console.Write(vehicles[index].getType() + " has left the carpark\n");
			vehicles.RemoveAt(index);
			return true;
		}

    }
}
