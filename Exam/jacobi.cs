using System;
using static System.Math;
using static System.Console;

public static class jacobi{
	public static matrix timesJ(matrix A, int p, int q, double theta){
		double c = Cos(theta) , s = Sin(theta);
		//WriteLine($"timesJ c={c} s={s}"); 
		for( int i = 0; i<A.size1 ; i++){
			double aip=A[i,p],aiq=A[i,q];
			A[i,p]=c*aip-s*aiq;
			A[i,q]=s*aip+c*aiq;
		}
	return A;
	}

	public static matrix Jtimes(matrix A, int p, int q, double theta){
	double c=Cos(theta),s=Sin(theta);
	//WriteLine($"Jtimes c={c} s={s}");
	for(int j=0;j<A.size1;j++){
		double apj=A[p,j],aqj=A[q,j];
		A[p,j]= c*apj+s*aqj;
		A[q,j]= -s*apj+c*aqj;
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
                                timesJ(A,p,q, theta); // A←A*J
                                Jtimes(A,p,q,-theta); // A←JT*A
                                timesJ(V,p,q, theta); // V←V*J
                                }
                        }
                }while(changed);
                return V;
	}

	public static (matrix, matrix) hessenberg(matrix A){
		int n = A.size1;
                var Q = new matrix(n,n);
                Q.set_identity();

                bool changed;
                do{
                changed=false;
                for(int p=1;p<n-1;p++)
                for(int q=p+1;q<n;q++){
                        double apq=A[p-1,q], app=A[p-1,p-1], aqq=A[q,q];
                        double theta=0.5*Atan2(2*apq,aqq-app);
                        double c=Cos(theta),s=Sin(theta);
                        double new_app=c*c*app-2*s*c*apq+s*s*aqq;
                        double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
                        if(new_app!=app || new_aqq!=aqq) // do rotation
                                {
                                changed=true;
                                A = timesJ(A,p-1,q, theta); // A←A*J
                                A = Jtimes(A,p-1,q,-theta); // A←JT*A
                                Q = timesJ(Q,p-1,q, theta); // V←V*J
                                }
                        }
                }while(changed);
		var H = A;
                return (H,Q);
	}
		
		/*	int n = A.size1;
		var H = A.copy();
		var Q = matrix.id(n);
		bool changed;
		do{
		changed = false;
		for(int p =1; p<n-1; p++){
			for(int q=p+1; q<n; q++){
				double apq=A[p-1,q], app=A[p,p-1], aqq=A[q,q];
				double theta = 0.5*Atan2(2*H[p-1,q],H[q,q]-H[p,p-1]);
				double c=Cos(theta),s=Sin(theta);
				double new_app=c*c*app-2*s*c*apq+s*s*aqq;
                        	double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
				if(new_app!=app || new_aqq!=aqq) // do rotation
                                {
                                changed=true;
				// This should be right
				H = timesJ(H,p-1,q,theta);
				H = Jtimes(H,p-1,q,-theta);
				Q = timesJ(Q,p-1,q,theta);
				}
			}
		}
		if(Q*H*Q.T == A){changed = false;}
		}while(changed);
		return (H,Q);
	}*/
}
