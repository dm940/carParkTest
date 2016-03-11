using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
	enum Type { StandardCar, LuxuryCar, Motorbike, Truck };
	class Vehicle {
		int weight; //assuming no decimals
		Type type;
		double fee;
		double paid;

		public Vehicle(int weight = 10, Type type = Type.StandardCar) {
			this.weight = weight;
			this.type = type;
			paid = 0;
			this.fee = calcFee();
		}

		public double payFee() { //pay total fee
			double outstanding = fee - paid;
			paid = fee;
			printPaid(outstanding);
			return outstanding;
		}

		void printPaid(double outstanding) { //Output to console on paid
			if (outstanding == 0) {
				Console.Write(getWriteableType() + " has not paid anything!  ");
			}
			else {
				Console.Write(getWriteableType() + " has paid $" + outstanding + ".  ");
				if (fee > paid) {
					Console.Write("$" + (fee - paid) + " remaining\n");
				}
				else {
					Console.Write("No remaining fees\n");
				}
			}
		}

		void increaseFee(double newFee) { //increasing fee 
			fee += newFee;
			Console.Write("The fee of this vehicle has been increased by $" + newFee + "!\n");
		}

		public Type getType() {
			return type;
		}

		public string getWriteableType() {
			switch (type) {
				case Type.LuxuryCar:
					return "Luxury Car";
				case Type.StandardCar:
					return "Standard Car";
				case Type.Motorbike:
					return "Motorbike";
				case Type.Truck:
					return "Truck";
				default:
					Console.Write("ERROR: NO TYPE DETECTED!\n");
					return "Null";
			}
		}

		public int getWeight() {
			return weight;
		}

		public double getFee() {
			return fee;
		}

		public double getPaid() {
			return paid;
		}

		public double getOutstanding() {
			return fee - paid;
		}

		public double calcFee() { //calculate fee of vehicle
			double fee = 2;
			switch (type) { //check type of vehicle
				case Type.LuxuryCar:
					fee += 3;
					goto case Type.StandardCar; //no fallthrough available on C# -> Workaround.
				case Type.StandardCar:
					fee += 5;
					break;
				case Type.Motorbike:
					fee += 2;
					break;
				case Type.Truck:
					fee += 10;
					break;
				default:
					Console.Write("ERROR: NO TYPE DETECTED!\n");
					break;
			}

			if (weight > 100) {//check if weight over
				fee += 3;
			}

			return fee;
		}
	}
}
