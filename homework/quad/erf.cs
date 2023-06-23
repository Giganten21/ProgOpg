using System;
using static System.Math;
public static partial class er{
	public static double erf(double z){
	/// single precision error function (Abramowitz and Stegun, from Wikipedia)
	if(z<0) {return -erf(-z);}
	Func<double, double> f;
	if((z>=0) && (z<=1.0)){
	f = delegate(double x){return Exp(-Pow(x,2));};
	return 2.0/Sqrt(PI) * calc.integral(f,0,z);
	}
	if(1.0<z){
	f=delegate(double x){return Exp(-Pow(z+(1-x)/x,2))/x/x;};
	return 1-(2.0/Sqrt(PI)) * calc.integral(f,0,1);
	}
	return 0.0;
	}
}
