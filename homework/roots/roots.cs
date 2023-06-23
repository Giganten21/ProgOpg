using System;
using static System.Console;
using static System.Math;
public static partial class roots{
public static vector newton(Func<vector, vector> f, vector x, double e=1e-2){
		vector fx=f(x),z,fz;
		int n = x.size;
		vector dx, deltx;
		dx = null;
		var df = new vector(n);
		matrix J = new matrix(n,n);
		dx = null;
		double delta = Pow(2,-26);

		do{
			if(dx==null) dx = x.map(xi => Abs(xi)*delta);
			for(int j=0;j<n;j++){
				x[j] += dx[j];
				df = (f(x)-fx);
				for (int k=0;k<n;k++){
					J[k,j] = df[k]/dx[j];
				}
				x[j] -= dx[j];
			}
			var R = new matrix(n,n);
			QRGS.decomp(J,R);
			deltx = QRGS.solve(J,R,-fx);
			double lambda = 2;
			do{
				lambda /= 2;
				z = x + deltx*lambda;
				fz = f(z);
			}while(fz.norm() > (1-lambda/2)*fx.norm() && lambda>1.0/1024);
			x = z;
			fx = fz;

		}while(fx.norm() > e);
		return x;
	}
}
