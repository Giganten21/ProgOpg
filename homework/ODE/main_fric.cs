using System;
using static System.Console;
using static System.Math;

class main{
	static Func<double, vector, vector> F= (x,y) =>{
		double b = 0.25;
		double c = 5.0;
		return new vector(y[1], -b*y[1]-c*Sin(y[0])); /* theta'(X) = omega(x)*/
								/*omega' = -b*omeag -c*sin(theta)*/
		};

	static void Main(){
		vector ya = new vector(PI-0.1,0.0);
		double a = 0;
		double b = 10;
		(genlist<double> xs, genlist<vector> ys) = ode.driver(F,a,ya,b);

		for (int i=0; i<xs.size; i++){
			WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
			}
}
}
