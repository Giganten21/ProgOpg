using System;
using static System.Console;
using static System.Math;

class main{

static Func<vector, double> f = (x) =>
	{
	if (Pow(x[0],2) + Pow(x[1],2) <=1) return 1.0;
	else return 0.0;
	};
static Func<vector, double> F = (x) => 1.0/PI/PI/PI/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]));
static void Main(){
	vector a = new vector(-1,-1);
	vector b = new vector(1,1);
	int n = 100000;

	var result = mc.plainmc(f,a,b,n);
	for (int i=1;i<n;i+=100){
		var res = mc.plainmc(f,a,b,i);
		WriteLine($"{i}	{res.Item2}");
	}
	WriteLine("\n");
	WriteLine("Example with at unit circle:");
	WriteLine($"Area estimate:{result.Item1} Error:{result.Item2}");

	vector x = new vector(0,0,0);
	vector y = new vector(PI,PI,PI);
	int N = 10000000;
	var integral = mc.plainmc(F,x,y,N);
	WriteLine("∫0π  dx/π ∫0π  dy/π ∫0π  dz/π [1-cos(x)cos(y)cos(z)]-1");
	WriteLine($"Integral estimate:{integral.Item1} Error:{integral.Item2}");
}
}
