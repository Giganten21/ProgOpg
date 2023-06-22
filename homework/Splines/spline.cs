using System;
using static System.Math;
public class spline{
	public static int binsearch(double[] x, double z)
	{/* locates the interval for z by bisection */ 
	if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
	int i=0, j=x.Length-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}

	public static double linterp(double[] x, double[] y, double z){
        	int i=binsearch(x,z);
        	double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        	double dy=y[i+1]-y[i];
        	return y[i]+dy/dx*(z-x[i]);
        }

	public static double linterpInteg(double[] x, double[] y, double z){
		int i=binsearch(x,z);
		double sum = 0;
		for (int j=0; j<i; j++){
			double dyj = y[j+1] -y[j];
			double dxj = x[j+1] -x[j];
			sum += y[j]*dxj + 1.0/2*dyj*dxj;
		}

		double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        	double dy=y[i+1]-y[i];
		double pi = dy/dx;
		sum += y[i]*(z-x[i])+1.0/2*pi*(z-x[i])*(z-x[i]);
		return sum;
	}
}
