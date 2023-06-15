using System;
using static System.Console;
using static System.Math;
class main{
static void Main(){
	int n=5, N=200;
	double[] x= new double[n];
	double[] y= new double[n];
	
	int i;
	for(i=0; i<n; i++){
		x[i]=2*PI*i/(n-1);
		y[i]=Sin(x[i]);
		WriteLine("{} {}",x[i],y[i]);
		}
	Write("\n");

	double z, step=(x[n-1]-x[0])/(N-1);
	for (z=x[0], i=0; i<N; z=x[0]+(++i)*step){
		WriteLine($"{z} {Sin(z)} {spline.linterp(x,y,z)}");
		}
	Write("\n");

	for (z=x[0], i=0; i<N; z=x[0]+(++i)*step){
		WriteLine($"{z} {Cos(z)} {spline.linterpInteg(x,y,z)}");
		}
	
}
}
