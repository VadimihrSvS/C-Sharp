using System;
using System.Collections.Generic;
					
public class Program
{
	static List<Numbers> list = new List<Numbers>();
	public static void Main()
	{
		string temperature = "";
		temperature = Console.ReadLine();
		float x = (float)Convert.ToDouble(temperature);
		Numbers low = null, high = null;
		float household = 0, population = 0, sum = 0;
		init();
		foreach(Numbers number in list){
			if (low != null) {
				high = number;
				sum = low.sum + (((high.sum - low.sum) / (high.temp - low.temp)) * (x - low.temp));
				population = low.population + (((high.population - low.population) / (high.temp - low.temp)) * (x - low.temp));
				household = low.household + (((high.household - low.household) / (high.temp - low.temp)) * (x - low.temp));
				break;
			}
			if(number.temp == x){
				household = number.household;
				population = number.population;
				sum = number.sum;
				break;
			}
			if(number.temp - 1 < x){
				low = number;
				continue;
			}
		}
		
		
		Console.WriteLine("Комбыт + население : ");
		Console.WriteLine(sum);
		Console.WriteLine("Население : ");
		Console.WriteLine(population);

		Console.ReadLine();
		
	}
	
	public static void init(){
		list.Add(new Numbers(20, 0, 0, 250));
		list.Add(new Numbers(18, 0, 0, 290));
		list.Add(new Numbers(17, 0, 0, 300));
		list.Add(new Numbers(15, 0, 0, 350));
		list.Add(new Numbers(14, 0, 0, 380));
		list.Add(new Numbers(13, 0, 0, 515));
		list.Add(new Numbers(11, 0, 0, 550));
		list.Add(new Numbers(9, 0, 0, 685));
		list.Add(new Numbers(6, 160, 855, 1015));
		list.Add(new Numbers(5, 170, 870, 1040));
		list.Add(new Numbers(4, 180, 910, 1090));
		list.Add(new Numbers(3, 190, 920, 1110));
		list.Add(new Numbers(2, 200, 1100, 1300));
		list.Add(new Numbers(1, 220, 1200, 1420));
		list.Add(new Numbers(0, 240, 1290, 1530));
		list.Add(new Numbers(-1, 260, 1300, 1560));
		list.Add(new Numbers(-2, 280, 1360, 1640));
		list.Add(new Numbers(-3, 300, 1380, 1680));
		list.Add(new Numbers(-4, 320, 1450, 1770));
		list.Add(new Numbers(-5, 340, 1470, 1810));
		list.Add(new Numbers(-6, 345, 1520, 1865));
		list.Add(new Numbers(-7, 350, 1570, 1920));
		list.Add(new Numbers(-8, 355, 1600, 1955));
		list.Add(new Numbers(-9, 360, 1630, 1990));
		list.Add(new Numbers(-10, 365, 1650, 2015));
		list.Add(new Numbers(-11, 370, 1705, 2075));
		list.Add(new Numbers(-12, 375, 1720, 2095));
		list.Add(new Numbers(-13, 380, 1750, 2130));
		list.Add(new Numbers(-14, 385, 1790, 2175));
		list.Add(new Numbers(-15, 385, 1800, 2185));
		list.Add(new Numbers(-16, 385, 1810, 2195));
		
	}
}

class Numbers {
	public int temp, household, population, sum = 0;
	
	public Numbers(int temp, int household, int population, int sum) {
		this.temp = temp;
		this.household = household;
		this.population = population;
		this.sum = sum;
	}
	
}
