using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    /// <summary>
    /// Represents a parking lot with functionality to add, remove, and list parked vehicles.
    /// </summary>
    public class Parking
    {
        private decimal initialPrice = 0;
        private decimal pricePerHour = 0;
        private List<string> vehicles = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Parking"/> class with specified initial price and hourly rate.
        /// </summary>
        /// <param name="initialPrice">The initial price for parking.</param>
        /// <param name="pricePerHour">The hourly rate for parking.</param>
        /// <exception cref="ArgumentException">Thrown when either initial price or hourly rate is negative.</exception>
        public Parking(decimal initialPrice, decimal pricePerHour)
        {
            if (initialPrice < 0 || pricePerHour < 0)
            {
                throw new ArgumentException("Prices cannot be negative.");
            }

            this.initialPrice = initialPrice;
            this.pricePerHour = pricePerHour;
        }

        /// <summary>
        /// Adds a vehicle to the parking lot.
        /// </summary>
        public void AddVehicle()
        {
            Console.WriteLine("Enter the vehicle plate for parking:");
            string plate = Console.ReadLine().Trim();

            Regex regex = new Regex(@"^[A-Z]{3}\-\d{4}$");

            if (regex.IsMatch(plate))
            {
                vehicles.Add(plate);
                Console.WriteLine($"Vehicle with plate {plate} added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid plate. Please enter a valid plate in the format ABC-1234.");
            }
        }

        /// <summary>
        /// Removes a vehicle from the parking lot.
        /// </summary>
        public void RemoveVehicle()
        {
            Console.WriteLine("Enter the vehicle plate to remove:");
            string plate = Console.ReadLine().Trim();

            if (!string.IsNullOrWhiteSpace(plate))
            {
                if (vehicles.Any(x => x.ToUpper() == plate.ToUpper()))
                {
                    try
                    {
                        Console.WriteLine("Enter the number of hours the vehicle was parked:");
                        int hours = int.Parse(Console.ReadLine().Trim());

                        if (hours < 0)
                        {
                            throw new ArgumentException("Hours cannot be negative.");
                        }

                        decimal totalPrice = initialPrice + pricePerHour * hours;

                        vehicles.Remove(plate);

                        Console.WriteLine($"The vehicle {plate} was removed and the total price was: R$ {totalPrice}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a numeric value for hours.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, this vehicle is not parked here. Please check if you entered the correct plate.");
                }
            }
            else
            {
                Console.WriteLine("Invalid plate. Please enter a valid plate.");
            }
        }

        /// <summary>
        /// Lists all vehicles parked in the parking lot.
        /// </summary>
        public void ListVehicles()
        {
            if (vehicles.Any())
            {
                Console.WriteLine("Parked vehicles:");

                foreach (string plate in vehicles)
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("There are no parked vehicles.");
            }
        }
    }
}

