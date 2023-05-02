using System;
using static System.Console;
using static System.Math;

public static class main{

	public static void Main(){
	double sqrt2=Sqrt(2.0);
	Write($"sqrt2^2 = {sqrt2*sqrt2}\n");

	Write($"2^1/5 = {Pow(2,0.2)}\n");

	Write($"e^pi = {Pow(E,PI)}\n");

	Write($"pi^e = {Pow(PI,E)}\n");
	
	WriteLine($"Gamma(1) = {sfuns.gamma(1)}");

	WriteLine($"Gamma(2) = {sfuns.gamma(2)}");

	WriteLine($"Gamma(3) = {sfuns.gamma(3)}");

	WriteLine($"Gamma(10) = {sfuns.gamma(10)}");

	WriteLine($"LnGamma(10) = {sfuns.lngamma(10)}");
	}
}
