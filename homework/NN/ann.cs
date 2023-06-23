using System;
using static System.Console;
using static System.Math;

public class ann{
	public int n; /* number of hidden neurons */
	Func<double,double> f; //= x => x*Exp(-x*x); /* activation function */
	public vector p; /* network parameters */
	public ann(int n, Func<double,double> f){/* constructor */
   		this.n = n;
		this.f = f;
		int nparam = 3*n;
		p = new vector(nparam);
	}


	public double response(double x){
      	/* return the response of the network to the input signal x */
		//Fp(x) = ∑i f((x-ai)/bi)*wi
		double F = 0;
		for(int i=0;i<n;i++){
			double ai =p[i];
			double bi =p[i+n];
			double wi =p[2+2*n];
			F += f((x-ai)/bi)*wi;
		}
		return F;
	}
	public void train(vector x,vector y){
		double xmin = x.min(), xmax = x.max();

		for(int i = 0; i<p.size; i++){
			if(i<n) {p[i]=xmin + (xmax-xmin)*i/(n+1);}
			else p[i] = 1;
		}

		/* train the network to interpolate the given table {x,y} */
		Func<vector,double> cp = c =>{
			p = c;
			double sum = 0;
			for(int i=0; i<x.size; i++){
				sum += Pow(response(x[i]) - y[i],2);
			}
		return sum/x.size;
		};
		
		vector par = p;
		double accuracy = 1e-3;
		var steps = qnewton.min(cp, ref par, accuracy);
		var res = par;
	}
}
