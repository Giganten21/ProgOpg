using System;
public static partial class ode{
	public static (vector,vector) rkstep12(
		Func<double,vector,vector> f,double x,vector y,double h)
		{
		vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
		vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
		vector yh = y+k1*h;              /* y(x+h) estimate */
		vector er = (k1-k0)*h;           /* error estimate */
		return (yh,er);
	}
}
