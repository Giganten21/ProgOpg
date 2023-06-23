using System;
using static System.Console;
using static System.Math;

public class ann{
	public int n; /* number of hidden neurons */
	public Func<double,double> f = x => x*Exp(-x*x); /* activation function */
	public vector p; /* network parameters */
	public ann(int n, Func<vector,vector> f){/* constructor */
   		this.n = n;
		this.f = f;
		int nparam = 3*n;
		p = new vector(nparam);
		IntializaParameters();
	}
	
	void InitializeParameters(){
        Random rand = new Random();
        for (int i = 0; i < 3 * n; i++){
		p[i] = rand.NextDouble() * 2 - 1; // initialize parameters randomly between -1
		}
    	}

	public double response(double x){
      	/* return the response of the network to the input signal x */
		//Fp(x) = ∑i f((x-ai)/bi)*wi
		double F = 0;
		for(int i;i<n;i++){
			double ai =p[i];
			double bi =p[i+n];
			double wi =p[i*2*n];
			F += f((x-ai)/bi)*wi;
		}
		return F;
	}
   void train(vector x,vector y){
      /* train the network to interpolate the given table {x,y} */
   }
}
