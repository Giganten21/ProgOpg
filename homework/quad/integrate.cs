using System;
using static System.Console;
using static System.Math;
using static System.Double;
public static partial class calc{
	public static double integral
	(Func<double,double> f, double a, double b,
	double delta = 0.001, double eps=0.001, double f2=double.NaN, double f3=double.NaN)
	{
	double h=b-a;
	if(double.IsNaN(f2)){ f2=f(a+2*h/6); f3=f(a+4*h/6); } // first call, no points to reuse
	double f1=f(a+h/6), f4=f(a+5*h/6);
	double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
	double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
	double err = Abs(Q-q);
	if (err <= delta+eps*Abs(Q)) return Q;
	else return integral(f,a,(a+b)/2,delta/Sqrt(2),eps,f1,f2)+
		integral(f,(a+b)/2,b,delta/Sqrt(2),eps,f3,f4);
}	
}
