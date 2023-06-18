using System;
using static System.Math;
public static partial class sfuns{
	public static double erf(double z){
	/// single precision error function (Abramowitz and Stegun, from Wikipedia)
	if(z<0) return -erf(-z);
	Func<double, double> f;
	f = delegate(double x){return Exp(-Pow(x,2));};
	if(0<=z && z<=1) return 2/Sqrt(PI) * calc.integral(f,0,z);
	f=delegate(double x){return Exp((-Pow(z+(1-x)/x,2)/x/x));};
	if(1<z) return 1-(2/Sqrt(PI)) * calc.integral(f,0,1);
	double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
	double t=1/(1+0.3275911*z);
	double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
	return 1-sum*Exp(-z*z);

	}
}
