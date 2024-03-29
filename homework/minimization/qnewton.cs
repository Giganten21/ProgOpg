using System;
using static System.Console;
using static System.Math;

public static partial class qnewton{
	public static double lambda_min = Pow(2,-12);
	public static double DELTA = Pow(2,-26);

	public static vector gradient(Func<vector,double>f,vector x){
	vector g=new vector(x.size);
	double fx=f(x);
	for(int i=0;i<x.size;i++){
		double dx=Abs(x[i])*DELTA;
		x[i]+=dx;
		g[i]=(f(x)-fx)/dx;
		x[i]-=dx;
	}
	return g;
	}
/*
	public static matrix hessian(Func<vector,double>phi,vector x){
	matrix H=new matrix(x.size);
	Func<vector,vector> f = z => gradient(phi,z);Out.txt : main.exe
	mono main.exe > Out.txt
	vector dx=x.map(t => Abs(t)*DELTA);
	vector fx=f(x);
	for(int j=0;j<x.size;j++){
		x[j]+=dx[j];
		vector df=f(x)-fx;
		for(int i=0;i<x.size;i++) H[i,j]=df[i]/dx[j];
		x[j]-=dx[j];
	}
	return H;
}*/

	public static int min
	(Func<vector,double>f,ref vector x, double acc=1e-3){
	double fx=f(x);
	vector gx=gradient(f,x);
/*
	matrix H=hessian(f,x);
	var qrH=new givensQR(H);
	matrix B=qrH.inverse();
*/
	matrix B=matrix.id(x.size);
	int nsteps=0;
	while(nsteps<1000){
		if(gx.norm()<acc) break;
		nsteps++;
		vector Dx=-B*gx;
		vector z;
		double fz,lambda=1;
		do{// backtracking linesearch
			z=x+lambda*Dx;
			fz=f(z);
			if(fz<fx) break; // good step
			if(lambda<lambda_min){
				B.setid();
/*
				H=hessian(f,z);
				qrH=new givensQR(H);
				B=qrH.inverse();
*/
				break; // accept anyway
				}
			lambda/=2;
		}while(true);
		vector s=z-x;
		vector gz=gradient(f,z);
		vector y=gz-gx;
		vector u=s-B*y;
		double uTy=u%y;
		if(Abs(uTy)>1e-6){
			B.update(u,u,1/uTy);
		}
		x=z; gx=gz; fx=fz;
	}//while
	return nsteps;
}//root

}

