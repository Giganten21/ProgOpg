using System;
using static System.Math;

public static class jacobi{
	public static matrix timesJ(matrix A, int p, int q, double theta){
		double c = Cos(theta) , s = Sin(theta);
		for( int i = 0; i<A.size1 ; i++){
			double aip=A[i,p],aiq=A[i,q];
			A[i,p]=c*aip-s*aiq;
			A[i,q]=s*aip+c*aiq;
		}
		return A;
	}

	public static matrix Jtimes(matrix A, int p, int q, double theta){
	double c=Cos(theta),s=Sin(theta);
	for(int j=0;j<A.size1;j++){
		double apj=A[p,j],aqj=A[q,j];
		A[p,j]= c*apj+s*aqj;
		A[q,j]=-s*apj+c*aqj;
		}
		return A;
	}

	public static matrix cyclic(matrix A){
		int n = A.size1;
		var V = new matrix(n,n);
		V.set_identity();

		bool changed;
		do{
		changed=false;
		for(int p=0;p<n-1;p++)
		for(int q=p+1;q<n;q++){
			double apq=A[p,q], app=A[p,p], aqq=A[q,q];
			double theta=0.5*Atan2(2*apq,aqq-app);
			double c=Cos(theta),s=Sin(theta);
			double new_app=c*c*app-2*s*c*apq+s*s*aqq;
			double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
			if(new_app!=app || new_aqq!=aqq) // do rotation
				{
				changed=true;
				A=timesJ(A,p,q, theta); // A←A*J
				A=Jtimes(A,p,q,-theta); // A←JT*A
				V=timesJ(V,p,q, theta); // V←V*J
				}
			}
		}while(changed);
		return V;
	}

	public static (matrix, matrix) hessenberg(matrix A){
		int n = A.size1;
		var V = new matrix(n,n);
		V.set_identity();
		// p -> 2 to n-1 
		// q -> 3 to n
		// Starts with p as J(2,3) -> J(2,n)
		for (int p = 0; p < n-1; p++){
			// Then q as J(2,n) -> J(n-1,n)
			for (int q = p+2; q < n; q++){
				//double theta=0.5*Atan2(2*A[p,q],A[q,q]-A[p,p]);
				double theta = Atan2(A[q,p], A[q-1,p]);
				A=Jtimes(A,q-1,q,theta);
			       	A=timesJ(A,q-1,q,-theta);
				V=Jtimes(V,q-1,q,theta);
			}
		}
		return (A,V);
	}
}
