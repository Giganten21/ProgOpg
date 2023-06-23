using System;
using static System.Console;
using static System.Math;

class main{

public static void Main(){
	int n=5, N=200;
	double[] x= new double[n];
	double[] y= new double[n];
	int i;
	for(i=0; i<n; i++){
		x[i]=i*PI;
		y[i]=x[i]*4+6;
		WriteLine($"{x[i]} {y[i]}");
	}
	Write("\n\n");
	double z, step=(x[n-1]-x[0])/(N-1);
	for (z=x[0], i=0; i<N; z=x[0]+(++i)*step){
		WriteLine($"{z} {4*z+6} {spline.linterp(x,y,z)}");
	}
	Write("\n\n");
	for (z=x[0], i=0; i<N; z=x[0]+(++i)*step){
		WriteLine($"{z} {Pow(z,2)*2+6*z} {spline.linterpInteg(x,y,z)}");
	}
	WriteLine("\n\n");
	double l;
	for (i = 0; i<n;i++){
		l = i*PI
		WriteLine($"{l} {Pow(l,2)*2+6*l}");
	}	
	}
}
