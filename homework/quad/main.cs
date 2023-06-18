using System;
using static System.Console;
using static System.Math;

class main{
static void Main(){
	double exact,itg;
	Func<double,double> f;
	int n = 0;
	double acu = 0.001;

	exact = 2.0/3.0;
	WriteLine($"Testing sqrt(x)dx 0 to 1 = {exact}");
	f = delegate(double x){n++; return Sqrt(x);};
	n=0; itg = calc.integral(f,0,1);
	WriteLine($"Result of integration = {itg}, Error = {Abs(itg-exact)/exact}, Calls = {n}");
	if (Abs(itg-exact)<acu)WriteLine("Result within accuracy!\n");
	else WriteLine("Not within accuracy!\n");

	exact = 2.0;
        WriteLine($"Testing 1/sqrt(x)dx 0 to 1 = {exact}");
        f = delegate(double x){n++; return 1/Sqrt(x);};
        n=0; itg = calc.integral(f,0,1);
        WriteLine($"Result of integration = {itg}, Error = {Abs(itg-exact)/exact}, Calls = {n}");
	if (Abs(itg-exact)<acu)WriteLine("Result within accuracy!\n");
        else WriteLine("Not within accuracy!\n");

	exact = PI;
        WriteLine($"Testing 4*sqrt(1-x^2)dx 0 to 1 = {exact}");
        f = delegate(double x){n++; return 4*Sqrt(1-Pow(x,2));};
        n=0; itg = calc.integral(f,0,1);
        WriteLine($"Result of integration = {itg}, Error = {Abs(itg-exact)/exact}, Calls = {n}");
	if (Abs(itg-exact)<acu)WriteLine("Result within accuracy!\n");
        else WriteLine("Not within accuracy!\n");

	exact = -4.0;
        WriteLine($"Testing ln(x)/sqrt(x)dx 0 to 1 = {exact}");
        f = delegate(double x){n++; return Log(x)/Sqrt(x);};
        n=0; itg = calc.integral(f,0,1);
        WriteLine($"Result of integration = {itg}, Error = {Abs(itg-exact)/exact}, Calls = {n}");
	if (Abs(itg-exact)<acu)WriteLine("Result within accuracy!\n");
        else WriteLine("Not within accuracy!\n");

}
}
